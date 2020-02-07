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

        public ICollection<Loan> GetAllLoans()
        {
            // Here we are NOT using .Include() so the authors books will NOT be loaded, read more about loading related data at https://docs.microsoft.com/en-us/ef/core/querying/related-data
            return 
                context.Loans.OrderBy(x => x.Delayed)
                .Include(x => x.Member)
                .Include(x => x.BookCopy)
                .ThenInclude(x => x.Details)
                .ToList()
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
