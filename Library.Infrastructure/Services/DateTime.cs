using Library.Application.Interfaces;
using System;

namespace Library.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime ReturnDate()
        {
            var date = DateTime.Today;
            return date;
        }
    }
}

