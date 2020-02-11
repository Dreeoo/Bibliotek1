using System.Collections.Generic;

namespace Library.Domain
{
    public class Member
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public IList<Loan> Loan { get; set; }
    }
}
