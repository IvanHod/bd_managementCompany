using System;

namespace web.Models
{
	public class AuthModel
	{
		public AuthModel ()
		{
		}
			
		public AuthModel (Organization org)
		{
			organization = org;
		}

		public AuthModel (Owner own)
		{
			owner = own;
		}

		public bool isOrganization() {
			return organization != null;
		}

		public int getId() {
			if (isOrganization ())
				return organization.id;
			else
				return owner.id;
		}

		public Organization organization { get; set; } = null;

		public Owner owner { get; set; } = null;
	}
}

