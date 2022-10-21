using System;
namespace eBookStore.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool Reserve { get; set; }
    }
}

