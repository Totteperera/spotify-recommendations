using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyClientCaller.Models;

namespace SpotifyClientCaller
{
    internal class HttpMethods
    {
        private readonly ApiUrlBuilder _apiUrlBuilder;
        private const string JsonContentType = "application/json";
        private AccessTokenModel _accessTokenModel;
        private HttpClient _client;

        public HttpMethods(ApiUrlBuilder apiUrlBuilder)
        {
            _apiUrlBuilder = apiUrlBuilder;
        }

        private HttpClient HttpClient => _client ?? (_client = GetClient());

        private AccessTokenModel AccessTokenModel => _accessTokenModel ?? (_accessTokenModel = Task.Run(GetAccessToken).Result);

        private static HttpClient GetClient()
        {
            var client = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 2, 0)
            };

            return client;
        }

        private async Task<AccessTokenModel> GetAccessToken()
        {
            var postParameters = new Dictionary<string, string> { { "grant_type", "client_credentials" } };
            var requestUri = _apiUrlBuilder.GetAccessTokenUrl();
            return await PostAsync<AccessTokenModel>(requestUri, postParameters);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AccessTokenModel.TokenType, AccessTokenModel.AccessToken);
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
            var response = await HttpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> PostAsync<T>(string url, Dictionary<string, string> postParameters)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{UserData.ClientId}:{UserData.ClientSecret}");
            var base64 = Convert.ToBase64String(plainTextBytes);
            HttpClient.DefaultRequestHeaders.Clear();
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64);
            var encodedContent = new FormUrlEncodedContent(postParameters);
            var response = await HttpClient.PostAsync(url, encodedContent);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}