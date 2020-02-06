using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.MVC.Models.MemberModels
{
    public class MemberDeleteVm
    {
        public int ID { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
    }
}
