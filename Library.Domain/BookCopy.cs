namespace Library.Domain
{
    public class BookCopy
    {
        public int ID { get; set; }
        public int LoanID { get; set; }
        public BookDetails Details { get; set; }

    }
}