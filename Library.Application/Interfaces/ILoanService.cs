using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface ILoanService
    {
        ICollection<Loan> GetAllLoans();
    }
}
