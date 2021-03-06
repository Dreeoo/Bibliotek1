﻿using Library.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// Gets all Authors
        /// </summary>
        /// <returns>List of authors</returns>
        IList<Author> GetAllAuthors();
        void AddAuthor(Author newAuthor);
        void UpdateAuthor(Author editedAuthor);
        void DeleteAuthor(Author deletedAuthor);
        Author GetAuthorById(int id);
    }
}
