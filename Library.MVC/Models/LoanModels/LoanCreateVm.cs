﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.MVC.Models.LoanModels
{
    public class LoanCreateVm
    {
        public int ID { get; set; }
        [Required]
        public DateTime LoanTime { get; set; } = DateTime.Now;
        [Required]
        public DateTime ReturnTime { get; set; } = DateTime.Now.AddDays(14);
        public SelectList BookList { get; set; }
        public SelectList MemberList { get; set; }
        public bool Delayed { get; set; } = false;
        public int Fine { get; set; } = 0;
        public int BookCopyID { get; set; }
        public int MemberID { get; set; }

    }
}
