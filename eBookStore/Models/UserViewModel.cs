using System;
using System.ComponentModel.DataAnnotations;

namespace eBookStore.Models
{
    public class UserViewModel 
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}

