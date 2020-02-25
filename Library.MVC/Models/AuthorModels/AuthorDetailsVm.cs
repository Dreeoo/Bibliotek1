using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.AuthorModels
{
    public class AuthorDetailsVm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<BookDetails> Books { get; set; } = new List<BookDetails>();
    }
}
