using System.Collections.Immutable;

using System.Linq;

using Fund.Infrastructure.RepoGenerator.Emitters;

using Fund.Infrastructure.RepoGenerator.Models;

using Microsoft.CodeAnalysis;

namespace Fund.Infrastructure.RepoGenerator;

[Generator]
public sealed class SqlGenerator : IIncrementalGenerator
{
    private const string FundEntityMetadataName =
        "Fund.Core.Domain.Abstractions.FundEntityBase";

    public void Initialize(
        IncrementalGeneratorInitializationContext context)
    {
        var entities =
            context.CompilationProvider
                .Select(static (compilation, _) =>
                    GetEntities(compilation));


        context.RegisterSourceOutput(
            entities,
            static (context, entities) =>
            {
                foreach (var entity in entities)
                {
                    Generate(context, entity);
                }
            });


        context.RegisterSourceOutput(
            entities,
            static (context, entities) =>
            {
                GenerateDependencyInjection(
                    context,
                    entities);
            });

        context.RegisterSourceOutput(
            entities,
            static (context, entities) =>
            {
                foreach (var entity in entities)
                {
                    GenerateDdl(context, entity);
                }
            });

        context.RegisterSourceOutput(
            entities,
            static (context, entities) =>
            {
                GenerateDataInitializer(
                    context,
                    entities);
            });
    }

    private static ImmutableArray<EntityModel> GetEntities(
        Compilation compilation)
    {
        var fundEntity =
            compilation.GetTypeByMetadataName(
                FundEntityMetadataName);

        if (fundEntity is null)
        {
            return ImmutableArray<EntityModel>.Empty;
        }

        var entities =
            ImmutableArray.CreateBuilder<EntityModel>();

        VisitNamespace(
            fundEntity.ContainingAssembly.GlobalNamespace,
            fundEntity,
            entities);

        return entities.ToImmutable();
    }

    private static void VisitNamespace(
        INamespaceSymbol @namespace,
        INamedTypeSymbol fundEntity,
        ImmutableArray<EntityModel>.Builder entities)
    {
        foreach (var type in @namespace.GetTypeMembers())
        {
            VisitType(
                type,
                fundEntity,
                entities);
        }

        foreach (var childNamespace in @namespace.GetNamespaceMembers())
        {
            VisitNamespace(
                childNamespace,
                fundEntity,
                entities);
        }
    }

    private static void VisitType(
        INamedTypeSymbol type,
        INamedTypeSymbol fundEntity,
        ImmutableArray<EntityModel>.Builder entities)
    {

        if (!type.IsAbstract &&
            SymbolEqualityComparer.Default.Equals(
                type.BaseType,
                fundEntity))
        {
            entities.Add(
                EntityModel.Create(type));
        }

        // if (!type.IsAbstract &&
        //     type.AllInterfaces.Any(
        //         i => SymbolEqualityComparer.Default.Equals(
        //             i,
        //             fundEntity)))
        // {
        //     entities.Add(
        //         EntityModel.Create(type));
        // }

        foreach (var nestedType in type.GetTypeMembers())
        {
            VisitType(
                nestedType,
                fundEntity,
                entities);
        }
    }

    private static void GenerateDataInitializer(
        SourceProductionContext context,
        ImmutableArray<EntityModel> entities)
    {
        var source =
            DataInitializerEmitter.Emit(entities);

        context.AddSource(
            "DbDataInitializer.g.cs",
            source);
    }

    private static void Generate(
        SourceProductionContext context,
        EntityModel entity)
    {
        var source =
            RepositoryEmitter.Emit(entity);

        context.AddSource(
            $"{entity.Name}Repository.g.cs",
            source);
    }

    private static void GenerateDependencyInjection(
        SourceProductionContext context,
        ImmutableArray<EntityModel> entities)
    {
        var source =
            DependencyInjectionEmitter.Emit(
                entities
                    .Where(static entity => entity is not null)
                    .Select(static entity => entity!)
                    .ToArray());

        context.AddSource(
            "RepositoryDependencyInjection.g.cs",
            source);
    }

    private static void GenerateDdl(
        SourceProductionContext context,
        EntityModel entity)
    {
        var source =
            DdlEmitter.Emit(entity);

        context.AddSource(
            $"{entity.Name}Extension.g.cs",
            source);
    }
}