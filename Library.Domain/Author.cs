using System.Collections.Generic;

namespace Library.Domain
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<BookDetails> Books { get; set; }
    }
}