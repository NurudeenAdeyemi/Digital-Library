using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        public Author GetAuthor(int id);
        public IList<Author> GetAuthors();

        public Author UpdateAuthor(Author author);

        public Author AddAuthor(Author author);

        public void DeleteAuthor(int id);
    }
}
