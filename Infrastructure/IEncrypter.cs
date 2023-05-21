using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	public interface IEncrypter
	{
		public string Encrypt(string input);
		public string Decrypt(string input);
	}
}
