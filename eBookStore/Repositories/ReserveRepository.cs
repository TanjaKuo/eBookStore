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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ReserveRepository(BookDbContext bookDbContext,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _bookDbContext = bookDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public async Task GenerateBookingNumberAsync(Guid bookId)
        //{

        //    var newBookingNumber = new Reserve
        //    {
        //        Id = Guid.NewGuid(),
        //        BookingNumber = Guid.NewGuid(),
        //        BookId = bookId,
        //        ReservedTime = DateTime.Now,
        //        //UserName =  (await _userManager
        //        //UserName = user.Username
        //    };

        //    await _bookDbContext.Reserves.AddAsync(newBookingNumber);
        //    await _bookDbContext.SaveChangesAsync();

        //}

        //public async Task GenerateBookingNumberAsync(Guid bookId, UserViewModel user)
        //{
        //    var newBookingNumber = new Reserve
        //    {
        //        Id = Guid.NewGuid(),
        //        BookingNumber = Guid.NewGuid(),
        //        BookId = bookId,
        //        ReservedTime = DateTime.Now,
        //        UserName = _signInManager.ToString()
        //    };

        //    await _bookDbContext.Reserves.AddAsync(newBookingNumber);
        //    await _bookDbContext.SaveChangesAsync();
        //}

        //public async Task GenerateBookingNumberAsync(Guid bookId, UserManager<IdentityUser> user)
        //{
        //    var newBookingNumber = new Reserve
        //    {
        //        Id = Guid.NewGuid(),
        //        BookingNumber = Guid.NewGuid(),
        //        BookId = bookId,
        //        ReservedTime = DateTime.Now,
        //        //UserName = user.FindByNameAsync(user.);
        //};

        //    await _bookDbContext.Reserves.AddAsync(newBookingNumber);
        //    await _bookDbContext.SaveChangesAsync();
        //}

        public async Task GenerateBookingNumberAsync(Guid bookId, IdentityUser user2)
        {
            var newBookingNumber = new Reserve
            {
                Id = Guid.NewGuid(),
                BookingNumber = Guid.NewGuid(),
                BookId = bookId,
                ReservedTime = DateTime.Now,
                UserName = user2.UserName
                //UserName = user.FindByNameAsync(user.);
            };

            await _bookDbContext.Reserves.AddAsync(newBookingNumber);
            await _bookDbContext.SaveChangesAsync();
        }


        //public async Task UpdateUserName(string name)
        //{
        //    var theUser = new Reserve
        //    {
        //        UserName =  name
        //    };

        //    await _bookDbContext.Reserves.AddAsync(theUser);
        //    await _bookDbContext.SaveChangesAsync();
        //}


        //public async Task<Guid> GetBookingNumberAsync(Guid bookId)
        //{
        //    var checkingBookId = await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookId == bookId);

        //    if (checkingBookId != null)
        //    {
        //         await _bookDbContext.Reserves.OrderBy(x => x.ReservedTime).ToListAsync();
        //    }

        //    return 

        //    //return await _bookDbContext.Reserves.Where(x => x.BookId == bookId).ToListAsync();
        //}

        //public async Task GetBookingNumberAsync(Guid bookId)
        //{
        //    //var checkingBookId = await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookId == bookId);

        //    //if (checkingBookId != null)
        //    //{
        //    //    await _bookDbContext.Reserves.OrderBy(x => x.ReservedTime).FirstOrDefaultAsync();
        //    //}

        //    //var checkingBookId = await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookId == bookId);

        //    //var reservedTime = await _bookDbContext.Reserves.OrderBy(x => x.ReservedTime).FirstOrDefaultAsync();

        //    //if (checkingBookId != null && reservedTime.ReservedTime != null)
        //    //{

        //    var checkingBookId = await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookId == bookId);

        //    var reservedTime = await _bookDbContext.Reserves.OrderBy(x => x.ReservedTime).FirstOrDefaultAsync();

        //    if (checkingBookId != null && reservedTime != null)
        //    {
        //        //return await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookingNumber);
        //         await _bookDbContext.Reserves.Select(x => x.BookingNumber);
        //    }
        //    //await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookingNumber);
        //    //}


        //    // check if the bookid is correct and the reserver data is news

        //}

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



        //public async Task<Guid> GetBookingNumberAsync(Guid bookId)
        //{

        //    var checkingBookId = await _bookDbContext.Reserves.FirstOrDefaultAsync(x => x.BookId == bookId);

        //    if(checkingBookId != null)
        //    {
        //        await _bookDbContext.Reserves.OrderBy(_bookDbContext.Reserves.)
        //    }

        //    return await _bookDbContext.Reserves.Where(x => x.BookId == bookId).ToListAsync();
        //}

        //public async Task<IEnumerable<Reserve>> GetBookIdAsync(Guid bookId)
        //{
        //    return await _bookDbContext.Reserves.Where(x => x.BookId == bookId).ToListAsync();
        //}

        //public Task<Guid> GetBookingNumber(Guid bookId)
        //{
        //    var newBookingNumber = new Reserve
        //    {
        //        Id = Guid.NewGuid(),
        //        BookingNumber = Guid.NewGuid(),
        //        BookId = bookId
        //    };

        //    if(bookId == newBookingNumber.BookingNumber)
        //    {

        //    }
        //}

        //public async Task<Guid> GetBookingNumberAsync(bool reserve)
        //{
        //    if(reserve == true)
        //    {
        //        await _bookDbContext.Reserves.Add(Guid.NewGuid());
        //    }
        //}
    }
}

