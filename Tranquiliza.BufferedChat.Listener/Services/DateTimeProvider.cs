using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Listener.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
