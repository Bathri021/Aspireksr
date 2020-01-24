using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Online_Book_Shopping___Revised
{
    class User
    {
        protected internal string Name;
        protected internal string UserName;
        protected internal string MailId;
        protected internal string Password;
        protected internal string Role;

       static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;


        public bool userLogIn()
        {
            Console.WriteLine("\n***Log-In***\n");
            Console.WriteLine("Enter User Name : ");
            string _UserName = Console.ReadLine();


            Console.WriteLine("Enter Password : ");
            string _Password = Console.ReadLine();

            SqlConnection dbConnection = new SqlConnection(connection);
            try
            {
                
                // Login For Customers
                string command = "spCheckUserNameandPassword";  // Stored Procedure
                using(SqlCommand selectcommandOne = new SqlCommand(command, dbConnection))
                 {
                   selectcommandOne.CommandType = CommandType.StoredProcedure;
                   selectcommandOne.Parameters.AddWithValue("@_UserName", _UserName); // Add Parameters
                   selectcommandOne.Parameters.AddWithValue("@_Password", _Password); // Add Parameters

                    //Add the output parameter to the command object
                    selectcommandOne.Parameters.Add("@_Role", SqlDbType.VarChar, 10);  // Add Output Parameter 
                    selectcommandOne.Parameters["@_Role"].Direction = ParameterDirection.Output;

                    dbConnection.Open();

                    // SqlDataAdapter sqldataAdapter = new SqlDataAdapter();

                    int temp = selectcommandOne.ExecuteNonQuery();

                    dbConnection.Close();
                    string Role = null;
                    Role = Convert.ToString(selectcommandOne.Parameters["@_Role"].Value);

                    if (Role!="")
                    {
                        Console.WriteLine("Welcome {0} \nAccess Granted As A {1}" , _UserName,Role);
                        if (Role=="Admin")
                        {
                            Admin adminObj = new Admin();
                            adminObj.accessAdmin();
                        }
                        else if (Role=="Seller")
                        {
                            Seller sellerObj = new Seller();
                            sellerObj.accessSeller();
                        }
                        else if (Role=="Customer")
                        {
                            Customer customerObj = new Customer();
                            customerObj.accessCustomer();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Login Failed...");
                        dbConnection.Close();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
                return false;
            }
            finally
            {
                dbConnection.Close();
            }

            return false;
        }
    }
}
