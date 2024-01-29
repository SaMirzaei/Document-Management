using System;

namespace Heinekamp.Application.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
