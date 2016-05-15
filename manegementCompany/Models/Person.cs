using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
	[Table("user")]
	public class Person
	{
		public Person ()
		{
		}

		[Column("id")]
		public int id { get; set; }

		[Column("first_name")]
		public string firstName { get; set; }

		[Column("second_name")]
		public string secondName { get; set; }
	}
}

