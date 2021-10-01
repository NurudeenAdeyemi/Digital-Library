using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Book
    {
         public string ISBN { get; set; }
         public string Title { get; set; }
         public string Subject { get; set; }
         public string Publisher { get; set; }
         public string Language { get; set; }
         public int NumberOfPages { get; set; }
         public List<Author> Authors { get; set; } = new List<Author>();
         public bool IsAvailable { get; set; }
         public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Price { get; set; }
        public BookStatus Status { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
