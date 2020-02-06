using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.AuthorModels
{
    public class AuthorIndexVm
    {
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
