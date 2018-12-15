using System.Net.Http;

namespace EixampleDotnet.Extensions
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
