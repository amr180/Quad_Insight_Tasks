using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}