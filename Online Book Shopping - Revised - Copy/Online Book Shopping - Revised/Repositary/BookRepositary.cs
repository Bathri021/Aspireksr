using Online_Book_Shopping___Revised.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.Repositary
{
    class BookRepositary : Book
    {
        static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString; // Get Connection String From App.Config

        SqlConnection dbConnection = new SqlConnection(connection);

        public void addBook(Book book)
        {
            try
            {
                dbConnection.Open();
                string command = "spInsertBook"; // Using Parameterized Command

                using (SqlCommand insertcommand = new SqlCommand(command, dbConnection))
                {
                    insertcommand.CommandType = CommandType.StoredProcedure;
                    // Add The Parameters
                    insertcommand.Parameters.AddWithValue("@Title", book.Title);
                    insertcommand.Parameters.AddWithValue("@Author", book.Author);
                    insertcommand.Parameters.AddWithValue("@Genere", book.Genere);
                    insertcommand.Parameters.AddWithValue("@Price", book.Price);
                    insertcommand.Parameters.AddWithValue("@NoOfPages", book.NoOfPages);



                    SqlDataAdapter sqldataAdapter = new SqlDataAdapter();

                    sqldataAdapter.InsertCommand = insertcommand;
                    int rows = insertcommand.ExecuteNonQuery();  // Execute the Insert Query
                    if (rows >= 1)
                    {
                        Console.WriteLine("\nBook Added...");
                    }
                    else
                    {
                        Console.WriteLine("\nBook Does not Added...");
                    }
                }
                addbBookIntoList();

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

        public void addbBookIntoList()
        {
            string sqlQuery = "Select * From Book";
            using (SqlCommand selectCommand = new SqlCommand(sqlQuery, dbConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = selectCommand;
                DataSet BookDataset = new DataSet();
                adapter.Fill(BookDataset, "Book");
                DataTable BookDataTable = BookDataset.Tables["Book"];
                foreach (DataRow row in BookDataTable.Rows)
                {
                    Book book = new Book
                    {
                        BookID = int.Parse(row[0].ToString()),
                        Title = row[2].ToString(),
                        Author = row[3].ToString(),
                        Genere = row[4].ToString(),
                        Price =int.Parse( row[5].ToString()),
                        NoOfPages = int.Parse(row[6].ToString())
                    };
                    BookList.Add(book.BookID, book);
                }
            };

        }
    }
}
