﻿using System.ComponentModel.DataAnnotations;

namespace ProductTracking.MVC.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Password length must be 8 characters.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are not equal!")]
        public string ConfirmPassword { get; set; }
    }
}
