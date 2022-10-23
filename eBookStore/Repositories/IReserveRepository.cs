using System;
using System.Threading.Tasks;
using eBookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Repositories
{
    public interface IReserveRepository
    {

        //Task<IEnumerable<Reserve>> GetBookIdAsync(Guid bookId);

        Task<Guid?> GetBookingNumberAsync(Guid bookId);

        Task<string?> GetReserveNameAsync(Guid bookId);

        //Task GetBookingNumberAsync(Guid bookId);


        //Task GenerateBookingNumberAsync(Guid bookId);

        //Task GenerateBookingNumberAsync(Guid bookId, UserViewModel user);

        //Task GenerateBookingNumberAsync(Guid bookId, UserManager<IdentityUser> user);
        Task GenerateBookingNumberAsync(Guid bookId, IdentityUser user2);

        //Task UpdateUserName(string name);
    }
}

