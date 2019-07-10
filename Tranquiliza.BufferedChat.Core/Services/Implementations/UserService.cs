using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core.Domain;
using Tranquiliza.BufferedChat.Core.Repositories;

namespace Tranquiliza.BufferedChat.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateUser(string twitchUsername)
        {
            var user = new User(twitchUsername);
            await _userRepository.CreateUserAsync(user).ConfigureAwait(false);
            await _userRepository.SaveChanges().ConfigureAwait(false);
            return user.Id;
        }

        public async Task AddIntegrationToUser(Guid id, string integrationUrl, bool visible)
        {
            var user = await _userRepository.GetUserAsync(id).ConfigureAwait(false);
            user.AddIntegration(integrationUrl, visible);
            await _userRepository.SaveChanges().ConfigureAwait(false);
        }
    }
}
