using System;
using System.Data.Entity;
using System.Data.Common;
using web.Models;

namespace web.ContextDbs
{
	public class PeopleContext : DbContext
	{
		public PeopleContext () : base("company")
		{
		}

		public PeopleContext(DbConnection existingConnection, bool contextOwnsConnections) 
			: base(existingConnection, contextOwnsConnections) {
			
		}

		public DbSet <Person> People { get; set; }

		public DbSet <Organization> Organizations { get; set; }

		public DbSet <Address> Addresses { get; set; }

		public Organization authorization(string email, string password) {
			Organization organization = null;
			foreach (Organization org in Organizations) {
				if( org.email == email && org.password == password )
					organization = org;
			}
			return organization;
		}
	}
}

