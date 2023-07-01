using System.Text.Json.Serialization;

namespace HippocampusWeb.Values;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RecipientState
{
    Empty,
    Average,
    Full
}