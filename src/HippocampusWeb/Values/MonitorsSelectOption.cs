namespace HippocampusWeb.Values;

public class MonitorsSelectOption
{
    public string Name { get; init; }
    public string MacAddress { get; init; }

    public override string ToString()
    {
        return Name;
    }
}