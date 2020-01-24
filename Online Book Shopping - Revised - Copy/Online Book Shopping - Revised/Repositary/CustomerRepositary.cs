using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Online_Book_Shopping___Revised
{
    class CustomerRepositary : Customer
    {

        static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString; // Get Connection String From App.Config

        SqlConnection dbConnection = new SqlConnection(connection);
        
        public void addCustomer(Customer customer)
        {

            try
            {
                dbConnection.Open();
                string command = "spInsertCustomer"; // Using Parameterized Command

                using (SqlCommand insertcommand = new SqlCommand(command, dbConnection))
                {
                    insertcommand.CommandType = CommandType.StoredProcedure;
                    // Add The Parameters
                    insertcommand.Parameters.AddWithValue("@Name", customer.Name);  
                    insertcommand.Parameters.AddWithValue("@UserName", customer.UserName);
                    insertcommand.Parameters.AddWithValue("@MailID", customer.MailId);
                    insertcommand.Parameters.AddWithValue("@Password", customer.Password);
                    insertcommand.Parameters.AddWithValue("@Role", customer.Role);
                 


                  SqlDataAdapter sqldataAdapter = new SqlDataAdapter();

                  sqldataAdapter.InsertCommand = insertcommand;
                  int rows = insertcommand.ExecuteNonQuery();  // Execute the Insert Query
                    if (rows >= 1)
                    {
                        Console.WriteLine("\nCustomer Added...");
                    }
                    else
                    {
                        Console.WriteLine("\nCustomer Does not Added...");
                    }
                }
                addCustomerIntoList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
            }

            finally
            {
                dbConnection.Close();
            }
             
         }

        public void addCustomerIntoList()
        {
            string sqlQuery = "Select * From Customer";
            using (SqlCommand selectCommand = new SqlCommand(sqlQuery, dbConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = selectCommand;
                DataSet customerDataset = new DataSet();
                adapter.Fill(customerDataset, "Customer");
                DataTable customerDataTable = customerDataset.Tables["Customer"];
                foreach (DataRow row in customerDataTable.Rows)
                {
                   Customer customer = new Customer
                    {
                        Name = row[0].ToString(),
                        UserName = row[1].ToString(),
                        MailId = row[2].ToString(),
                        Password = row[3].ToString(),
                        Role = row[4].ToString(),
                        CustomerID = int.Parse(row[5].ToString())
                    };
                    customerList.Add(customer.CustomerID, customer);
                }
            };

        }

    }
}
