using System;

namespace Tranquiliza.BufferedChat.Listener.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}