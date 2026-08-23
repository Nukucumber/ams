// using System;
// using System.Collections.Immutable;
// using System.Linq;
// using Fund.Infrastructure.RepoGenerator.Emitters;
// using Fund.Infrastructure.RepoGenerator.Models;
// using Microsoft.CodeAnalysis;
// using Microsoft.CodeAnalysis.CSharp.Syntax;

// namespace Fund.Infrastructure.RepoGenerator;

// [Generator]
// public sealed class SqlGenerator : IIncrementalGenerator
// {
//     private const string FundEntityMetadataName =
//         "Fund.Core.Abstractions.IFundEntity";

//     private const string RepositoryMetadataName =
//         "Fund.Core.Repositories.IRepository";

//     public void Initialize(
//         IncrementalGeneratorInitializationContext context)
//     {
//         var entities = context.SyntaxProvider
//             .CreateSyntaxProvider(
//                 static (node, _) =>
//                     node is ClassDeclarationSyntax,

//                 static (ctx, _) =>
//                     GetEntity(ctx))
//             .Where(static entity => entity is not null);

//         // Генерация конкретного репозитория
//         context.RegisterSourceOutput(
//             entities,
//             static (context, entity) =>
//             {
//                 Generate(context, entity!);
//             });

//         // Генерация регистрации найденного репозитория в DI
//         context.RegisterSourceOutput(
//             entities.Collect(),
//             static (context, entities) =>
//             {
//                 GenerateDependencyInjection(
//                     context,
//                     entities);
//             });

//         context.RegisterSourceOutput(
//             entities,
//             static (context, entity) =>
//             {
//                 GenerateDdl(context, entity!);
//             });

//         context.RegisterSourceOutput(
//             entities.Collect(),
//             static (context, entities) =>
//             {
//                 GenerateDataInitializer(context, entities);
//             });

        
//     }

//     private static void GenerateDataInitializer(SourceProductionContext context, ImmutableArray<EntityModel> entities)
//     {
//         var source =
//             DataInitializerEmitter.Emit(entities);

//         context.AddSource(
//             $"DbDataInitializer.g.cs",
//             source);
//     }

//     private static EntityModel GetEntity(
//         GeneratorSyntaxContext context)
//     {
//         if (context.SemanticModel.GetDeclaredSymbol(
//                 context.Node) is not INamedTypeSymbol symbol)
//         {
//             return null;
//         }

//         if (symbol.IsAbstract)
//             return null;

//         var fundEntity =
//             context.SemanticModel.Compilation
//                 .GetTypeByMetadataName(
//                     FundEntityMetadataName);

//         if (fundEntity is null)
//             return null;

//         if (!symbol.AllInterfaces.Any(
//                 i => SymbolEqualityComparer.Default.Equals(
//                     i,
//                     fundEntity)))
//         {
//             return null;
//         }

//         return EntityModel.Create(symbol);
//     }

//     private static void Generate(
//         SourceProductionContext context,
//         EntityModel entity)
//     {
//         var source =
//             RepositoryEmitter.Emit(entity);

//         context.AddSource(
//             $"{entity.Name}Repository.g.cs",
//             source);
//     }

//     private static void GenerateDependencyInjection(
//         SourceProductionContext context,
//         ImmutableArray<EntityModel> entities)
//     {
//         var source =
//             DependencyInjectionEmitter.Emit(
//                 entities
//                     .Where(static entity => entity is not null)
//                     .Select(static entity => entity!)
//                     .ToArray());

//         context.AddSource(
//             "RepositoryDependencyInjection.g.cs",
//             source);
//     }


//     private static void GenerateDdl(
//     SourceProductionContext context,
//     EntityModel entity)
//     {
//         var source =
//             DdlEmitter.Emit(entity);

//         context.AddSource(
//             $"{entity.Name}Extension.g.cs",
//             source);
//     }
// }