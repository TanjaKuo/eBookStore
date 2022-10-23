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

        [Display(Name = "Booking Number")]
        public Guid? BookingNumber { get; set; }

        public string? UserName { get; set; }

        // navigation 
        public ICollection<Reserve> ReserveDetails { get; set; }


    }
}

