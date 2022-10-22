using System;
using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<IEnumerable<Book>> GetAllBooksWithBookingNumber(Guid bookingNumber);

        Task<IEnumerable<Book>> GetSearchBooks(string searchString);

        Task<Book> GetSingleBook(Guid? id);

        Task<Book> UpdateReserve(Book book);

        Task<Book> UpdateBookingNumber(Guid id, Guid? bookingNumber);

    }
}

