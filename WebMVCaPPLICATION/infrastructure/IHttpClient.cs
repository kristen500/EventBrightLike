namespace WebMVCaPPLICATION.infrastructure
{
    public interface IHttpClient
    {
       Task<string> GetStringAsync(string uri, 
           string authorizationToken = null, string authorizationMethod = "Bearer");

       Task<HttpResponseMessage> PostASync<T>(string uri, T item, 
           string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PutASync<T>(string uri, T item,
           string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> DeleteASync(string uri,
          string authorizationToken = null, string authorizationMethod = "Bearer");


    }

}
