using System;
using System.Data.Entity;
using System.Data.Common;
using web.Models;

namespace web.ContextDbs
{
	public class HouseContext : DbContext
	{
		public HouseContext () : base("company")
		{
		}
			
		public HouseContext(DbConnection existingConnection, bool contextOwnsConnections) 
			: base(existingConnection, contextOwnsConnections) {

		}

		public DbSet <House> houses { get; set; }

		public DbSet <Room> rooms { get; set; }
	}
}

