using Heinekamp.Application.Services;

namespace Heinekamp.Shared.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}