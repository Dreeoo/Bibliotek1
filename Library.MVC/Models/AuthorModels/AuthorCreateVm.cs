using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.AuthorModels
{
    public class AuthorCreateVm
    {
        [Required]
        [Display(Name = "Author Name")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a valid author name")]
        public string Name { get; set; }
    }
}
