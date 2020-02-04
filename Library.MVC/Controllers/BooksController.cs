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
        private readonly IBookService bookservice;
        private readonly IAuthorService authorService;

        public BooksController(IBookService bookservice, IAuthorService authorService)
        {
            this.bookservice = bookservice;
            this.authorService = authorService;
        }

        //GET: Books
        public async Task<IActionResult> Index()
        {
            var vm = new BookIndexVm();
            vm.Books = bookservice.GetAllBooks();
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

                bookservice.AddBook(newBook);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error","Home","");
        }

        //GET: Gets the chosen book to edit
        public IActionResult Edit(int id)
        {
            var book = bookservice.GetBookById(id);
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
            bookservice.UpdateBookDetails(editedBook);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var bookToDelete = bookservice.GetBookById(id);
            var vm = new BookDeleteVm();
            vm.ID = id;
            vm.ISBN = bookToDelete.ISBN;
            vm.Title = bookToDelete.Title;
            vm.Author = bookToDelete.AuthorId;
            vm.Description = bookToDelete.Description;
            return View(vm);
        }

    }
}
