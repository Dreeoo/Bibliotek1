using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext context;

        public BookService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddBook(BookDetails book)
        {
            context.Add(book);
            context.SaveChanges();
        }

        public ICollection<BookDetails> GetAllBooks()
        {
            return context.BookDetails.Include(x => x.Author).Include(x => x.Copies).OrderBy(x => x.Title).ToList();
        }

        public int GetNumberOfAvailableCopies(BookDetails book)
        {
            return book.Copies.Where(x => x.OnLoan == false).Count();
        }

        public BookDetails GetBookById(int id)
        {
            return context.BookDetails.Include(x => x.Copies).Include(x => x.Author).SingleOrDefault(x => x.ID == id);
        }

        public void UpdateBookDetails(BookDetails book)
        {
            context.Update(book);
            context.SaveChanges();
        }

        public void DeleteBook(BookDetails book)
        {
            context.Remove(book);
            context.SaveChanges();
        }

        public void UpdateBookDetails(int id, BookDetails book)
        {
            throw new NotImplementedException();
        }

        public BookCopy GetCopyOfBook(BookDetails book)
        {
            return book.Copies.Where(x => x.OnLoan == false).ToList().Last();
        }
    }
}
