using RestSharp;
using System.Threading.Tasks;
using Newtonsoft.Json;
using bleaf_test_automation.Utils;

namespace bleaf_test_automation.API
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient()
        {
            _client = new RestClient(ConfigManager.GetConfigValue("ApiUrl"));
        }

        public async Task<RestResponse> SendAsync(Method method, string endpoint, object payload = null)
        {
            var request = new RestRequest(endpoint, method);
            if (payload != null)
            {
                request.AddJsonBody(JsonConvert.SerializeObject(payload));
            }
            return await _client.ExecuteAsync(request);
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await SendAsync(Method.Get, endpoint);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task<T> PostAsync<T>(string endpoint, object payload)
        {
            var response = await SendAsync(Method.Post, endpoint, payload);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task<T> PutAsync<T>(string endpoint, object payload)
        {
            var response = await SendAsync(Method.Put, endpoint, payload);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public async Task DeleteAsync(string endpoint)
        {
            await SendAsync(Method.Delete, endpoint);
        }
    }
}