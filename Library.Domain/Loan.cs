using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class Loan
    {
        public int ID { get; set; }
        public DateTime LoanTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public bool Delayed { get; set; } = true;
        public int Fine { get; set; } = 0;
        public BookCopy BookCopy { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
    }
}
