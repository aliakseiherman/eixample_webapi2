using System.Net.Http;

namespace eixample_webapi2.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetSubDomain(this HttpRequestMessage request)
        {
            string result = request.Headers.Referrer.GetSubDomain();
            return result;
        }
    }
}
