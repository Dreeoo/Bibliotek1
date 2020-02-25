using Library.Application.Interfaces;
using Library.Domain;
using Library.MVC.Models.LoanModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Library.MVC.Controllers
{
    public class LoansController : Controller
    {
        private readonly ILoanService loanService;
        private readonly IMemberService memberService;
        private readonly IBookService bookService;
        private readonly IBookCopyService bookCopyService;

        public LoansController(ILoanService loanService, IMemberService memberService, IBookService bookService, IBookCopyService bookCopyService)
        {
            this.loanService = loanService;
            this.memberService = memberService;
            this.bookService = bookService;
            this.bookCopyService = bookCopyService;
        }

        public IActionResult Index()
        {
            var vm = new LoanIndexVm();
            vm.Loans = loanService.GetAllLoans();
            vm.ReturnedLoans = loanService.GetReturnedLoans();
            return View(vm);
        }

        //GET: Create Loan
        public IActionResult Create()
        {
            var vm = new LoanCreateVm();
            vm.BookList = new SelectList(bookService.GetAllBooks(), "ID", "Title");
            vm.MemberList = new SelectList(memberService.GetAllMembers(), "ID", "Name");
            return View(vm);
        }

        //GET: Get details
        public IActionResult Details(int id)
        {
            var date = loanService.ReturnDate();
            var loan = loanService.GetLoanById(id);
            var vm = new LoanDetailsVm();
            vm.ID = id;
            vm.BookCopy = loan.BookCopy;
            vm.LoanTime = loan.LoanTime;
            vm.ReturnTime = loan.ReturnTime;
            vm.Member = loan.Member;
            if(vm.ReturnTime.Date < date)
            {
                vm.Delayed = true;

                if (vm.Delayed == true)
                {
                    vm.Fine = loanService.FineIncrease(vm.ReturnTime);
                    loan.Delayed = vm.Delayed;
                    loan.Fine = vm.Fine;
                    loanService.UpdateLoan(loan);
                }
                else
                {
                    vm.Fine = loan.Fine;
                }
            }
            else
            {
                vm.Delayed = false;
            }
            return View(vm);
        }

        // GET: Return book copy
        public IActionResult Return(int id)
        {
            var date = loanService.ReturnDate();
            var loanToReturn = loanService.GetLoanById(id);
            var vm = new LoanReturnVm();
            vm.ID = id;
            vm.LoanTime = loanToReturn.LoanTime;
            vm.ReturnTime = loanToReturn.ReturnTime;
            vm.MemberID = loanToReturn.Member.ID;
            vm.BookCopyID = loanToReturn.BookCopy.ID;
            if (vm.ReturnTime.Date < date)
            {
                vm.Delayed = true;

                if (vm.Delayed == true)
                {
                    vm.Fine = loanService.FineIncrease(vm.ReturnTime);
                }
                else
                {
                    vm.Fine = loanToReturn.Fine;
                }
            }
            else
            {
                vm.Delayed = false;
            }
            return View(vm);
        }

        // POST: Return book copy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Return(LoanReturnVm vm)
        {
            var loan = loanService.GetLoanById(vm.ID);
            var date = loanService.ReturnDate();
            var returnedLoan = new Loan(); // Spara i ny lista av lån
            returnedLoan.ID = vm.ID;
            returnedLoan.BookCopy = bookCopyService.GetBookCopyById(vm.BookCopyID);
            returnedLoan.LoanTime = loan.LoanTime;
            returnedLoan.ReturnTime = loan.ReturnTime;
            returnedLoan.MemberID = vm.MemberID;
            returnedLoan.BookCopyID = returnedLoan.BookCopy.ID;
            if (returnedLoan.ReturnTime.Date < date)
            {
                returnedLoan.Delayed = true;

                if (returnedLoan.Delayed == true)
                {
                    returnedLoan.Fine = loanService.FineIncrease(returnedLoan.ReturnTime);
                }
            }
            else if (returnedLoan.ReturnTime.Date > date)
            {
                returnedLoan.Delayed = false;
                returnedLoan.Fine = vm.Fine;
            }
            returnedLoan.Returned = true;
            returnedLoan.BookCopy.OnLoan = false;
            returnedLoan.BookCopy.Details.CopiesAvailable += bookService.GetNumberOfAvailableCopies(returnedLoan.BookCopy.Details);
            AddReturnedLoan(returnedLoan); //Skickar informationen till en ny lista
            bookService.UpdateBookDetails(returnedLoan.BookCopy.Details);
            loanService.ReturnLoan(returnedLoan);
            return RedirectToAction(nameof(Index));
        }

        public void AddReturnedLoan(Loan returnedLoan)
        {
            var returnLoan = new ReturnedLoans();
            returnLoan.BookCopyID = returnedLoan.BookCopyID;
            returnLoan.BookCopy = returnedLoan.BookCopy;
            returnLoan.Delayed = returnedLoan.Delayed;
            returnLoan.Fine = returnedLoan.Fine;
            returnLoan.MemberID = returnedLoan.MemberID;
            returnLoan.Returned = returnedLoan.Returned;
            loanService.AddReturnedLoan(returnLoan);
        }
    }
}
