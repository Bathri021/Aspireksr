using Online_Book_Shopping___Revised.Entities.Book_Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Online_Book_Shopping___Revised
{
    class Customer :User
    {
        protected internal int CustomerID;
        public Dictionary<int, Customer> customerList = new Dictionary<int, Customer>();

        public void getCustomerRegistration()
        {
            RegistrationValidation userRegister = new RegistrationValidation();
            Customer customer = new Customer {
                Name = userRegister.getName(),
                UserName = userRegister.getUserName(),
                MailId = userRegister.getMailId(),
                Role = "Customer",
                Password = userRegister.getPassword()
        };
            CustomerRepositary custRepos = new CustomerRepositary();
            if (custRepos.addCustomer(customer) == 1)
            {
                Console.WriteLine("\nCustomer Added...");
            }
            else
            {
                Console.WriteLine("\nCustomer Does Not Added...");
            }
        }

        private void viewBooks()
        {
            BookManagement bookManager = new BookManagement();
            bookManager.viewBooks();
        }

         public void accessCustomer()
        {
            getChoice:
            Console.WriteLine("\nEnter Your Choice : \n1)View Books 2)Exit");
            short temp = short.Parse(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    viewBooks();
                    goto getChoice;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
