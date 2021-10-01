using CachedAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CachedAPI.Controllers
{
    [ApiController]
    [Route("github")]
    public class GithubController : ControllerBase
    {
        public GithubController() { }

        [HttpGet]
        public async Task<ResponseFormat> GetAsync()
        {
            string ApiString;
            using (StreamReader stream = new(Request.Body))
            {
                ApiString = await stream.ReadToEndAsync();
            }
            HttpClient client = new()
            {
                BaseAddress = new Uri("https://api.github.com/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "none");
            HttpResponseMessage response = client.GetAsync(ApiString).Result;

            return new ResponseFormat()
            {
                Response = JsonSerializer.Deserialize<object>(response.Content.ReadAsStringAsync().Result),
                ResponseHeaders = response.Headers
            };
        }
    }
}
