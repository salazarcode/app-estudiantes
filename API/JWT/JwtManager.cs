using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API.JWT
{
    public class JwtManager : IJwtManager
	{
		private readonly JwtConfig _jwtConfig;

		public JwtManager(IConfiguration conf)
		{
			_jwtConfig = new JwtConfig();
		}

		public string GenerateToken(string userId)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
			    {
				 new Claim(ClaimTypes.NameIdentifier, userId)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.ExpirationMinutes),
				Issuer = _jwtConfig.Issuer,
				Audience = _jwtConfig.Audience,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public ClaimsPrincipal GetPrincipalFromToken(string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = _jwtConfig.Issuer,
				ValidAudience = _jwtConfig.Audience,
				ClockSkew = TimeSpan.Zero
			};

			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
			return principal;
		}
	}

}