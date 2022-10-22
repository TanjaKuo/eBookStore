using System;
using System.Net;
using eBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookDbContext _bookDbContext;

        public AccountRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _bookDbContext.User.FirstOrDefaultAsync(x => x.Id == userId); 
        }

        public async Task CreateUserAsync(User user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Password = user.Password
            };

            await _bookDbContext.User.AddAsync(newUser);
            await _bookDbContext.SaveChangesAsync();
        }

        //public async Task PostUserAsync(User user)
        //{

        //    var newUser = new User
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = user.Name,
        //        Password = user.Password,
        //        BookId = user.BookId

        //    };

        //    await _bookDbContext.User.AddAsync(newUser);
        //    await _bookDbContext.SaveChangesAsync();
        //}

        //public async Task UpdateUserAsync(User user)
        //{
        //    var theUser = await _bookDbContext.User.FirstOrDefaultAsync(x => x.Id == user.Id);

        //    if(theUser != null)
        //    {
        //        var newUser = new User
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = user.Name,
        //            Password = user.Password,
        //            BookId = user.BookId
        //        };

        //        await _bookDbContext.AddAsync(newUser);
        //        await _bookDbContext.SaveChangesAsync();

        //    }; 
        //}
    }
}

