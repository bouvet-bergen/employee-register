using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using EmployeeRegister.Core.Extensions;
using Newtonsoft.Json;

namespace EmployeeRegister.Core.Models
{
    public class WebClient
    {
        public const string BaseUrl = @"https://vindafor.azurewebsites.net/api";

        public async Task<T> GetAsync<T>(string relativeUrl, Dictionary<string, string> headers = null, Dictionary<string, string> queryParams = null) where T : class
        {
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.AddHttpHeaders(headers);

            var url = $"{BaseUrl}/{relativeUrl}";
            client.AddQueryParams(url, queryParams);

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new WebClientException($"{response.StatusCode} - {response.ReasonPhrase}");

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<T> GetStructAsync<T>(string relativeUrl, Dictionary<string, string> headers = null, Dictionary<string, string> queryParams = null) where T : struct
        {
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.AddHttpHeaders(headers);

            var url = $"{BaseUrl}/{relativeUrl}";
            client.AddQueryParams(url, queryParams);

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                throw new WebClientException($"{response.StatusCode} - {response.ReasonPhrase}");

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task PutAsync(string relativeUrl, Dictionary<string, string> headers = null, Dictionary<string, string> queryParams = null, HttpContent body = null)
        {
            var client = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.AddHttpHeaders(headers);

            var url = $"{BaseUrl}/{relativeUrl}";
            client.AddQueryParams(url, queryParams);

            var response = await client.PutAsync(url, body);
            if (!response.IsSuccessStatusCode)
                throw new WebClientException($"{response.StatusCode} - {response.ReasonPhrase}");

            await response.Content.ReadAsStringAsync();
        }
    }
}
