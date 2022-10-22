using System;
using System.Threading.Tasks;
using eBookStore.Models;

namespace eBookStore.Repositories
{
    public interface IReserveRepository
    {

        //Task<IEnumerable<Reserve>> GetBookIdAsync(Guid bookId);

        Task<Guid?> GetBookingNumberAsync(Guid bookId);

        //Task GetBookingNumberAsync(Guid bookId);


        Task GenerateBookingNumberAsync(Guid bookId);
    }
}

