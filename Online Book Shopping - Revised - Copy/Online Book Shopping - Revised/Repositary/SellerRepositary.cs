using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;

namespace Online_Book_Shopping___Revised
{
    class SellerRepositary : Seller
    {

        static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;  // Get Connection String From App.Config

        SqlConnection dbConnection = new SqlConnection(connection);
        public int addSeller(Seller seller)
        {
            int rows;
            try
            {

                dbConnection.Open();
                string command = "spInsertSeller";  // Using Parameterized Command

                using (SqlCommand insertcommand = new SqlCommand(command, dbConnection))
                {
                    insertcommand.CommandType = CommandType.StoredProcedure;
                    // Add The Parameters
                    insertcommand.Parameters.AddWithValue("@Name", seller.Name);
                    insertcommand.Parameters.AddWithValue("@UserName", seller.UserName);
                    insertcommand.Parameters.AddWithValue("@MailID", seller.MailId);
                    insertcommand.Parameters.AddWithValue("@PhoneNumber", seller.PhoneNumber);
                    insertcommand.Parameters.AddWithValue("@Password", seller.Password);
                    insertcommand.Parameters.AddWithValue("@Role", seller.Role);

                    SqlDataAdapter sqldataAdapter = new SqlDataAdapter();

                    sqldataAdapter.InsertCommand = insertcommand;
                    rows = insertcommand.ExecuteNonQuery();   // Execute the Insert Query
                   
                }
                addSellerIntoList();
                return rows;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : " + e.Message);
                return 0;
            }

            finally
            {
                dbConnection.Close();
            }


        }

        public void addSellerIntoList()
        {
            string sqlQuery = "Select * From Seller";
            using (SqlCommand selectCommand = new SqlCommand(sqlQuery, dbConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = selectCommand;
                DataSet sellerDataset = new DataSet();
                adapter.Fill(sellerDataset, "Seller");
                DataTable sellerDataTable = sellerDataset.Tables["Seller"];  // create Data table Seller
                foreach (DataRow row in sellerDataTable.Rows)
                {
                    Seller seller = new Seller
                    {
                        Name = row[0].ToString(),
                        UserName = row[1].ToString(),
                        MailId = row[2].ToString(),
                        PhoneNumber = Double.Parse(row[3].ToString()),
                        Password = row[4].ToString(),
                        Role = row[5].ToString(),
                        SellerID = int.Parse(row[6].ToString())
                    };
                    sellerList.Add(seller.SellerID, seller);  // Add the seller Object into List
                }
            };

        }

    }
}
