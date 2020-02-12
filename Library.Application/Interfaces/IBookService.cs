using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Adds the book to DB
        /// </summary>
        /// <param name="book"></param>
        void AddBook(BookDetails book);

        /// <summary>
        /// Updates a book
        /// </summary>
        /// <param name="book"></param>
        void UpdateBookDetails(BookDetails book);

        /// <summary>
        /// Updates a book.
        /// </summary>
        /// <param name="id">Id of book to update</param>
        /// <param name="book">New values of book (Id is ignored)</param>
        void UpdateBookDetails(int id, BookDetails book);

        void DeleteBook(BookDetails book);

        /// <summary>
        /// Gets all books from the database
        /// </summary>
        /// <returns>list of books</returns>
        ICollection<BookDetails> GetAllBooks();
        BookDetails GetBookById(int id);

        BookCopy GetBookCopyById(BookDetails id);
    }
}
