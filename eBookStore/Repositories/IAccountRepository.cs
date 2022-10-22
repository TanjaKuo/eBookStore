using System;
using eBookStore.Models;

namespace eBookStore.Repositories
{
    public interface IAccountRepository
    {

        Task<User> GetUserAsync(Guid userId);

        Task CreateUserAsync(User user);

    }
}

