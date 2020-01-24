using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.Entities.Seller_Entity
{
    class SellerManagement : Seller
    {
        public void viewSeller()
        {
            SellerRepositary obj = new SellerRepositary();
            obj.addSellerIntoList();
            foreach (KeyValuePair<int, Seller> seller in obj.sellerList)
            {
                Console.WriteLine("Name : {0}\nUserName : {1}\nMailID : {2}\nPhone Number : {3}\nRole : {4}\nSeller ID : {5}\n ", seller.Value.Name, seller.Value.UserName, seller.Value.MailId, seller.Value.PhoneNumber, seller.Value.Role, seller.Value.SellerID);
            }
        }
    }
}
