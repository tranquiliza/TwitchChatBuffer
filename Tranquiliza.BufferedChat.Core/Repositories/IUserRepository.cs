using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.Core.Repositories
{
    public interface IUserRepository
    {
        Task CreateUserAsync(User user);
        Task SaveChanges();
        Task<User> GetUserAsync(Guid id);
    }
}
