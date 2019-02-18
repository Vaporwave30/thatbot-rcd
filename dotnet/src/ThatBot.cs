using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThatBotLib
{
    public class ThatBot : IDisposable
    {
        public ThatBot(string ApiKey)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
        }

        public async Task<string> CreateTask(string scope)
        {
            var taskPostData = new { scope };

            using (var taskResult = await httpClient.PostAsync(EndPoints.CreateTask, taskPostData.AsJson()))
            {
                using (var taskResultContent = taskResult.Content)
                {
                    string taskReturnJson = await taskResultContent.ReadAsStringAsync();
                    Json.ReturnStatus taskReturnStatus = JsonConvert.DeserializeObject<Json.ReturnStatus>(taskReturnJson);
                    if (taskReturnStatus.status == "success")
                    {
                    Recheck:
                        await Task.Delay(TimeSpan.FromSeconds(15)); //threshold
                        var tokenPostData = new { taskReturnStatus.data.taskId };
                        var tokenResult = await httpClient.PostAsync(EndPoints.TaskResult, tokenPostData.AsJson());
                        using (var tokenResultContent = tokenResult.Content)
                        {
                            string tokenReturnJson = await tokenResultContent.ReadAsStringAsync();
                            Json.FcRoot tokenReturnStatus = JsonConvert.DeserializeObject<Json.FcRoot>(tokenReturnJson);

                            if (!tokenReturnStatus.data.ready)
                                goto Recheck;

                            if (tokenReturnStatus.status == "success")
                            {
                                return tokenReturnStatus.data.value;
                            }
                            else if (tokenReturnStatus.status == "error")
                            {
                                throw new Exception(tokenReturnStatus.data.message);
                            }
                        }
                    }
                    else if (taskReturnStatus.status == "error")
                    {
                        throw new Exception(taskReturnStatus.data.message);
                    }
                }
            }

            return null;
        }

        public async Task<(bool Success, string Cookie)> Login(string Username, string Password, string Token)
        {
            return await Requests.Roblox.RobloxLogin(Username, Password, Token);
        }

        public void Dispose() => httpClient.Dispose();

        private HttpClient httpClient;

        ~ThatBot() => httpClient.Dispose();
    }
}
