using Microsoft.CodeAnalysis;

namespace Fund.Infrastructure.RepoGenerator.Models;

internal sealed class PropertyModel
{
    public string Name { get; }

    public string FullyQualifiedType { get; }

    public string UnderlyingType { get; }

    public bool IsNullable { get; }

    private PropertyModel(
        string name,
        string fullyQualifiedType,
        string underlyingType,
        bool isNullable)
    {
        Name = name;
        FullyQualifiedType = fullyQualifiedType;
        UnderlyingType = underlyingType;
        IsNullable = isNullable;
    }

    public static PropertyModel Create(
        IPropertySymbol property)
    {
        var type = property.Type;

        var underlyingType = type;

        if (type is INamedTypeSymbol
            {
                IsGenericType: true,
                Name: "Nullable"
            } nullable)
        {
            underlyingType =
                nullable.TypeArguments[0];
        }

        var isNullable =
            property.NullableAnnotation ==
                NullableAnnotation.Annotated
            || type is INamedTypeSymbol
            {
                IsGenericType: true,
                Name: "Nullable"
            };

        return new PropertyModel(
            name: property.Name,

            fullyQualifiedType:
                type.ToDisplayString(
                    SymbolDisplayFormat
                        .FullyQualifiedFormat),

            underlyingType:
                underlyingType.ToDisplayString(
                    SymbolDisplayFormat
                        .FullyQualifiedFormat),

            isNullable:
                isNullable);
    }
}
