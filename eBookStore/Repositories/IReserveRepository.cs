using System;
using System.Threading.Tasks;
using eBookStore.Models;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Repositories
{
    public interface IReserveRepository
    {


        Task<Guid?> GetBookingNumberAsync(Guid bookId);

        Task<string?> GetReserveNameAsync(Guid bookId);

        Task GenerateBookingNumberAsync(Guid bookId, IdentityUser user2);

    }
}

