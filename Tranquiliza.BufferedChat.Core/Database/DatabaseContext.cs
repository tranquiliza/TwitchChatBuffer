using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tranquiliza.BufferedChat.Core.Domain;

namespace Tranquiliza.BufferedChat.Core
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; private set; }

        public DbSet<User> Users { get; private set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }
    }
}
