using System.Net.Http.Headers;

namespace CachedAPI.Models
{
    public class ResponseFormat
    {
        public HttpResponseHeaders? ResponseHeaders {  get; set; }
        public object? Response {  get; set; }
    }
}
