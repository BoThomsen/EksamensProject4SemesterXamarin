using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PlantProject.Services
{
     class ConMiddleware
    {

        //ip with my phone and computer
       // public static string serverUrl = "http://172.20.10.3:3000/api/";
        public static string serverUrl = "http://192.168.87.143:3000/api/";

        public static HttpClient client;

        public static async Task<HttpResponseMessage> GetDatalogger()
        {
            try
            {
                // creating http client
                client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //getting httpresponse
                HttpResponseMessage response = await client.GetAsync(serverUrl + "datalogger");
                response.EnsureSuccessStatusCode();

                Console.WriteLine(response);
                return response;

            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage();
            }
        }


        public static async Task<HttpResponseMessage> GetPlants()
        {
            try
            {
                // creating http client
                client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //getting httpresponse
                HttpResponseMessage response = await client.GetAsync(serverUrl + "plants");
                response.EnsureSuccessStatusCode();

                Console.WriteLine(response);
                return response;

            }
            catch (HttpRequestException)
            {
                return new HttpResponseMessage();
            }
        }




    }
}
