using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.LoanModels
{
    public class LoanReturnVm
    {
        public int ID { get; set; }
        public DateTime LoanTime { get; set; } 
        public DateTime ReturnTime { get; set; }
        public bool Delayed { get; set; }
        public int Fine { get; set; }
        public bool Returned { get; set; }
        public int BookCopyID { get; set; }
        public int MemberID { get; set; }
    }
}
