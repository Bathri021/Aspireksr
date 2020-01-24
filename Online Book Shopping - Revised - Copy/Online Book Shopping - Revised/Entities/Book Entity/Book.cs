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

            bookRepos.addBook(book);
        }

        public void listBooks()
        {
            string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;   // Getting the Connection String 
            SqlConnection dbConnection = new SqlConnection(connection);

            try
            {
                dbConnection.Open();
                string command = "SELECT * FROM Book";   // Declare The Query
                SqlCommand selectcommand = new SqlCommand(command, dbConnection);
                SqlDataReader reader = selectcommand.ExecuteReader();

                Console.WriteLine("\n***Book Details***\n");
                //FetchDatails From Table
                while (reader.Read())
                {
                    Console.WriteLine("BookID : {0}\nTitle : {1}\nAuthor : {2}\nGenere : {3}\nPrice : {4}\nNo Of Pages : {5}", reader[0], reader[2], reader[3], reader[4], reader[5], reader[6]);
                    Console.WriteLine("\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : " + e.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}
