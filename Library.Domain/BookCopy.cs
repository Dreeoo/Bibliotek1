namespace Library.Domain
{
    public class BookCopy
    {
        public int ID { get; set; }
        public bool OnLoan { get; set; } 
        public BookDetails Details { get; set; }
    }
}