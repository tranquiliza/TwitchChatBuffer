using System;
using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.Core.Services
{
    public  interface IUserService
    {
        Task<Guid> CreateUser(string twitchUsername);
        Task AddIntegrationToUser(Guid id, string integrationUrl, bool visible);
    }
}