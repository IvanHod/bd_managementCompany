using System;
using System.Data.Entity;
using System.Data.Common;
using web.Models;

namespace web.ContextDbs
{
	public class AddressContext : DbContext
	{
		public AddressContext () : base("company")
		{
		}

		public AddressContext(DbConnection existingConnection, bool contextOwnsConnections) 
			: base(existingConnection, contextOwnsConnections) {

		}

		public DbSet <Region> Regions { get; set; }

		public DbSet <City> Cities { get; set; }
	}
}

