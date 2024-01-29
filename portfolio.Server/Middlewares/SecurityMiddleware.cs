namespace portfolio.Server.Middlewares
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;

        public SecurityMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Enable CORS
            context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Append("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
            context.Response.Headers.Append("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");

            // JWT Authorization
            if (!string.IsNullOrEmpty(context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last()))
            {
                var signinKey = _config.GetValue<string>("JwtSettings:SigninKey");

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config.GetValue<string>("JwtSettings:Issuer"),
                    ValidAudience = _config.GetValue<string>("JwtSettings:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey))
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                try
                {
                    var principal = tokenHandler.ValidateToken(context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(), tokenValidationParameters, out SecurityToken validatedToken);
                    context.User = principal;
                }
                catch (Exception)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }
            }

            context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
            context.Response.Headers.Append("X-Xss-Protection", "1; mode=block");
            context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'");

            context.Response.Headers.Append("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
            context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");
            context.Response.Headers.Append("Feature-Policy", "geolocation 'none'; midi 'none'; sync-xhr 'none'");

            context.Response.Headers.Remove("Server");

            await _next(context);
        }
    }
}
