using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThatBotLib.Requests
{
    public static class Roblox
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<(bool Success, string Cookie)> RobloxLogin(string username, string pass, string Token)
        {
            httpClient.DefaultRequestHeaders.Add("X-CSRF-TOKEN", GetXSRFToken());

            var postData = new { credentialsValue = username, fcToken = Token };

            var result = await httpClient.PostAsync(EndPoints.FcLogin, postData.AsJson());
            string resultContent = await result.Content.ReadAsStringAsync();

            if (resultContent != "{}") return (false, String.Empty);

            var loginPostData = new { ctype = "Username", cvalue = username, password = pass };
            var loginResult = await httpClient.PostAsync(EndPoints.Login, loginPostData.AsJson());
            string loginResultContent = await loginResult.Content.ReadAsStringAsync();

            IEnumerable<string> cookieHeader;

            loginResult.Headers.TryGetValues("Set-Cookie", out cookieHeader);
            if (cookieHeader != null)
            {
                foreach (var item in cookieHeader)
                {
                    if (item.Contains(".ROBLO"))
                    {
                        return (true, item);
                    }
                }

            }
            return (false, String.Empty);
        }

        private static string GetXSRFToken()
        {
            using (HttpResponseMessage response = httpClient.GetAsync("https://www.roblox.com/").Result)
            {
                using (HttpContent content = response.Content)
                {
                    return Parse("Roblox.XsrfToken.setToken('", "');", content.ReadAsStringAsync().Result);
                }
            }
        }

        private static string Parse(string bDelimiter, string eDelimter, string fString)
        {
            int beginIndex = fString.IndexOf(bDelimiter) + bDelimiter.Length;
            int endIndex = fString.IndexOf(eDelimter, beginIndex);

            return fString.Substring(beginIndex, endIndex - beginIndex);
        }
    }
}
