using System;
using System.Data.Entity;
using System.Data.Common;
using web.Models;

namespace web.ContextDbs
{
	public class OwnerContext : DbContext
	{
		public OwnerContext () : base("company")
		{
		}

		public OwnerContext(DbConnection existingConnection, bool contextOwnsConnections) 
			: base(existingConnection, contextOwnsConnections) {

		}

		public DbSet <Owner> owners { get; set; }
	}
}

