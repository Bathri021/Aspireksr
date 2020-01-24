using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.Entities.Customer_Entity
{
    class CustomerManagement
    {
        public void viewCustomer()
        {
            CustomerRepositary obj = new CustomerRepositary();
            obj.addCustomerIntoList();
            foreach (KeyValuePair<int, Customer> customer in obj.customerList)
            {
                Console.WriteLine("Name : {0}\nUserName : {1}\nMailID : {2}\nRole : {3}\nSeller ID : {4}\n ", customer.Value.Name, customer.Value.UserName, customer.Value.MailId, customer.Value.Role, customer.Value.CustomerID);
            }
        }
    }
}
