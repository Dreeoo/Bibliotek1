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
            // Here we are using .Include() to eager load the author, read more about loading related data at https://docs.microsoft.com/en-us/ef/core/querying/related-data
            return context.BookDetails.Include(x => x.Author).Include(x => x.Copies).OrderBy(x => x.Title).ToList();
        }

        public BookDetails GetBookById(int id)
        {
            return context.BookDetails.Find(id);
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
    }
}
