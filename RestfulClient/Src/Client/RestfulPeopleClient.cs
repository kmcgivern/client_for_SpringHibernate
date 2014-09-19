using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using RestfulClient.DTO;

namespace RestfulClient.Client
{
    public class RestfulPeopleClient : PeopleClient
    {
        static string uri = "http://localhost:9000/people";
        static string uri_all = uri+ "/all";

        static string HTTP_POST_VERB = "POST";
        static string JSON_CONTENT_TYPE = "application/json";

        public string GetPerson(long id)
        {
            string result = "";
            string uriToInvoke = uri + "?Id=" + id;
            result = GetFromService(uriToInvoke);
            return result;
        }

        public string GetAllPeople()
        {
            string result = "";
            result = GetFromService(uri_all);
            return result;
        }

        public string CreatePerson(string json)
        {
            var httpWebRequest = CreateHttpWebRequest(uri);
            SetPostContent(httpWebRequest);

            return CreatePerson(json, httpWebRequest);
        }

        private string GetFromService(string uri)
        {
            string result = "";
            using (WebClient client = new WebClient())
            {
                result = client.DownloadString(uri);
            }
            return result;
        }

        private string CreatePerson(string json, HttpWebRequest httpWebRequest)
        {
            string response = "";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                response = GetResponseStream(httpResponse);
            }
            return response;
        }

        private string GetResponseStream(HttpWebResponse httpResponse)
        {
            string response;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            return response;
        }

        private HttpWebRequest CreateHttpWebRequest(string uriToInvoke)
        {
            return WebRequest.Create(uriToInvoke) as HttpWebRequest;
        }

        private void SetPostContent(HttpWebRequest httpWebRequest)
        {
            httpWebRequest.ContentType = JSON_CONTENT_TYPE;
            httpWebRequest.Method = HTTP_POST_VERB;
        }



       
    }
}
