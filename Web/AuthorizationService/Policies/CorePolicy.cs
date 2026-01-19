using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace AuthorizationService.Policies
{
    public class CorePolicy : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;
        public CorePolicy()
        {
            _policy = new CorsPolicy()
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
            };

            _policy.Origins.Add("http://localhost:4200");
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult<CorsPolicy>(_policy);
        }
    }
}
