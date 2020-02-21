using Library.Application.Interfaces;
using System;

namespace Library.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now { get; set; } = DateTime.Now;
    }
}

