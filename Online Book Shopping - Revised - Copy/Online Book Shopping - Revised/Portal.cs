
using Online_Book_Shopping___Revised.Entities;
using Online_Book_Shopping___Revised.Entities.Book_Entity;
/**
* Class : Online Book Shopping System [Project]
* Version :Visual Studio 2015
* Date : 21-01-2020
* Author : N.Bathri
**/
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


            Console.WriteLine("Enter Your Option : \n1)Registration \n2)Login \n3)Exit\n");
            short userOption= short.Parse(Console.ReadLine());
            switch (userOption)
            {
                case 1:
                    Console.WriteLine("Enter Your Type Of User Registration :\n1)Customer \n2)Seller");
                    short temp = Int16.Parse(Console.ReadLine());
                    if (temp==1)
                    {
                        customerObj = new Customer();
                        customerRepositary = new CustomerRepositary();
                        customerObj.getCustomerRegistration();
                        customerObj.Role = "Customer";
                        User user1 = new User();
                        user1.userLogIn();
                    }
                    else if (temp==2)
                    {

                        sellRepositary = new SellerRepositary();
                        sellerObj = new Seller();
                        sellerObj.getSellerRegistration();
                        sellerObj.Role = "Seller";
                        User user2 = new User();
                        user2.userLogIn();
                    }
                    break;
                case 2:
                    User user = new User();
                    if (user.userLogIn())
                    {
                       // Console.WriteLine("There is no matching Username and Password in the List...");
                    }
                    break;
                case 3:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            Console.WriteLine("If you want to continue Enter: yes");
            bool istrue = (Console.ReadLine() == "yes");
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
   