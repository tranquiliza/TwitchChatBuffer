using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.API.Controllers
{
    [Route("api/messages")]
    public class MessageController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;

        public MessageController(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }

        [Route("")]
        public async Task<IActionResult> Messages(string channelName, int pageSize = 20)
        {
            var result = await _chatMessageService.GetLatestMessages(channelName, pageSize).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
