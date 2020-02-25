using Library.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.LoanModels
{
    public class LoanCreateVm
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime LoanTime { get; set; } = DateTime.Today.AddDays(-16);
        [Required]
        public DateTime ReturnTime { get; set; } = DateTime.Today.AddDays(-14);
        public SelectList BookList { get; set; }
        public SelectList MemberList { get; set; }
        public bool Delayed { get; set; }
        public int Fine { get; set; }
        public bool Returned { get; set; }
        public int BookCopyID { get; set; }
        public BookCopy BookCopy { get; set; }
        public int MemberID { get; set; }

    }
}
