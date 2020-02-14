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
    public class BookCopyService : IBookCopyService

    {
        private readonly ApplicationDbContext context;

        public BookCopyService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IList<BookCopy> GetAllBookCopies()
        {
            return context.BookCopies.Include(x => x.Details).ToList();
        }
        public void AddBookCopy(BookCopy bookCopy)
        {
            context.Add(bookCopy);
            context.SaveChanges();
        }
        public BookCopy GetBookCopyById(int id)
        {
            return context.BookCopies.Include(x => x.Details).SingleOrDefault(x => x.ID == id);
        }
    }
}
