using System.Net.Http.Json;
using HippocampusWeb.Diplomat.HttpIn;
using HippocampusWeb.Values.Forms;

namespace HippocampusWeb.Data;

public interface IHippocampusApiClient
{
    Task<RecipientMonitorCreatedDto?> PostRecipientMonitorAsync(RecipientMonitorCreationForm form);
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
        return await response.Content.ReadFromJsonAsync<RecipientMonitorCreatedDto>();
    }

    // public async Task<>
}