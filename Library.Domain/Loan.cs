using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public string LoanTime { get; set; }
        public string ReturnTime { get; set; }
        public bool Delayed { get; set; } = true;
        public int Fine { get; set; } = 0;
        public BookCopy BookCopy { get; set; }
        public Member Member { get; set; }
    }
}
