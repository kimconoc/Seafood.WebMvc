using Domain.FileLog;
using Newtonsoft.Json;
using System;
using Domain.Models.BaseModel;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.ResponseModel;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Service.ServiceProvider
{
    public class Provider : IProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly string ApiEndPoint;

        public Provider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
            ApiEndPoint = ConfigurationManager.AppSettings["ApiEndPoint"];
        }
        public Task<ResponseBase<TResult>> GetAsync<TResult>(string uri, string token = "")
        {
            uri = ApiEndPoint + uri;
            try
            {
                Uri urlapi = new Uri(uri);
                using (var wc = new HttpClient())
                {
                    wc.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var jsonResult = wc.GetAsync($@"{urlapi}").Result.Content.ReadAsStringAsync().Result;
                    return Task.Run(() => JsonConvert.DeserializeObject<ResponseBase<TResult>>(jsonResult, _serializerSettings));
                }
            }
            catch (Exception ex)
            {
                FileHelper.GeneratorFileByDay(ex.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            return default;
        }
        public Task<ResponseBase<TResult>> PostAsync<TResult>(string uri, dynamic fromBody, string token = "")
        {
            uri = ApiEndPoint + uri;
            try
            {
                Uri urlapi = new Uri(uri);
                using (var wc = new HttpClient())
                {
                    wc.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var modelString = JsonConvert.SerializeObject(fromBody);
                    var content = new StringContent(modelString, Encoding.UTF8, "application/json");
                    var jsonResult = wc.PostAsync($@"{urlapi}", content).Result.Content.ReadAsStringAsync().Result;
                    return Task.Run(() => JsonConvert.DeserializeObject<ResponseBase<TResult>>(jsonResult, _serializerSettings));
                }
            }
            catch (Exception ex)
            {
                FileHelper.GeneratorFileByDay(ex.ToString(), MethodBase.GetCurrentMethod().Name);
            }
            return default;
        }
    }
}
