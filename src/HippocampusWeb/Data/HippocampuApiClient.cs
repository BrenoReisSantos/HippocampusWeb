using System.Net.Http.Json;
using HippocampusWeb.Diplomat.HttpIn;
using HippocampusWeb.Values;
using HippocampusWeb.Values.Forms;

namespace HippocampusWeb.Data;

public interface IHippocampusApiClient
{
    Task<RecipientMonitorCreatedDto?> PostRecipientMonitorAsync(RecipientMonitorCreationForm form);
    Task<RecipientMonitorCreatedDto?> UpdateRecipientMonitorAsync(RecipientMonitorUpdateForm form);
    Task<IEnumerable<MonitorsTableRow>?> GetMonitorsForTable();
    Task<IEnumerable<MonitorsSelectOption>?> GetMonitorsForMonitorsSelectOption();
    Task<MonitorGet?> GetMonitorByIdAsync(Guid id);
}

public class HippocampuApiClient : HttpClient, IHippocampusApiClient
{
    public HippocampuApiClient(string hippocampusApiUrl)
    {
        this.BaseAddress = new Uri(hippocampusApiUrl);
    }

    public async Task<RecipientMonitorCreatedDto?> PostRecipientMonitorAsync(RecipientMonitorCreationForm form)
    {
        var response = await this.PostAsJsonAsync("RecipientMonitors/", form);
        if (!response.IsSuccessStatusCode)
            return null;
        return await response.Content.ReadFromJsonAsync<RecipientMonitorCreatedDto>();
    }

    public async Task<RecipientMonitorCreatedDto?> UpdateRecipientMonitorAsync(RecipientMonitorUpdateForm form)
    {
        var response = await this.PutAsJsonAsync("RecipientMonitors/", form);
        if (!response.IsSuccessStatusCode)
            return null;
        return await response.Content.ReadFromJsonAsync<RecipientMonitorCreatedDto>();
    }

    public async Task<IEnumerable<MonitorsTableRow>?> GetMonitorsForTable() =>
        await this.GetFromJsonAsync<IEnumerable<MonitorsTableRow>>("RecipientMonitors/list");

    public async Task<IEnumerable<MonitorsSelectOption>?> GetMonitorsForMonitorsSelectOption() =>
        await this.GetFromJsonAsync<IEnumerable<MonitorsSelectOption>>("RecipientMonitors/list");

    public async Task<MonitorGet?> GetMonitorByIdAsync(Guid id) =>
        await this.GetFromJsonAsync<MonitorGet>($"RecipientMonitors/{id}");
}