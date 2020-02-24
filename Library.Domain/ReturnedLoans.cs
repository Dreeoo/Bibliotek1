using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain
{
    public class ReturnedLoans
    {
        public int ID { get; set; }
        public bool Delayed { get; set; }
        public int Fine { get; set; }
        public bool Returned { get; set; } = true;
        public int BookCopyID { get; set; }
        public int MemberID { get; set; }
        public Member Member { get; set; }
    }
}
