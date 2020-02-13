using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class BookDetailsVm
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorID { get; set; }
        public string Description { get; set; }
        public IList<BookCopy> Copies { get; set; }

    }
}
