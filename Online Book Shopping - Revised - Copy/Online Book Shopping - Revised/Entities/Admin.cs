using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using Online_Book_Shopping___Revised.Entities.Seller_Entity;
using Online_Book_Shopping___Revised.Entities.Customer_Entity;

namespace Online_Book_Shopping___Revised
{
    class Admin
    {
        protected internal string Name;
        protected internal string UserName;
        protected internal string MailId;
        protected internal double PhoneNumber;
        protected internal string Password;
        protected internal string Role;
        protected internal int AdminID;

        public Dictionary<int, Admin> AdminList = new Dictionary<int, Admin>();
        protected internal void viewCustomers()
        {
            CustomerManagement customerManager = new CustomerManagement();
            customerManager.viewCustomer();
        }

        protected internal void viewSeller()
        {
            SellerManagement sellerManager = new SellerManagement();
            sellerManager.viewSeller();
        }

        internal void accessAdmin()
        {
            getChoice:
            Console.WriteLine("Enter Your Choice : \n1)View Customer \n2)View Seller \n3)Exit");
            short temp = short.Parse(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    viewCustomers();
                    goto getChoice;
                case 2:
                    viewSeller();
                    goto getChoice;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
