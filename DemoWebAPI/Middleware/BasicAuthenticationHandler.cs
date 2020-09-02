using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DemoWebAPI.Middleware
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))            
                return AuthenticateResult.Fail("This is not Authenticated");
            var SchemeName = "BasicAuthentication";
            var authHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var byteAuthCode = Convert.FromBase64String(authHeaderValue.Parameter);
            string[] authString = Encoding.UTF8.GetString(byteAuthCode).Split(":");
            var authId = authString[0];
            var authPassword = authString[1];
            if("netsession1".Equals(authId, StringComparison.CurrentCultureIgnoreCase) &&
                "winter!@".Equals(authPassword, StringComparison.CurrentCultureIgnoreCase))
            {
                Claim[] claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, authId)
                };

                var identity = new ClaimsIdentity(claims, SchemeName);
                var principle = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principle, SchemeName);
                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("This is not Authenticated");
        }
    }
}
