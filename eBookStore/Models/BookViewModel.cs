using System;
namespace eBookStore.Models
{
    public class BookViewModel
    { 
         public List<Book>? Books { get; set; }
         public string? SearchString { get; set; }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool Reserve { get; set; }

        public Guid ReserveNumber { get; set; }
    }
}

