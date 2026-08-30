using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Application.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
        DateTime ConvertToUserLocalTime(DateTime utcDateTime, string timeZoneId);
    }
}
