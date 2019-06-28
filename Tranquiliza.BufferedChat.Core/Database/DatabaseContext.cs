using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Core
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; private set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
