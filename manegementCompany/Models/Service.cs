﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
	[Table("service")]
	public class Service
	{
		public Service ()
		{
		}

		public void editS(Service s)
		{
			name = s.name;
			description = s.description;
			price = s.price;
			period = s.period;
		}

		[Column("id")]
		public int id { get; set; }

		[Column("name")]
		public string name { get; set; }

		[Column("description")]
		public string description { get; set; }

		[Column("price")]
		public int price { get; set; }

		[Column("isGeneral")]
		public bool isGeneral { get; set; }

		[Column("period")]
		public int period { get; set; }
	}
}

