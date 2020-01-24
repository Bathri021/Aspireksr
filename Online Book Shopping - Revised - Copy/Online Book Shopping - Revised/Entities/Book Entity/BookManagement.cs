using Online_Book_Shopping___Revised.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.Entities.Book_Entity
{
    class BookManagement
    {
        public void viewBooks()
        {
            BookRepositary obj = new BookRepositary();
            obj.addbBookIntoList();
            foreach (KeyValuePair<int, Book> book in obj.BookList)
            {
                Console.WriteLine("Book ID : {0} \n Title : {1} \n Author : {2} \n Genere : {3} \n Price : {4} \n No Of Pages : {5} \n",book.Key,book.Value.Title,book.Value.Author,book.Value.Genere,book.Value.Price,book.Value.NoOfPages);
            }
        }
    }
}
