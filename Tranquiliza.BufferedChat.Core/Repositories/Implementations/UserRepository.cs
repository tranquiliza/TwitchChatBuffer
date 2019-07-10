using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateUserAsync(User user) => await _databaseContext.Users.AddAsync(user).ConfigureAwait(false);
        public async Task<User> GetUserAsync(Guid id) => await _databaseContext.Users
            .Include(x => x.Integrations)
            .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

        public async Task SaveChanges() => await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
    }
}
