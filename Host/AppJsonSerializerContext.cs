using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(JsonNode))]

internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}