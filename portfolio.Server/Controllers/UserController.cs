using Microsoft.Extensions.Configuration;

namespace portfolio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        private readonly IConfiguration _config;

        public UserController(UserService userServices, IConfiguration config)
        {
            _service = userServices;
            _config = config;
        }

        //Token create
        [HttpGet]
        public string Get(string userName, string password)
        {
            var claims = new[]{
                new Claim(ClaimTypes.Name,userName),
                new Claim(JwtRegisteredClaimNames.Email,userName)
            };
            var signinKey = _config.GetValue<string>("JwtSettings:SigninKey");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
              issuer: _config.GetValue<string>("JwtSettings:Issuer"),
              audience: _config.GetValue<string>("JwtSettings:Audience"),
              claims: claims,
              expires: DateTime.Now.AddDays(15),
              notBefore: DateTime.Now,
              signingCredentials: credentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }

        [HttpGet("ValidateToken")]
        public bool Validatetoken(string token)
        {
            var signinKey = _config.GetValue<string>("JwtSettings:SigninKey");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey));
            try
            {
                JwtSecurityTokenHandler handler = new();
                handler.ValidateToken(token,new TokenValidationParameters(){
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false
                },out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
