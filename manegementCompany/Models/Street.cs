using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
	[Table("street")]
	public class Street
	{
		public Street ()
		{
		}
			
		[Column("id")]
		public int id { get; set; }

		[Column("name")]
		public string name { get; set; }

		[Column("house")]
		public string house { get; set; }
	}
}

