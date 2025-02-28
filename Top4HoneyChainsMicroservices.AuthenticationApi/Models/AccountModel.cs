﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Top4HoneyChainsMicroservices.AuthenticationApi.Models
{
	public	class AccountModel
	{
		public class LoginModel
		{
			[Required]
			[Display(Name = "Enter Username")]
			public string UserName { get; set; }
			[Required]
			[DataType(DataType.Password)]
			[Display(Name = "Enter Username")]
			public string Password { get; set; }
		}

		public class ChangePasswordModel
		{
			[Required]
			public string UserName { get; set; }
			
			[Required]
			[DataType(DataType.Password)]
			[Display(Name = "Current password")]
			public string OldPassword { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
			[DataType(DataType.Password)]
			[Display(Name = "New password")]
			public string NewPassword { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm new password")]
			[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}

		public class RegisterModel
		{
			[Required(ErrorMessage = "Enter valid username!")]
			[Display(Name = "UserName")]
			public string UserName { get; set; }

			[Required(ErrorMessage = "Enter valid mail!")]
			[DataType(DataType.EmailAddress)]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}
	}
}