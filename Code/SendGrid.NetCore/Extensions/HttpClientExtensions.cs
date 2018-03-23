using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SendGrid.NetCore.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string endpoint, JObject data)
        {
            // TODO: JC: Untested solution to: Find new way to achieve this without dependency on Microsoft.AspNet.WebApi.Client
            // Taken from: https://stackoverflow.com/questions/40027299/where-is-postasjsonasync-method-in-asp-net-core
            var postRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

            var json = JsonConvert.SerializeObject(data);

            postRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var http = new HttpClient();
            return await http.SendAsync(postRequest);
        }
    }
}