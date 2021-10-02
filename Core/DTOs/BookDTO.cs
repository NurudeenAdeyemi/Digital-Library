using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class BookModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public int NumberOfPages { get; set; }
        public decimal Price { get; set; }

        public string BookImage { get; set; }

        public string BookPDF { get; set; }

        public BookStatus Status { get; set; }
        public DateTime PublicationDate { get; set; }

        public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }

    public class CreateBookRequestModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public int NumberOfPages { get; set; }
        public decimal Price { get; set; }

        public string BookImage { get; set; }

        public string BookPDF { get; set; }

        public BookStatus Status { get; set; }
        public DateTime PublicationDate { get; set; }
    }

    public class UpdateBookRequestModel
    {
        public decimal Price { get; set; }

        public string BookImage { get; set; }

        public string BookPDF { get; set; }

        public BookStatus Status { get; set; }

    }


}
