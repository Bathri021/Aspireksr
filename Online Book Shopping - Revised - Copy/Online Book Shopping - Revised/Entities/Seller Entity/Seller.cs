

using Online_Book_Shopping___Revised.Entities;
using Online_Book_Shopping___Revised.Validation;
using System;
using System.Collections.Generic;

namespace Online_Book_Shopping___Revised
{
    class Seller : User
    {
        public Dictionary<int, Seller> sellerList = new Dictionary<int, Seller>();
        protected internal int SellerID;
        protected internal double PhoneNumber;
        int NoOfSales;

        static void initializeSellers()
        {
            SellerRepositary sellerRepos = new SellerRepositary();
            sellerRepos.addSellerIntoList();
        }
        public void getSellerRegistration()
        {
            RegistrationValidation userRegister = new RegistrationValidation();

            Seller seller = new Seller
            {
                Name = userRegister.getName(),
                UserName = userRegister.getUserName(),
                MailId = userRegister.getMailId(),
                PhoneNumber = userRegister.getPhoneNumber(),
                Role="Seller",
                Password = userRegister.getPassword()
            };
            SellerRepositary sellerRepos = new SellerRepositary();
            
            if (sellerRepos.addSeller(seller) >= 1)
            {
                Console.WriteLine("\nSeller Added...");
            }
            else
            {
                Console.WriteLine("\nSeller Does not Added...");
            }
        }

        private void addBook()
        {
            BookValidation validationObj = new BookValidation();
            Book bookObj = new Book();
            // int sellerID = 
            string title = validationObj.getBooktitle();
            string author = validationObj.getBookAuthor();
            string genere = validationObj.getBookGenere();
            int price = validationObj.getBookPrice();
            int noOfPages = validationObj.getNoOfPages();
            bookObj.getBook(title,author,genere,price,noOfPages);
        }

        public void accessSeller()
        {
            getChoice:
            Console.WriteLine("\nEnter Your Choice : \n1)Add Books 2)Exit");
            short temp = short.Parse(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    addBook();
                    goto getChoice;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
