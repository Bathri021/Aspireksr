using Online_Book_Shopping___Revised.Text_Source;
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
            Console.WriteLine(Text.booktitle);
            try
            {
                title = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(title);
                if (!match.Success)
                {
                    Console.WriteLine(Text.wrongBooktitle);
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
                Console.WriteLine(Text.authorName);
                author = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(author);
                if (!match.Success)
                {
                    Console.WriteLine(Text.wrongAuthorName);
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
                Console.WriteLine(Text.Genere);
                genere = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(genere);
                if (!match.Success)
                {
                    Console.WriteLine(Text.wrongGenere);
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
                Console.WriteLine(Text.Price);
                tempPrice = Console.ReadLine();
                Regex regex = new Regex(@"\d");
                Match match = regex.Match(tempPrice);
                if (!match.Success)
                {
                    Console.WriteLine(Text.wrongPrice);
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
                Console.WriteLine(Text.NoOfPages);
                tempNoOfPages = Console.ReadLine();
                Regex regex = new Regex(@"\d");
                Match match = regex.Match(tempNoOfPages);
                if (!match.Success)
                {
                    Console.WriteLine(Text.wrongNoOfPages);
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
