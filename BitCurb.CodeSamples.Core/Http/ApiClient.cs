using BitCurb.CodeSamples.Core.Http.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BitCurb.CodeSamples.Core.Http
{
    public class ApiClient
    {
        private readonly string BITCURB_API_URL = ConfigurationManager.AppSettings["BitCurb_API_Url"];
        private string oauth_token;

        public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, string endpoint)
            where TRequest : IApiRequest
            where TResponse : IApiResponse
        {
            if (string.IsNullOrWhiteSpace(this.oauth_token))
            {
                this.oauth_token = await GetTokenAsync();
            }

            using (HttpClient apiClient = new HttpClient())
            {
                apiClient.BaseAddress = new Uri(BITCURB_API_URL, UriKind.Absolute);
                apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.oauth_token);

                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                string url = BITCURB_API_URL + endpoint;
                string json = JsonConvert.SerializeObject(request, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await apiClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<TResponse>(responseText);
                }

                return default(TResponse);
            }
        }

        public async Task<TResponse> SendAsyncGet<TResponse>(string endpoint)
        {
            if (string.IsNullOrWhiteSpace(this.oauth_token))
            {
                this.oauth_token = await GetTokenAsync();
            }

            using (HttpClient apiClient = new HttpClient())
            {
                apiClient.BaseAddress = new Uri(BITCURB_API_URL, UriKind.Absolute);
                apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.oauth_token);
                apiClient.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                string url = BITCURB_API_URL + endpoint;
                

                HttpResponseMessage response = await apiClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();
                   
                    return JsonConvert.DeserializeObject<TResponse>(responseText);
                }

                return default(TResponse);
            }

        }

        private async Task<string> GetTokenAsync()
        {
            using (HttpClient apiClient = new HttpClient())
            {
                apiClient.BaseAddress = new Uri(BITCURB_API_URL, UriKind.Absolute);

                string url = BITCURB_API_URL + "/token";

                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                list.Add(new KeyValuePair<string, string>("client_id", ConfigurationManager.AppSettings["api_clientKey"].ToString()));
                list.Add(new KeyValuePair<string, string>("client_secret", ConfigurationManager.AppSettings["api_clientSecret"].ToString()));
                list.Add(new KeyValuePair<string, string>("username", ConfigurationManager.AppSettings["BitCurb_username"].ToString()));
                list.Add(new KeyValuePair<string, string>("password", ConfigurationManager.AppSettings["BitCurb_password"].ToString()));
                list.Add(new KeyValuePair<string, string>("grant_type", "password"));

                var content = new FormUrlEncodedContent(list);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                HttpResponseMessage response = await apiClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseText = await response.Content.ReadAsStringAsync();

                    TokenResponse tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseText);
                    return tokenResponse.AccessToken;
                }

                return null;
            }
        }
    }
}
