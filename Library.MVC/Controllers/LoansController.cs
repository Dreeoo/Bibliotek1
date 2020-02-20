using Library.Application.Interfaces;
using Library.Domain;
using Library.MVC.Models.LoanModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var loan = loanService.GetLoanById(id);
            var vm = new LoanDetailsVm();
            vm.ID = id;
            vm.BookCopy = loan.BookCopy;
            vm.LoanTime = loan.LoanTime;
            vm.ReturnTime = loan.ReturnTime;
            vm.Member = loan.Member;
            vm.Delayed = loan.Delayed;
            vm.Fine = loan.Fine;
            return View(vm);
        }

        // GET: Return book copy
        public IActionResult Return(int id)
        {
            var loan = loanService.GetLoanById(id);
            var vm = new LoanReturnVm();
            vm.ID = id;
            vm.LoanTime = loan.LoanTime;
            vm.ReturnTime = loan.ReturnTime;
            vm.MemberID = loan.MemberID;
            vm.BookCopyID = loan.BookCopyID;
            vm.BookCopy = loan.BookCopy;
            vm.Delayed = loan.Delayed;
            vm.Fine = loan.Fine;
            vm.Returned = loan.Returned;
            return View(vm);
        }

        // POST: Return book copy
        [HttpPost]
        public IActionResult Return(LoanReturnVm vm)
        {
            var loanToReturn = loanService.GetLoanById(vm.ID);
            var returnedLoan = new Loan();
            returnedLoan.ID = vm.ID;
            returnedLoan.BookCopyID = loanToReturn.BookCopyID;
            returnedLoan.BookCopy = loanToReturn.BookCopy;
            returnedLoan.LoanTime = loanToReturn.LoanTime;
            returnedLoan.ReturnTime = loanToReturn.ReturnTime;
            returnedLoan.MemberID = loanToReturn.MemberID;
            returnedLoan.Delayed = loanToReturn.Delayed;
            returnedLoan.Fine = loanToReturn.Fine;
            returnedLoan.Returned = true;
            returnedLoan.BookCopy.OnLoan = false;
            loanService.ReturnLoan(returnedLoan);
            return RedirectToAction(nameof(Index));
        }

        //// GET: Loans
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Loans.ToListAsync());
        //}

        //// GET: Loans/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loan = await _context.Loans
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (loan == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(loan);
        //}

        //// GET: Loans/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Loans/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,LoanTime,ReturnTime,Delayed,Fine,MemberID")] Loan loan)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(loan);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(loan);
        //}

        //// GET: Loans/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loan = await _context.Loans.FindAsync(id);
        //    if (loan == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(loan);
        //}

        //// POST: Loans/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,LoanTime,ReturnTime,Delayed,Fine,MemberID")] Loan loan)
        //{
        //    if (id != loan.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(loan);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LoanExists(loan.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(loan);
        //}

        //// GET: Loans/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loan = await _context.Loans
        //        .FirstOrDefaultAsync(m => m.ID == id);
        //    if (loan == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(loan);
        //}

        //// POST: Loans/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var loan = await _context.Loans.FindAsync(id);
        //    _context.Loans.Remove(loan);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LoanExists(int id)
        //{
        //    return _context.Loans.Any(e => e.ID == id);
        //}
    }
}
