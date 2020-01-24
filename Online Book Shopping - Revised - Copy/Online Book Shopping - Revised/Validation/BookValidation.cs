using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised.Validation
{
    class BookValidation
    {
        public string getBooktitle()
        {
            string title;
            getTitle:
            Console.WriteLine("Enter Book Name : ");
            try
            {
                title = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(title);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid Title...!!!");
                    goto getTitle;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
                goto getTitle;
            }
            return title;
        }

        public string getBookAuthor()
        {
            string author;
            getBookAuthor:
            try
            {
                Console.WriteLine("Enter Author Name : ");
                author = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(author);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid Author Name...!!!");
                    goto getBookAuthor;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
                goto getBookAuthor;
            }
            return author;
        }

        public string getBookGenere()
        {
            string genere;
            getBookGenere:
            try
            {
                Console.WriteLine("Enter Book Genere : ");
                genere = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(genere);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid Genere...!!!");
                    goto getBookGenere;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
                goto getBookGenere;
            }
            return genere;
        }

        public int getBookPrice()
        {
            string tempPrice;
           // int price;
            getBookPrice:
            try
            {
                Console.WriteLine("Enter Book Price");
                tempPrice = Console.ReadLine();
                Regex regex = new Regex(@"\d");
                Match match = regex.Match(tempPrice);
                if (!match.Success)
                {
                    Console.WriteLine("Please Enter Valid Price...!!!");
                    goto getBookPrice;
                }
               int price = int.Parse(tempPrice);
               return price;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
                goto getBookPrice;
            }
        }

        public int getNoOfPages()
        {
            string tempNoOfPages;
            int noOfPages;
            getNoOfPages:
            try
            {
                Console.WriteLine("Enter No Of Pages : ");
                tempNoOfPages = Console.ReadLine();
                Regex regex = new Regex(@"\d");
                Match match = regex.Match(tempNoOfPages);
                if (!match.Success)
                {
                    Console.WriteLine("Please Enter Valid Pages...!!!");
                    goto getNoOfPages;
                }
                noOfPages = int.Parse(tempNoOfPages);
                return noOfPages;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : "+e.Message);
                goto getNoOfPages;
            }
        }
    }
}
