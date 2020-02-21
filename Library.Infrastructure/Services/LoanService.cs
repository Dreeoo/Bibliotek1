using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext context;

        public LoanService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddLoan(Loan newLoan)
        {
            context.Add(newLoan);
            context.SaveChanges();
        }

        public int FineIncrease(DateTime returnTime)
        {
            DateTime dayIncrease = DateTime.Now;
            TimeSpan days = dayIncrease - returnTime;
            int totalDays = int.Parse(days.Days.ToString());
            int fine = 0;

            for (int i = 0; i < totalDays; i++)
            {
                fine += 12;
            }

            return fine;
        }

        public ICollection<Loan> GetAllLoans()
        {
            // Here we are NOT using .Include() so the authors books will NOT be loaded, read more about loading related data at https://docs.microsoft.com/en-us/ef/core/querying/related-data
            return
                context.Loans
                .Include(x => x.Member)
                .Include(x => x.BookCopy)
                .ThenInclude(x => x.Details)
                .OrderBy(x => x.Delayed)
                .ToList();
                
               
            ;}

        public Loan GetLoanById(int id)
        {
            return 
                context.Loans
                .Include(x => x.Member)
                .Include(x => x.BookCopy)
                .ThenInclude(x => x.Details)
                .SingleOrDefault(x => x.ID == id)
            ;
        }

        public void ReturnLoan(Loan returnLoan)
        {
            context.Remove(returnLoan);
            context.SaveChanges();
        }
    }
}
