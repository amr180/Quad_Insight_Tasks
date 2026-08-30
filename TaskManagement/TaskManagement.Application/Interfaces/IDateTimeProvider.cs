using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Application.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
        //لو هخلي الباك هو اللي يحول الوقت
        //DateTime ConvertToUserLocalTime(DateTime utcDateTime, string timeZoneId);
    }
}
