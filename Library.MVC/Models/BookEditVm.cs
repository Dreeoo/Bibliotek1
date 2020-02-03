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
        public string ISBN { get; set; }
        [Display(Name = "Titel")]
        [MaxLength(7)]
        public string Title { get; set; }
        [Display(Name = "Författare")]
        public SelectList AuthorList { get; set; }
        public int AuthorID { get; set; }
        public string Description { get; set; }
    }
}
