using Domain.FileLog;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Provider
    {
        static string ApiEndPoint = "https://localhost:44335/";
        public static Task<dynamic> GetAsync(string uri, dynamic body = null, string token = "")
        {
            dynamic resultAPI = null;
            uri = ApiEndPoint + uri;
            try
            {
                Uri urlapi = new Uri(uri);
                using (var wc = new HttpClient())
                {
                    wc.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var modelString = JsonConvert.SerializeObject(body);
                    var content = new StringContent(modelString, Encoding.UTF8, "application/json");
                    var jsonResult = wc.PostAsync($@"{urlapi}", content).Result.Content.ReadAsStringAsync().Result;
                    resultAPI = JsonConvert.DeserializeObject<dynamic>(jsonResult);
                }
            }
            catch (Exception ex)
            {
                FileHelper.GeneratorFileByDay(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                return null;
            }
            return resultAPI;
        }
    }
}
