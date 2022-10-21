using System;
namespace eBookStore.Models
{
    public class Reserve
    {
        public Guid Id { get; set; }

        public Guid BookingNumber { get; set; }

        public Guid BookId { get; set; }
    }
}

