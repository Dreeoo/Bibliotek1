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
using Library.MVC.Models.AuthorModels;

namespace Library.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        private IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        //GET: Authors
        public async Task<IActionResult> Index()
        {
            var vm = new AuthorIndexVm();
            vm.Authors = authorService.GetAllAuthors();
            return View(vm);
        }

        // GET: Create author
        public IActionResult Create()
        {
            var vm = new AuthorCreateVm();
            return View(vm);
        }

        //POST: Create author
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorCreateVm vm)
        {
            if (ModelState.IsValid)
            {
                var newAuthor = new Author();
                newAuthor.Name = vm.Name;

                authorService.AddAuthor(newAuthor);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error", "Home", "");
        }
        //GET: Edit author
        public IActionResult Edit(int id)
        {
            var editedAuthor = authorService.GetAuthorById(id);
            var vm = new AuthorEditVm();
            vm.Name = editedAuthor.Name;
            return View(vm);
        }

        //POST: Edit author
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AuthorEditVm vm)
        {
            var editedAuthor = new Author();
            editedAuthor.ID = vm.ID;
            editedAuthor.Name = vm.Name;
            authorService.UpdateAuthor(editedAuthor);
            return RedirectToAction(nameof(Index));
        }
        // GET: Delete author
        public IActionResult Delete(int id)
        {
            var authorToDelete = authorService.GetAuthorById(id);
            var vm = new AuthorDeleteVm();
            vm.ID = id;
            vm.Name = authorToDelete.Name;
            return View(vm);
        }

        //POST: Delete author
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(AuthorDeleteVm vm)
        {
            var deletedAuthor = new Author();
            deletedAuthor.ID = vm.ID;
            deletedAuthor.Name = vm.Name;
            authorService.DeleteAuthor(deletedAuthor);
            return RedirectToAction(nameof(Index));
        }
        //GET: Author details 
        public IActionResult Details(int id)
        {
            var author = authorService.GetAuthorById(id);
            var vm = new AuthorDetailsVm();
            vm.ID = id;
            vm.Name = author.Name;
            return View(vm);
        }
    }
}
