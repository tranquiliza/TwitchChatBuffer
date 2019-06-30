using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.API.Contracts;
using Tranquiliza.BufferedChat.Core;
using Tranquiliza.BufferedChat.Core.Domain;

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
        [HttpGet]
        public async Task<IActionResult> Messages(string channelName, int pageSize = 20)
        {
            var result = await _chatMessageService.GetLatestMessages(channelName, pageSize).ConfigureAwait(false);
            return Ok(result.Select(ChatMessageContract.Create));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddMessage([FromBody]CreateChatMessageContract chatMessage)
        {
            try
            {
                await _chatMessageService.CreateAndSaveMessage(
                    chatMessage.Channel,
                    chatMessage.Message,
                    chatMessage.UserColorHex,
                    chatMessage.UserColorHex,
                    chatMessage.UserId,
                    chatMessage.EmoteReplacedMessage,
                    chatMessage.DisplayName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // log exception
                throw;
            }

            return Ok();
        }
    }
}
