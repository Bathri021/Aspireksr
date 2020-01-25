using Online_Book_Shopping___Revised.Repositary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.LogIn_Manager
{
    class LogInManager
    {

        public void userLogIn()
        {
            CustomerRepositary custRepos = new CustomerRepositary();
            SellerRepositary sellerRepos = new SellerRepositary();
            AdminRepositary adminRepos = new AdminRepositary();

            string Role=null;
            Console.WriteLine("\n***Log-In***\n");
            Console.WriteLine("Enter User Name : ");
            string _UserName = Console.ReadLine();


            Console.WriteLine("Enter Password : ");
            string _Password = Console.ReadLine();

            try
            {
                // Add the Data Table Into the List By Calling the Method
                custRepos.addCustomerIntoList();
                sellerRepos.addSellerIntoList();
                adminRepos.addAdminIntoList();

                // Check the User Name and Password Through the foreach Loop For Every User abd Admin
                foreach (KeyValuePair<int,Customer> customer in custRepos.customerList)
                {

                    if (customer.Value.Password == _Password && customer.Value.UserName == _UserName)
                    {
                        Console.WriteLine("Login Successfull...\n");
                        Role = customer.Value.Role;
                    }

                }

                foreach (KeyValuePair<int, Seller> seller in sellerRepos.sellerList)
                {

                    if (seller.Value.Password == _Password && seller.Value.UserName == _UserName)
                    {
                        Console.WriteLine("Login Successfull...\n");
                        Role = seller.Value.Role;
                    }

                }

                foreach (KeyValuePair<int, Admin> admin in adminRepos.AdminList)
                {

                    if (admin.Value.Password == _Password && admin.Value.UserName == _UserName)
                    {
                        Console.WriteLine("Login Successfull...\n");
                        Role = admin.Value.Role;
                    }

                }

                // If Role is not Null the Control take in to the Specified Access
                if (Role != "")
                    {
                        Console.WriteLine("Welcome {0} \nAccess Granted As A {1}", _UserName, Role);
                        if (Role == "Admin")
                        {
                            Admin adminObj = new Admin();
                            adminObj.accessAdmin();
                        }
                        else if (Role == "Seller")
                        {
                            Seller sellerObj = new Seller();
                            sellerObj.accessSeller();
                        }
                        else if (Role == "Customer")
                        {
                            Customer customerObj = new Customer();
                            customerObj.accessCustomer();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Login Failed...");
                       
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine("Exception Occur : " + e.Message);
                }
           
            }
        }

    
}
