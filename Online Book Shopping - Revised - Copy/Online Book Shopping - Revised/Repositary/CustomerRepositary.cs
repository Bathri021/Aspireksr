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
        
        public int addCustomer(Customer customer)
        {
            int rows;
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
                  rows = insertcommand.ExecuteNonQuery();  // Execute the Insert Query
                  
                }
                addCustomerIntoList();
                return rows;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
                return 0;
            }

            finally
            {
                dbConnection.Close();
            }
             
         }

        public void addCustomerIntoList()  // Add the customer Details into the list
        {
            string sqlQuery = "Select * From Customer";
            using (SqlCommand selectCommand = new SqlCommand(sqlQuery, dbConnection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = selectCommand;
                DataSet customerDataset = new DataSet();
                adapter.Fill(customerDataset, "Customer");
                DataTable customerDataTable = customerDataset.Tables["Customer"];
                // Iterate through the Data table to fetch the Row 
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
                    customerList.Add(customer.CustomerID, customer);  // Add into the List
                }
            };

        }

    }
}
