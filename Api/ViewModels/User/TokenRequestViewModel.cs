﻿using Common;
using System.ComponentModel.DataAnnotations;

namespace BoilerplateDotnetCorePostgres.ViewModels.User
{
    public class TokenRequestViewModel
    {
        [Required(ErrorMessage = ValidationErrorCode.RequiredField)]
        [Display(Name ="EMAIL_OR_USERNAME")]
        public string EmailOrUsername { get; set; }
      
        [Required(ErrorMessage = ValidationErrorCode.RequiredField)]
        [Display(Name = "PASSWORD")]
        public string Password { get; set; }
    }
}
