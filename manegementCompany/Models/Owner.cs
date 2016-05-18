using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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

		[Column("room")]
		public int room { get; set; }
	}
}

