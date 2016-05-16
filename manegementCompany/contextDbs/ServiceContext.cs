using System;
using System.Data.Entity;
using System.Data.Common;
using web.Models;

namespace web.ContextDbs
{
	public class ServiceContext : DbContext
	{
		public ServiceContext () : base("company")
		{
		}

		public ServiceContext(DbConnection existingConnection, bool contextOwnsConnections) 
			: base(existingConnection, contextOwnsConnections) {

		}

		public DbSet <Service> Services { get; set; }
	}
}

