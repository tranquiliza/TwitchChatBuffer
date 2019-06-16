using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tranquiliza.BufferedChat.Core;

namespace Tranquiliza.BufferedChat.Listener
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; private set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
