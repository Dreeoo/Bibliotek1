using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Persistence;
using System;
using System.Collections.Generic;

namespace Library.Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        private readonly ApplicationDbContext context;

        public LoanService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<Loan> GetAllLoans()
        {
            throw new NotImplementedException();
        }
    }
}
