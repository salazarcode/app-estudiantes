using Domain.Entities;
using Infrastructure;
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

		private bool HasValidRole(string decryptedToken) { 
			Usuario usuario = JsonConvert.DeserializeObject<Usuario>(decryptedToken);
			return usuario.Role.Nombre.ToLower() == _allowedRole;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var conf = context.HttpContext.RequestServices.GetService<IConfiguration>();
			var encrypter = context.HttpContext.RequestServices.GetService<IEncrypter>();

			var headers = context.HttpContext.Request.Headers;

			if (!headers.ContainsKey("token-x"))
			{
				context.Result = new UnauthorizedResult();
				return;
			}

			string encryptedToken = headers["token-x"];
			string decryptedToken = encrypter.Decrypt(encryptedToken);

			if (!HasValidRole(decryptedToken))
			{
				context.Result = new UnauthorizedResult();
				return;
			}
		}
	}


}
