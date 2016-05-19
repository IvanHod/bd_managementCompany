using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
	[Table("owner")]
	public class Owner
	{
		public Owner ()
		{
		}

		public Owner (int r)
		{
			room = r;
		}

		public Owner(MOwner own) {
			id = own.id;
			name = own.name;
			lastName = own.lastName;
			patronimic = own.patronimic;
			phone = own.phone;
			email = own.email;
			password = own.password;
			if( own.services != null)
				services = string.Join(",",own.services);
			room = own.room;
		}

		[Column("id")]
		public int id { get; set; }

		[Column("name")]
		public string name { get; set; }

		[Column("last_name")]
		public string lastName { get; set; }

		[Column("patronimic")]
		public string patronimic { get; set; }

		[Column("phone")]
		public string phone { get; set; }

		[Column("email")]
		public string email { get; set; }

		[Column("hashPassword")]
		public string password { get; set; }

		[Column("services")]
		public string services { get; set; }

		[Column("services_pay")]
		public string servicesPay { get; set; }

		[Column("room")]
		public int room { get; set; }
	}

	public class MOwner {

		public MOwner () {}

		public MOwner (int r)
		{
			room = r;
		}

		public int id { get; set; }

		[Required]
		public string name { get; set; }

		[Required]
		public string lastName { get; set; }

		[Required]
		public string patronimic { get; set; }

		[Required]
		public string phone { get; set; }

		[Required]
		public string email { get; set; }

		[Required]
		public string password { get; set; }

		public List<string> services { get; set; }

		[Required]
		public int room { get; set; }
	}
}

