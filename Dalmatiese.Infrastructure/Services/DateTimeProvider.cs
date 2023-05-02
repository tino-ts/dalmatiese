using Dalmatiese.Application.Common.Interfaces.Services;

namespace Dalmatiese.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}