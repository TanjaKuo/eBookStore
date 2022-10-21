using System;
using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<IEnumerable<Book>> GetSearchBooks(string searchString);


        Task<Book> GetSingleBook(Guid? id);

        Task<Book> UpdateReserve(bool reserver);
    }
}

