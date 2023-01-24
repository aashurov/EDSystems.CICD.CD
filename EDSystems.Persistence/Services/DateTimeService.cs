using EDSystems.Application.Interfaces;
using System;

namespace EDSystems.Persistence.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}