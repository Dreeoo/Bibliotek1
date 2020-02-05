using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain;

namespace Library.MVC.Models
{
    public class MemberIndexVm
    {
        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
