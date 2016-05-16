using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using web.ContextDbs; 

namespace web.Models
{
	[Table("organization")]
	public class Organization
	{
		public Organization ()
		{
		}

		[Column("id")]
		public int id { get; set; }

		[Column("full_name")]
		public string fullName { get; set; }

		[Column("name")]
		public string name { get; set; }

		[Column("legal_address")]
		public int legalAddress { get; set; }

		[Column("address")]
		public int address { get; set; }

		[Column("OGRN")]
		public string OGRN { get; set; }

		[Column("INN")]
		public string INN { get; set; }

		[Column("KPP")]
		public string KPP { get; set; }

		[Column("OKTMO")]
		public string OKTMO { get; set; }

		[Column("phone")]
		public string phone { get; set; }

		[Column("email")]
		public string email { get; set; }

		[Column("psw")]
		public string password { get; set; }

		string GetHashString(string s)  
		{  
			//переводим строку в байт-массим  
			byte[] bytes = Encoding.Unicode.GetBytes(s);  

			//создаем объект для получения средст шифрования  
			MD5CryptoServiceProvider CSP =  
				new MD5CryptoServiceProvider();  

			//вычисляем хеш-представление в байтах  
			byte[] byteHash = CSP.ComputeHash(bytes);  

			string hash = string.Empty;  

			//формируем одну цельную строку из массива  
			foreach (byte b in byteHash)  
				hash += string.Format("{0:x2}", b);  

			return hash;  
		}  
	}
}

