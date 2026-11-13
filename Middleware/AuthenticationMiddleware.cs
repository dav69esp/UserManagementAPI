using System.Net.Http.Headers;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        private const string ValidToken =
            "TechHiveSecureToken123";

        public AuthenticationMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(
                "Authorization",
                out var authorizationHeader))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync(
                    "Unauthorized");

                return;
            }

            if (!AuthenticationHeaderValue.TryParse(
                    authorizationHeader,
                    out var authorization)
                || !string.Equals(
                    authorization.Scheme,
                    "Bearer",
                    StringComparison.OrdinalIgnoreCase)
                || !string.Equals(
                    authorization.Parameter,
                    ValidToken,
                    StringComparison.Ordinal))
            {
                context.Response.StatusCode = 401;

                await context.Response.WriteAsync(
                    "Unauthorized");

                return;
            }

            await _next(context);
        }
    }
}