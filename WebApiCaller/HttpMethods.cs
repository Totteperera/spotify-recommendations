using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApiCaller
{
    public class HttpMethods
    {
        public async Task<T> GetAsync<T>(string url)
        {
            var client = new HttpClient();
            var test = await client.GetAsync(url);
            var content = await test.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}