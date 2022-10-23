using System;
using System.Net;
using eBookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Repositories
{
    public class ReserveRepository : IReserveRepository
    {

        private readonly BookDbContext _bookDbContext;
      
        public ReserveRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
            
        }

     
        public async Task GenerateBookingNumberAsync(Guid bookId, IdentityUser user)
        {
            var newBookingNumber = new Reserve
            {
                Id = Guid.NewGuid(),
                BookingNumber = Guid.NewGuid(),
                BookId = bookId,
                ReservedTime = DateTime.Now,
                UserName = user.UserName
            };

            await _bookDbContext.Reserves.AddAsync(newBookingNumber);
            await _bookDbContext.SaveChangesAsync();
        }



        public async Task<Guid?> GetBookingNumberAsync(Guid bookId)
        {
            var checkingBookId = await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookId == bookId);

            var reservedTime = await _bookDbContext.Reserves.OrderByDescending(x => x.ReservedTime).FirstOrDefaultAsync();

            if (checkingBookId != null || reservedTime != null)
            {

                return reservedTime.BookingNumber;
            }

            return null;
             
        }

        public async Task<string?> GetReserveNameAsync(Guid bookId)
        {
            var checkingBookId = await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookId == bookId);

            var reservedTime = await _bookDbContext.Reserves.OrderByDescending(x => x.ReservedTime).FirstOrDefaultAsync();

            if (checkingBookId != null || reservedTime != null)
            {

                return reservedTime.UserName;
            }

            return null;
        }


    }
}

