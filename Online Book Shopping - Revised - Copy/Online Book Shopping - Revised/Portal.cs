/**
* Class : Online Book Shopping System [Project]
* Version :Visual Studio 2015
* Date : 25-01-2020
* Author : N.Bathri
**/

using Online_Book_Shopping___Revised.Entities;
using Online_Book_Shopping___Revised.Entities.Book_Entity;
using Online_Book_Shopping___Revised.LogIn_Manager;
using Online_Book_Shopping___Revised.Text_Source;
using System;


namespace Online_Book_Shopping___Revised
{
      
    class Portal
    {
     
        public static void getUserChoice()
        {
            CustomerRepositary customerRepositary;
            Customer customerObj;
            Seller sellerObj;
            SellerRepositary sellRepositary;
            LogInManager loginObj = new LogInManager();

            Console.WriteLine(Text.FirstOption);
            short userOption= short.Parse(Console.ReadLine());
            switch (userOption)
            {
                case 1:
                    Console.WriteLine(Text.SecondOption);
                    short temp = Int16.Parse(Console.ReadLine());
                    if (temp==1)
                    {
                        customerObj = new Customer();
                        customerRepositary = new CustomerRepositary();
                        customerObj.getCustomerRegistration();
                        customerObj.Role = "Customer";
                        loginObj.userLogIn();
                    }
                    else if (temp==2)
                    {

                        sellRepositary = new SellerRepositary();
                        sellerObj = new Seller();
                        sellerObj.getSellerRegistration();
                        sellerObj.Role = "Seller";
                        loginObj.userLogIn();
                    }
                    break;
                case 2:
                    loginObj.userLogIn();
                    break;
                case 3:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.WriteLine(Text.ThirdOption);
            bool istrue = (Console.ReadLine() == "yes" || Console.ReadLine() == "Yes" || Console.ReadLine() == "YES");
            if (istrue)
            {
                getUserChoice();
            }
        } 

        static void Main(string[] args)
        {
                BookManagement bookObj = new BookManagement();
            Console.WriteLine("******Welcome To Online Book Shopping System******\n");
            bookObj.viewBooks();
            getUserChoice();
        }
    }
}
   