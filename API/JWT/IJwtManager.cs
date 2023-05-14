using System.Security.Claims;

namespace API.JWT
{
	public interface IJwtManager
	{
		public string GenerateToken(string userId);
		public ClaimsPrincipal GetPrincipalFromToken(string token);
	}
}
