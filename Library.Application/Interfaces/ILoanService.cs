using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface ILoanService
    {
        ICollection<Loan> GetAllLoans(); 
        void AddLoan(Loan newLoan);
        void ReturnLoan(Loan returnLoan);
        Loan GetLoanById(int id);
    }
}
