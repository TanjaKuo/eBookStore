using System;
namespace eBookStore.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public Guid BookId { get; set; }
    }
}

