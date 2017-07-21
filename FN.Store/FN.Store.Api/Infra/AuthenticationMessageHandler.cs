using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace FN.Store.Api.Infra
{
    public class AuthenticationMessageHandler : DelegatingHandler
    {
        public AuthenticationMessageHandler(HttpConfiguration httpConfig)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfig);
        }

        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            if (request.Headers.Authorization != null &&
                request.Headers.Authorization.Scheme == "Basic")
            {
                var encode = request.Headers.Authorization.Parameter.Trim();
                var user = Encoding.Default.GetString(Convert.FromBase64String(encode));
                var data = user.Split(":".ToCharArray());
                var username = data[0];
                var pass = data[1];

                if (!(username == "admin" && pass == "123456"))
                {
                    response = request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                    return response;
                }
            }
            else {
                response = request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                return response;
            }
            response = await base.SendAsync(request, cancellationToken);
            response.Headers.Add("WWW-Authenticate", "Basic");
            return response;

        }
    }
}