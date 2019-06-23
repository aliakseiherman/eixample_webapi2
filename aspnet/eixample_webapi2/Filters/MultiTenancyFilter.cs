using Autofac.Integration.WebApi;
using eixample_webapi2.Application;
using eixample_webapi2.Consts;
using eixample_webapi2.EntityFramework;
using eixample_webapi2.Extensions;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace eixample_webapi2.Filters
{
    public class MultiTenancyFilter : IAutofacActionFilter
    {
        public Session Session { get; set; }
        public AppDbContext DbContext { get; set; }
        public ITenantService TenantService { get; set; }

        public Task OnActionExecutingAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken
            )
        {
            string subdomain = actionContext.Request.GetSubDomain();

            string userId = null;
            int? tenantId = null;

            var claimsIdentity = actionContext.RequestContext.Principal as ClaimsPrincipal;

            var userIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }

            var tenantIdClaim = claimsIdentity.Claims.SingleOrDefault(c => c.Type == CustomClaims.TenantId);
            if (tenantIdClaim != null)
            {
                tenantId = !string.IsNullOrEmpty(tenantIdClaim.Value) ? int.Parse(tenantIdClaim.Value) : (int?)null; // fetching from Claim for maximum performance
            }
            else
            {
                tenantId = TenantService.GetBySubdomain(subdomain); // making db call when Claim is missing
            }

            DbContext.UserId = userId;
            DbContext.TenantId = tenantId;

            Session.UserId = userId;
            Session.TenantId = tenantId;
            Session.Subdomain = subdomain;

            return Task.FromResult(0);
        }

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}