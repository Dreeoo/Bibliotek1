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

        //GET: Edit member
        public IActionResult Edit(int id)
        {
            var editedMember = memberService.GetMemberById(id);
            var vm = new MemberEditVm();
            vm.ID = id;
            vm.SSN = editedMember.SSN;
            vm.Name = editedMember.Name;
            return View(vm);
        }

        //POST: Edit member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MemberEditVm vm)
        {
            var editedMember = new Member();
            editedMember.ID = vm.ID;
            editedMember.SSN = vm.SSN;
            editedMember.Name = vm.Name;
            memberService.UpdateMember(editedMember);
            return RedirectToAction(nameof(Index));
        }
        // GET: Delete
        public IActionResult Delete(int id)
        {
            var memberToDelete = memberService.GetMemberById(id);
            var vm = new MemberDeleteVm();
            vm.ID = id;
            vm.SSN = memberToDelete.SSN;
            vm.Name = memberToDelete.Name;
            return View(vm);
        }

        //POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(MemberDeleteVm vm)
        {
            var deletedMember = new Member();
            deletedMember.ID = vm.ID;
            deletedMember.SSN = vm.SSN;
            deletedMember.Name = vm.Name;
            memberService.DeleteMember(deletedMember);
            return RedirectToAction(nameof(Index));
        }
        //GET: Details
        public IActionResult Details(int id)
        {
            var member = memberService.GetMemberById(id);
            var vm = new MemberDetailsVm();
            vm.ID = id;
            vm.SSN = member.SSN;
            vm.Name = member.Name;
            vm.Loans = loanService.GetLoansByMember(member);
            return View(vm);
        }
    }
}
