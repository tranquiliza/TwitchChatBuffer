using System;
using System.Collections.Generic;
using System.Text;

namespace Tranquiliza.BufferedChat.Core
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
