using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.API.Contracts;
using Tranquiliza.BufferedChat.Core.Repositories;
using Tranquiliza.BufferedChat.Core.Services;

namespace Tranquiliza.BufferedChat.API.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser([FromRoute]Guid userId)
        {
            if (userId == default(Guid))
                return NotFound();

            var user = await _userRepository.GetUserAsync(userId).ConfigureAwait(false);

            return Ok(UserContract.Create(user));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserContract createUserContract)
        {
            var id = await _userService.CreateUser(createUserContract.TwitchUsername).ConfigureAwait(false);
            return Ok(new { userId = id });
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddIntegration([FromRoute]Guid userId, [FromBody]IntegrationContract integration)
        {
            await _userService.AddIntegrationToUser(userId, integration.IntegrationUrl, integration.IsVisible).ConfigureAwait(false);
            return Ok();
        }
    }
}
