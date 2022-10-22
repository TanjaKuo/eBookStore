using System;
using System.ComponentModel.DataAnnotations;

namespace eBookStore.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        // navigation 
        
    }
}

