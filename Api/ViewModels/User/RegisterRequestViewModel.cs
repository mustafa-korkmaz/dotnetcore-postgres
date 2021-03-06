﻿using Common;
using System.ComponentModel.DataAnnotations;

namespace BoilerplateDotnetCorePostgres.ViewModels.User
{
    public class RegisterRequestViewModel
    {
        [Required(ErrorMessage = ValidationErrorCode.RequiredField)]
        [StringLength(30, ErrorMessage = ValidationErrorCode.MaxLength)]
        [Display(Name = "USERNAME")]
        public string Username { get; set; }

        [Required(ErrorMessage = ValidationErrorCode.RequiredField)]
        [EmailAddress(ErrorMessage = ValidationErrorCode.EmailNotValid)]
        [Display(Name = "EMAIL")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = ValidationErrorCode.BetweenLength, MinimumLength = 4)]
        [Display(Name = "NAME_SURNAME")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = ValidationErrorCode.RequiredField)]
        [Display(Name = "PASSWORD")]
        public string Password { get; set; }
    }
}
