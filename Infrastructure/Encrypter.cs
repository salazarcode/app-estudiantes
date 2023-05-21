using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure
{
	public class Encrypter : IEncrypter
	{
		private readonly string _key;
		public Encrypter(IConfiguration conf)
		{
			_key = conf["EncryptionKey"].ToString();

		}
		public string Decrypt(string encryptedInput)
		{
			byte[] ivAndEncryptedBytes = Convert.FromBase64String(encryptedInput);

			using (var aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(_key);

				byte[] iv = new byte[aes.IV.Length];
				byte[] encryptedBytes = new byte[ivAndEncryptedBytes.Length - aes.IV.Length];

				Array.Copy(ivAndEncryptedBytes, 0, iv, 0, iv.Length);
				Array.Copy(ivAndEncryptedBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

				aes.IV = iv;

				using (var decryptor = aes.CreateDecryptor())
				{
					byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
					string decryptedValue = Encoding.UTF8.GetString(decryptedBytes);
					return decryptedValue;
				}
			}
		}

		public string Encrypt(string input)
		{
			using (var aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(_key);
				aes.GenerateIV(); // Generar un nuevo vector de inicialización (IV) para cada encriptación

				byte[] valueBytes = Encoding.UTF8.GetBytes(input);

				using (var encryptor = aes.CreateEncryptor())
				{
					byte[] encryptedBytes = encryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);

					// Concatenar IV y datos encriptados
					byte[] ivAndEncryptedBytes = new byte[aes.IV.Length + encryptedBytes.Length];
					Array.Copy(aes.IV, 0, ivAndEncryptedBytes, 0, aes.IV.Length);
					Array.Copy(encryptedBytes, 0, ivAndEncryptedBytes, aes.IV.Length, encryptedBytes.Length);

					string encryptedValue = Convert.ToBase64String(ivAndEncryptedBytes);
					return encryptedValue;
				}
			}
		}
	}
}
