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
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "Please enter a valid ISBN consisting of 10 or 13 digits")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Book Title")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Author")]
        public SelectList AuthorList { get; set; }

        public int AuthorID { get; set; }

        [Required]
        [Display(Name = "Book Description")]
        [DataType(DataType.Text)]
        [StringLength(500, MinimumLength = 4, ErrorMessage = "Please enter a valid book description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Number of Book Copies")]
        public int Copies { get; set; }

    }
}
