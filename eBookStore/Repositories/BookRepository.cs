using System;
using eBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;

        private readonly SignInManager<IdentityUser> _signInManager;

        public BookRepository(BookDbContext bookDbContext, SignInManager<IdentityUser> signInManager)
        {
            _bookDbContext = bookDbContext;
            _signInManager = signInManager;
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

        public async Task<Book> UpdateBooking(Guid id, Guid? bookingNumber, string? userName)
        {
            var existingBook = await _bookDbContext.Book.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook != null)
            {
                existingBook.BookingNumber = bookingNumber;
                existingBook.UserName = userName;
            }

            await _bookDbContext.SaveChangesAsync();
            return existingBook;
        }

  

        public async Task<Book> UpdateReserve(Book book)
        {
            var existingBook = await _bookDbContext.Book.FirstOrDefaultAsync(x => x.Id == book.Id);

            if (existingBook != null)
            {
                existingBook.Id = book.Id;
                existingBook.Title = book.Title;
                existingBook.Reserve = book.Reserve;
                
                if (book.Reserve == true)
                {
                    existingBook.BookingNumber = existingBook.BookingNumber;
                    existingBook.UserName = existingBook.UserName;
                }
                else
                {
                    existingBook.BookingNumber = null;
                    existingBook.UserName = null;
                }

            }

            await _bookDbContext.SaveChangesAsync();
            return existingBook;
        }

        
    }
}

