using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.MemberModels
{
    public class MemberCreateVm
    {
        [Required]
        public string SSN { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
