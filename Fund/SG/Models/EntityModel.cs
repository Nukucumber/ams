using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace Fund.Infrastructure.RepoGenerator.Models;

internal sealed class EntityModel
{
    public string Name { get; }

    public string Namespace { get; }

    public string FullyQualifiedName { get; }

    public IReadOnlyList<PropertyModel> Properties { get; }

    public PropertyModel Id =>
        Properties.First(property =>
            property.Name == "Id");

    public IReadOnlyList<PropertyModel> NonIdProperties =>
        Properties
            .Where(property =>
                property.Name != "Id")
            .ToArray();

    private EntityModel(
        string name,
        string @namespace,
        string fullyQualifiedName,
        IReadOnlyList<PropertyModel> properties)
    {
        Name = name;
        Namespace = @namespace;
        FullyQualifiedName = fullyQualifiedName;
        Properties = properties;
    }

    public static EntityModel Create(
        INamedTypeSymbol symbol)
    {
        var properties = symbol
            .GetMembers()
            .OfType<IPropertySymbol>()
            .Where(static property =>
                property.DeclaredAccessibility ==
                    Accessibility.Public
                && !property.IsStatic
                && property.GetMethod is not null)
            .Select(PropertyModel.Create)
            .ToArray();

        return new EntityModel(
            name: symbol.Name,

            @namespace:
                symbol.ContainingNamespace
                    .ToDisplayString(),

            fullyQualifiedName:
                symbol.ToDisplayString(
                    SymbolDisplayFormat
                        .FullyQualifiedFormat),

            properties:
                properties);
    }
}
