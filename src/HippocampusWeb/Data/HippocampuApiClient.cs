using System.Net.Http.Json;
using HippocampusWeb.Diplomat.HttpIn;
using HippocampusWeb.Values;
using HippocampusWeb.Values.Forms;

namespace HippocampusWeb.Data;

public interface IHippocampusApiClient
{
    Task<RecipientMonitorCreatedDto?> PostRecipientMonitorAsync(RecipientMonitorCreationForm form);
    Task<IEnumerable<MonitorsTableRow>?> GetMonitorsForTable();
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

    public async Task<IEnumerable<MonitorsTableRow>?> GetMonitorsForTable() =>
        await this.GetFromJsonAsync<IEnumerable<MonitorsTableRow>>("RecipientMonitors/list");
}