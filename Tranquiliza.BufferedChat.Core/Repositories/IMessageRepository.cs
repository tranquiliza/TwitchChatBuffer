﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tranquiliza.BufferedChat.Core
{
    public interface IMessageRepository
    {
        Task SaveChanges();
        Task AddMessage(ChatMessage chatMessage);
    }
}
