using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Library.Application.Interfaces;
using Library.MVC.Models;
using Library.MVC.Models.MemberModels;
using Library.Infrastructure.Services;

namespace Library.MVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService memberService;
        private readonly ILoanService loanService;

        public MembersController(IMemberService memberService, ILoanService loanService)
        {
            this.memberService = memberService;
            this.loanService = loanService;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var vm = new MemberIndexVm();
            vm.Members = memberService.GetAllMembers();
            return View(vm);
        }

        //GET: Create Member
        public IActionResult Create()
        {
            var vm = new MemberCreateVm();
            return View(vm);
        }

        //POST: New Member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MemberCreateVm vm)
        {
            if (ModelState.IsValid)
            {
                //Create new member
                var newMember = new Member();
                newMember.SSN = vm.SSN;
                newMember.Name = vm.Name;

                memberService.AddMember(newMember);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error", "Home", "");
        }
    }
}
