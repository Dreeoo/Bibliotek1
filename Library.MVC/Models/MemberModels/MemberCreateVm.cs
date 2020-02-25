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
        [Display(Name = "Social Security Number")]
        [DataType(DataType.Text)]
        [StringLength(15, ErrorMessage = "Please enter a valid SSN")]
        public string SSN { get; set; }
        [Required]
        [Display(Name = "Member Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }
    }
}
