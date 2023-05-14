using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace API.AuthFilter 
{ 
	public class AuthenticationFilter : ActionFilterAttribute
	{
		private readonly string _allowedRole;
		private string _encryptionKey;

		public AuthenticationFilter(string allowedRole)
		{
			_allowedRole = allowedRole;	
		}

		private string DecryptToken(string encryptedToken)
		{
			byte[] encryptedBytes = Convert.FromBase64String(encryptedToken);
			byte[] keyBytes = Encoding.UTF8.GetBytes(_encryptionKey);

			string decryptedToken;

			using (var aes = Aes.Create())
			{
				aes.Key = keyBytes;
				aes.Mode = CipherMode.ECB;
				aes.Padding = PaddingMode.PKCS7;

				using (var decryptor = aes.CreateDecryptor())
				{
					byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
					decryptedToken = Encoding.UTF8.GetString(decryptedBytes);
				}
			}

			return decryptedToken;
		}

		private bool HasValidRole(string decryptedToken) { 
			Usuario usuario = JsonConvert.DeserializeObject<Usuario>(decryptedToken);
			return usuario.Role.Nombre.ToLower() == _allowedRole;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var conf = context.HttpContext.RequestServices.GetService<IConfiguration>();
			this._encryptionKey = conf["EncryptionKey"].ToString();

			var headers = context.HttpContext.Request.Headers;

			if (!headers.ContainsKey("token-x"))
			{
				context.Result = new UnauthorizedResult();
				return;
			}

			string encryptedToken = headers["token-x"];
			//string decryptedToken = DecryptToken(encryptedToken);
			string decryptedToken = encryptedToken;

			if (!HasValidRole(decryptedToken))
			{
				context.Result = new UnauthorizedResult();
				return;
			}
		}
	}


}
