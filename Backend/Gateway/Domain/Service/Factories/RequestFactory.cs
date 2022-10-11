using ECommerceUserAPI;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text;


namespace ECommerceAPIGateway.Domain.Service.Factories
{
    public class RequestFactory
    {
        private readonly IConfiguration _configuration;
        public RequestFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private HttpMethod GetRequestMethod(string method)
        {
            switch (method)
            {
                case "GET":
                    return HttpMethod.Get;
                case "POST":
                    return HttpMethod.Post;
                case "PUT":
                    return HttpMethod.Put;
                case "DELETE":
                    return HttpMethod.Delete;
            }
            return HttpMethod.Get;
        }

        public async Task<string> SendRequest(string serviceName, string endpointName, dynamic? body, string method)
        {
            string url = _configuration[$"Services:{serviceName}:Url"];
            string endpoint = _configuration[$"Services:{serviceName}:{endpointName}"];
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add(_configuration["HeaderSecret"], "");
            client.BaseAddress = new Uri(url);
            HttpRequestMessage request = new HttpRequestMessage(GetRequestMethod(method), endpoint);

            if (method == "POST" || method == "PUT")
            {
                string json = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<dynamic>(body.ToString()));
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }         

            HttpResponseMessage response = await client.SendAsync(request);

            //if (!response.IsSuccessStatusCode)
            //        throw new ArgumentException($"Error in service: {serviceName},\nendpoint: {endpointName}.");

            string jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
    }
}
