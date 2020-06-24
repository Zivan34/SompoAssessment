using BussinessObjects.GlobalClasses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace SompoAssessment.Helpers
{
    public class API
    {


        //For security create a custom Deserialization Settings wich will set Type Name Handling to none. This will be used in all deserializations.
        private static JsonSerializerSettings DeserializationSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.None
    };
        private class ExceptionObject
        {
            public string ExceptionMessage;
        }

        public static ApiResponse<TResponse> Post<TResponse, TRequest>(string url, TRequest request)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.UseDefaultCredentials = true;
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            httpWebRequest.ContentType = "application/json; charset=UFT-8";
            httpWebRequest.ReadWriteTimeout = 60000;
            httpWebRequest.Timeout = 60000;
            try
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = JsonConvert.SerializeObject(request);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    httpWebRequest.Abort();
                    TResponse responseData = JsonConvert.DeserializeObject<TResponse>(result, DeserializationSettings);
                    ApiResponse<TResponse> response = new ApiResponse<TResponse>();
                    response.Data = responseData;
                    response.Success("Success");
                    return response;
                }
            }
            catch (WebException ex)
            {
                using (WebResponse response = (WebResponse)ex.Response)
                {
                    HttpWebResponse webResponse = (HttpWebResponse)response;
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var resultError = streamReader.ReadToEnd();
                        httpWebRequest.Abort();
                        return new ApiResponse<TResponse>()
                        {
                            Message = JsonConvert.DeserializeObject<ExceptionObject>(resultError).ExceptionMessage
                        };
                    }
                }
            }
        }
    }
}