using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using Domain.Interfaces.Tools;

namespace Infrastructure
{
	public class Hashing : IHasher
	{
		private readonly string _encryptionKey;
		public Hashing(IConfiguration conf)
		{
			_encryptionKey = conf["EncryptionKey"].ToString();
		}

		public string Hash(string input)
		{
			string hashClaveUsuario;

			using (SHA256Managed sha256 = new SHA256Managed())
			{
				byte[] bytes = Encoding.UTF8.GetBytes(input);
				byte[] hash = sha256.ComputeHash(bytes);
				hashClaveUsuario = BitConverter.ToString(hash).Replace("-", "").ToLower();
			}

			return hashClaveUsuario;
		}
	}
}
