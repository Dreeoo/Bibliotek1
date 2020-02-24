using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class BookCreateVm
    {
        [Required]
        [Display(Name = "ISBN")]
        [DataType(DataType.Text)]
        /*[RegularExpression(@"^(?:ISBN(?:-1[03])?:?●)?(?=[0-9X]{10}$|
(?=(?:[0-9]+[-●]){3})[-●0-9X]{13}$|
97[89][0-9]{10}$|(?=(?:[0-9]+[-●]){4})[-●0-9]{17}$)|
(?:97[89][-●]?)?[0-9]{1,5}[-●]?[0-9]+[-●]?[0-9]+[-●]?[0-9X]$", ErrorMessage = "Please enter a valid ISBN")]*/
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author Name")]
        public SelectList AuthorList { get; set; }

        public int AuthorID { get; set; }

        [Required]
        [Display(Name = "Book Description")]
        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 4)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number of Book Copies")]
        public int Copies { get; set; }

    }
}
