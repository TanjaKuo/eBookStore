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

        public Task<List<Guid>> GenerateNumber(Guid number)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookDbContext.Book.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetSearchBooks(string searchString)
        {
            return await _bookDbContext.Book.Where(x => x.Title!.Contains(searchString)).ToListAsync();
        }

        public async Task<Book> GetSingleBook(Guid? id)
        {
            return await _bookDbContext.Book.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Book> UpdateReserve(Book book)
        {
            var existingBook = await _bookDbContext.Book.FirstOrDefaultAsync(x => x.Id == book.Id);

            if (existingBook != null)
            {
                existingBook.Id = book.Id;
                existingBook.Title = book.Title;
                existingBook.Reserve = book.Reserve;
            }

            await _bookDbContext.SaveChangesAsync();
            return existingBook;
        }

    }
}

