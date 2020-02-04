using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class BookDetailsVm
    {
        public int ID { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public Domain.Author Author { get; set; }
        public Domain.Author AuthorId { get; set; }
        public string Description { get; set; }

    }
}
