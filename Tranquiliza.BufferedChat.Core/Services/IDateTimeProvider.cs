using System;

namespace Tranquiliza.BufferedChat.Core
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}