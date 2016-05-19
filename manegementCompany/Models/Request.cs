using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
	[Table("request")]
	public class DBRequest
	{
		public DBRequest ()
		{
		}

		[Column("id")]
		public int id { set; get; }

		[Column("owner")]
		public int owner { set; get; }

		[Column("organization")]
		public int organization { set; get; }

		[Column("service")]
		public int service { set; get; }

		[Column("number")]
		public string number { set; get; }
	}

	public class MRequest
	{
		public MRequest(){
		}

		public MRequest(DBRequest request, string o, string s)
		{
			id = request.id;
			organization = request.organization;
			owner = request.owner;
			ownerName = o;
			service = request.service;
			serviceName = s;
			number = request.number;
		}

		public int id { set; get; }

		public int organization { set; get; }

		public int owner { set; get; }

		public string ownerName { set; get; }

		public int service { set; get; }

		public string serviceName { set; get; }

		public string number { set; get; }	
	}
}

