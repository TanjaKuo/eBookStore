using System;
using System.ComponentModel.DataAnnotations;

namespace eBookStore.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool Reserve { get; set; }

        // navigation 
        public ICollection<Reserve> Reserves { get; set; }

    }
}

