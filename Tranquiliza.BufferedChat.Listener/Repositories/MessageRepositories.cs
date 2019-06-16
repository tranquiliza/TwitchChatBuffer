﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.Listener.Repositories
{
    public class MessageRepositories : IMessageRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MessageRepositories(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddMessage(ChatMessage chatMessage)
        {
            await _databaseContext.ChatMessages.AddAsync(chatMessage).ConfigureAwait(false);
        }

        public async Task SaveChanges()
        {
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
