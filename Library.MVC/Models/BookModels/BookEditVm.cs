using Library.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models
{
    public class BookEditVm
    {
        [Required]
        public int ID { get; set; }
        [Display(Name = "ISBN")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$", ErrorMessage = "Please enter a valid ISBN consisting of 10 or 13 digits")]
        public string ISBN { get; set; }
        [Display(Name = "Book Title")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Title { get; set; }
        [Display(Name = "Författare")]
        public SelectList AuthorList { get; set; }
        public int AuthorID { get; set; }
        public string Description { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
        public int NumberCopies { get; set; }
    }
}
