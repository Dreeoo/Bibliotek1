using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain
{
    public class BookCopy
    {
        public int ID { get; set; }
        [ForeignKey("Loan")]
        public int LoanID { get; set; }
        public BookDetails Details { get; set; }

    }
}