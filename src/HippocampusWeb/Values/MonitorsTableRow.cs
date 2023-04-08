namespace HippocampusWeb.Values;

public class MonitorsTableRow
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public RecipientType RecipientType { get; init; }
    public int Level { get; init; }
    public RecipientState RecipientState { get; init; } 
    public bool IsPumpOn { get; init; }
}