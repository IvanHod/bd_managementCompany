using System;
using System.ComponentModel.DataAnnotations;

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

	public class AuthorizationModel
	{
		public AuthorizationModel(){}

		public AuthorizationModel(string e, string p){
			email = e;
			password = p;
		}

		[Required(ErrorMessage = "Поле должно быть установлено")]
		public string email { set; get; }

		[Required(ErrorMessage = "Поле должно быть установлено")]
		[StringLength(10, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 10 символов")]
		public string password { set; get; }
	}
}

