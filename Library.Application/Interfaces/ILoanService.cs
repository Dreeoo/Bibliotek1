using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface ILoanService
    {
        ICollection<Loan> GetAllLoans();
        ICollection<ReturnedLoans> GetReturnedLoans();
        IList<Loan> GetLoansByMember(Member member);
        void AddLoan(Loan newLoan);
        void AddReturnedLoan(ReturnedLoans returnedLoan);
        void ReturnLoan(Loan returnLoan);
        Loan GetLoanById(int id);
        int FineIncrease(DateTime returnTime);
        public DateTime ReturnDate();
        public void UpdateLoan(Loan loan);
    }
}
