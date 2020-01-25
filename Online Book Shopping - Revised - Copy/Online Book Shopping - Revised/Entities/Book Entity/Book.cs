using Online_Book_Shopping___Revised.Repositary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.Entities
{
    class Book
    {
        public Dictionary<int, Book> BookList = new Dictionary<int, Book>();

        public int BookID;
      //  public int SellerID;
        public string Title;
        public string Author;
        public string Genere;
        public int Price;
        public int NoOfPages;
        public int Discount;

        public void getBook(string title,string author,string genere,int price,int noOfPages)
        {
            Book book = new Book
            {
               // SellerID=
                Title = title,
                Author=author,
                Genere=genere,
                Price=price,
                NoOfPages=noOfPages
            };

            BookRepositary bookRepos = new BookRepositary();

            if (bookRepos.addBook(book) >= 1)
            {
                Console.WriteLine("\nBook Added...");
            }
            else
            {
                Console.WriteLine("\nBook Does not Added...");
            }
        }

       
    }
}
