using TaskManagement.Application.Interfaces;

namespace TaskManagement.Application.Helpers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
    //عشان محطش صغط ع الباك
    //public DateTime ConvertToUserLocalTime(DateTime utcDateTime, string timeZoneId)
    //{
    //    var userTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    //    return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, userTimeZone);
    //}
}