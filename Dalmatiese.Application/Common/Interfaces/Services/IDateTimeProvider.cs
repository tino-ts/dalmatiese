namespace Dalmatiese.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}