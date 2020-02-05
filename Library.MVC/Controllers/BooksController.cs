using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Domain;
using Library.MVC.Models;
using Library.Application.Interfaces;

namespace Library.MVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        //GET: Books
        public async Task<IActionResult> Index()
        {
            var vm = new BookIndexVm();
            vm.Books = bookService.GetAllBooks();
            return View(vm);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var vm = new BookCreateVm();
            vm.AuthorList = new SelectList(authorService.GetAllAuthors(), "Id", "Name");
            return View(vm);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateVm vm)
        {
            if (ModelState.IsValid)
            {
                //Skapa ny bok
                var newBook = new BookDetails();
                newBook.AuthorID = vm.AuthorId;
                newBook.Description = vm.Description;
                newBook.ISBN = vm.ISBN;
                newBook.Title = vm.Title;

                bookService.AddBook(newBook);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error","Home","");
        }

        //GET: Gets the chosen book to edit
        public IActionResult Edit(int id)
        {
            var book = bookService.GetBookById(id);
            var vm = new BookEditVm();
            vm.ID = id;
            vm.Title = book.Title;
            vm.ISBN = book.ISBN;
            vm.Description = book.Description;
            vm.AuthorID = book.AuthorID;

            vm.AuthorList = new SelectList(authorService.GetAllAuthors(), "Id", "Name", book.AuthorID);

            return View(vm);
        }

        //POST: Posts the changes made to the chosen book
        [HttpPost]
        public IActionResult Edit(BookEditVm vm)
        {
            var editedBook = new BookDetails();
            editedBook.ID = vm.ID;
            editedBook.Title = vm.Title;
            editedBook.ISBN = vm.ISBN;
            editedBook.Description = vm.Description;
            editedBook.AuthorID = vm.AuthorID;
            bookService.UpdateBookDetails(editedBook);
            return RedirectToAction(nameof(Index));
        }

        //GET: Delete
        public IActionResult Delete(int id)
        {
            var bookToDelete = bookService.GetBookById(id);
            var vm = new BookDeleteVm();
            vm.ID = id;
            vm.ISBN = bookToDelete.ISBN;
            vm.Title = bookToDelete.Title;
            vm.AuthorID = bookToDelete.AuthorID;
            vm.Description = bookToDelete.Description;
            return View(vm);
        }

        //POST: Delete
        [HttpPost]
        public IActionResult Delete(BookDeleteVm vm)
        {
            var deletedBook = new BookDetails();
            deletedBook.ID = vm.ID;
            deletedBook.Title = vm.Title;
            deletedBook.ISBN = vm.ISBN;
            deletedBook.Description = vm.Description;
            deletedBook.AuthorID = vm.AuthorID;
            bookService.DeleteBook(deletedBook);
            return RedirectToAction(nameof(Index));
        }

        //GET: Details
        public IActionResult Details(int id)
        {
            var book = bookService.GetBookById(id);
            var vm = new BookDetailsVm();
            vm.ID = id;
            vm.Title = book.Title;
            vm.ISBN = book.ISBN;
            vm.Description = book.Description;
            vm.AuthorID = book.AuthorID;
            return View(vm);
        }

    }
}
