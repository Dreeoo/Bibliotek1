using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.MemberModels
{
    public class MemberDetailsVm
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public IList<Loan> Loans { get; set; } = new List<Loan>();
    }
}
