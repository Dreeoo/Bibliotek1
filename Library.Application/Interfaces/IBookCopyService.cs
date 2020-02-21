using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IBookCopyService
    {
        /// <summary>
        /// Gets all book copies from the database
        /// </summary>
        /// <returns>list of book copies</returns>
        IList<BookCopy> GetAllBookCopies();
        IList<BookCopy> GetAvailableBookCopies(BookDetails book);
        BookCopy GetBookCopyById(int id);
    }
}
