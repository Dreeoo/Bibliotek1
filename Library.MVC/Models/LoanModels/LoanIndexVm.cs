using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.LoanModels
{
    public class LoanIndexVm
    {
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<ReturnedLoans> ReturnedLoans { get; set; } = new List<ReturnedLoans>();
    }
}
