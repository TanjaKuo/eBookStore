using System;
using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }


        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookDbContext.Book.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetSearchBooks(string searchString)
        {
            //var books = from m in _bookDbContext.Book select m;
            return await _bookDbContext.Book.Where(x => x.Title!.Contains(searchString)).ToListAsync();
        }

        public async Task<Book> GetSingleBook(Guid? id)
        {
            return await _bookDbContext.Book.FirstOrDefaultAsync(m => m.Id == id);
        }

        Task<Book> IBookRepository.UpdateReserve(bool reserver)
        {
            throw new NotImplementedException();
        }
    }
}

