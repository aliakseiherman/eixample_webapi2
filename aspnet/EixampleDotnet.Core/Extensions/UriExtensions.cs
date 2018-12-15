using EixampleDotnet.Consts;
using System;
using System.Linq;

namespace EixampleDotnet.Extensions
{
    public static class UriExtensions
    {
        public static string GetSubDomain(this Uri url)
        {
            var parts = url.Host.Split('.').ToList();

            if (parts.Any())
            {
                if (!parts.First().Equals(AppConsts.Host))
                {
                    return parts.First();
                }
            }

            return null;
        }
    }
}
