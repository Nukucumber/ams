using System;
using System.Text;
using Fund.Infrastructure.RepoGenerator.Models;

namespace Fund.Infrastructure.RepoGenerator.Emitters;

internal static class DdlEmitter
{
    public static string Emit(EntityModel entity)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"namespace Fund.Infrastructure.SimpleSqlSourceGenerated;");
        sb.AppendLine();
        sb.AppendLine($"using {entity.Namespace};");
        sb.AppendLine();
        sb.AppendLine($"public static class {entity.Name}Extension");
        sb.AppendLine("{");
        sb.AppendLine($"    extension({entity.Name})");
        sb.AppendLine("    {");
        sb.AppendLine("        public static string GetInitCommand()");
        sb.AppendLine("        {");
        sb.AppendLine("            return @\"");
        sb.AppendLine($"                CREATE TABLE IF NOT EXISTS {entity.Name}");
        sb.AppendLine("                (");

        for (var i = 0; i < entity.Properties.Count; i++)
        {
            var property = entity.Properties[i];
            var suffix = i < entity.Properties.Count - 1
                ? ","
                : string.Empty;

            sb.AppendLine(
                $"                    {BuildColumn(property)}{suffix}");
        }

        sb.AppendLine("                );");
        sb.AppendLine("            \";");
        sb.AppendLine("        }");
        sb.AppendLine("    }");
        sb.AppendLine("}");

        return sb.ToString();
    }

    private static string BuildColumn(
        PropertyModel property)
    {
        var sqlType =
            GetSqlType(property.UnderlyingType);

        var nullable =
            property.IsNullable
                ? string.Empty
                : " NOT NULL";

        var primaryKey =
            property.Name == "Id"
                ? " PRIMARY KEY"
                : string.Empty;

        return
            $"{property.Name,-16} " +
            $"{sqlType,-10}" +
            $"{nullable}" +
            $"{primaryKey}";
    }

    private static string GetSqlType(
     string fullyQualifiedType)
    {
        return fullyQualifiedType switch
        {
            "string" or
            "global::System.String" =>
                "TEXT",

            "Guid" or
            "System.Guid" or
            "global::System.Guid" =>
                "TEXT",

            "int" or
            "System.Int32" or
            "global::System.Int32" =>
                "INTEGER",

            "long" or
            "System.Int64" or
            "global::System.Int64" =>
                "INTEGER",

            "short" or
            "System.Int16" or
            "global::System.Int16" =>
                "INTEGER",

            "uint" or
            "System.UInt32" or
            "global::System.UInt32" =>
                "INTEGER",

            "ulong" or
            "System.UInt64" or
            "global::System.UInt64" =>
                "INTEGER",

            "ushort" or
            "System.UInt16" or
            "global::System.UInt16" =>
                "INTEGER",

            "byte" or
            "System.Byte" or
            "global::System.Byte" =>
                "INTEGER",

            "sbyte" or
            "System.SByte" or
            "global::System.SByte" =>
                "INTEGER",

            "bool" or
            "System.Boolean" or
            "global::System.Boolean" =>
                "INTEGER",

            "double" or
            "System.Double" or
            "global::System.Double" =>
                "REAL",

            "float" or
            "System.Single" or
            "global::System.Single" =>
                "REAL",

            "decimal" or
            "System.Decimal" or
            "global::System.Decimal" =>
                "NUMERIC",

            "DateTime" or
            "System.DateTime" or
            "global::System.DateTime" =>
                "TEXT",

            "DateTimeOffset" or
            "System.DateTimeOffset" or
            "global::System.DateTimeOffset" =>
                "TEXT",

            "byte[]" or
            "System.Byte[]" or
            "global::System.Byte[]" =>
                "BLOB",

            _ => throw new InvalidOperationException(
                $"Unsupported SQL type: {fullyQualifiedType}")
        };
    }
}