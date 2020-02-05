namespace Library.Domain
{
    public class Member
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public Loan Loan { get; set; }
    }
}
