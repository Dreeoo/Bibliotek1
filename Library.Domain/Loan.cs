using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class Loan
    {
        public int ID { get; set; }
        public string LoanTime { get; set; }
        public string ReturnTime { get; set; }
        public bool Delayed { get; set; } = true;
        public int Fine { get; set; } = 0;
        public ICollection<BookCopy> LoanedBooks { get; set; }
        public int MemberID { get; set; }
    }
}
