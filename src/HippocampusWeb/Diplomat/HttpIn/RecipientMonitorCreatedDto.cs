using HippocampusWeb.Values;

namespace HippocampusWeb.Diplomat.HttpIn;

public class RecipientMonitorCreatedDto
{
    public Guid RecipientMonitorId { get; init; } = Guid.Empty;
    public string MacAddress { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public RecipientType RecipientType { get; init; }
    public RecipientBoundary RecipientBoundary { get; init; } = new();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public RecipientMonitorLinkedToCreatedDto? RecipientMonitorLinkedTo { get; init; }
}

public class RecipientMonitorLinkedToCreatedDto
{
    public Guid RecipientMonitorId { get; init; } = Guid.Empty;
    public string MacAddress { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public RecipientType RecipientType { get; init; }
    public RecipientBoundary RecipientBoundary { get; init; } = new();
}