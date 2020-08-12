using System.Collections.Generic;
using System.Net.Http;

namespace EmployeeRegister.Core.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHttpHeaders(this HttpClient client, Dictionary<string, string> headers)
        {
            if (headers == null || headers.Count <= 0)
                return;

            foreach (var (key, value) in headers)
            {
                client.DefaultRequestHeaders.Add(key.Trim(), value.Trim());
            }
        }

        public static string AddQueryParams(this HttpClient client, string url, Dictionary<string, string> queryParams)
        {
            if (queryParams == null || queryParams.Count <= 0)
                return url;

            var counter = 0;

            foreach (var (key, value) in queryParams)
            {
                if (counter == 0)
                    url += "?";

                url += $"{key}={value}&";
                counter++;
            }

            return url.Trim().TrimEnd('&');
        }
    }
}
