using System;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Shopping___Revised
{
    class RegistrationValidation
    {
     
        public string getName()
        {
            string name;
            getName:
            Console.WriteLine("Enter Your Name : ");
            try
            {
                name = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(name);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid Name...!!!");
                    goto getName;
                }
                return name;
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("ArgumentNullException Occur :{0}\n{1} ", a.StackTrace, a.Message);
                goto getName;
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("ArgumentException Occur :{0}\n{1} ", a.StackTrace,a.Message);
                goto getName;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur :{0}\n{1} ", e.GetType(), e.Message);
                goto getName;
            }
        }

        public string getUserName()
        {
            string userName;
            getUserName:
            Console.WriteLine("Enter Your User Name : ");
            try
            {
                userName = Console.ReadLine();
                Regex regex = new Regex(@"^[A-Z][a-zA-Z]*$");
                Match match = regex.Match(userName);
                if (!match.Success)
                {
                    Console.WriteLine("Invalid Name...!!!");
                    goto getUserName;
                }
                return userName;
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("ArgumentNullException Occur :{0}\n{1} ", a.StackTrace, a.Message);
                goto getUserName;
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("ArgumentException Occur :{0}\n{1} ", a.StackTrace, a.Message);
                goto getUserName;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur :{0}\n{1} ", e.GetType(), e.Message);
                goto getUserName;
            }
        }

        public string getMailId()
        {
            string mailid;
            getMailId:
            Console.WriteLine("Enter Mail ID : ");
            try
            {
                mailid = Console.ReadLine();
                Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                Match match = regex.Match(mailid);
                if (!match.Success)
                {
                    Console.WriteLine("Enter Valid Mail ID...!!!");
                    goto getMailId;
                }
                return mailid;
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("ArgumentNullException Occur :{0}\n{1} ", a.StackTrace, a.Message);
                goto getMailId;
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("ArgumentException Occur :{0}\n{1} ", a.StackTrace, a.Message);
                goto getMailId;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur :{0}\n{1} ", e.GetType(), e.Message);
                goto getMailId;
            }
        }

        public double getPhoneNumber()
        {
            string tempPhoneNo;
            getPhoneNumber:
            Console.WriteLine("Enter your Phone Number");
            try
            {
                tempPhoneNo = Console.ReadLine();
                Regex regex = new Regex(@"^[0-9]{10}$");
                Match match = regex.Match(tempPhoneNo);
                if (!match.Success)
                {
                    Console.WriteLine("Please Enter Valid Phone Number...!!!");
                    goto getPhoneNumber;
                }
                double phoneNo = double.Parse(tempPhoneNo);
                return phoneNo;
            }
            catch (ArgumentNullException a)
            {
                Console.WriteLine("ArgumentNullException Occur :{0}\n{1} ", a.StackTrace, a.Message);
                goto getPhoneNumber;
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("ArgumentException Occur :{0}\n{1} ", a.StackTrace, a.Message);
                goto getPhoneNumber;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur :{0}\n{1} ", e.GetType(), e.Message);
                goto getPhoneNumber;
            }
        }

        public string getPassword()
        {
            string password;
            getPassword:
            Console.WriteLine("Enter Your Password : ");
            try
            {
                password = Console.ReadLine();
                Console.WriteLine("Again Enter Your Password to Confirm");
                string tempPassword = Console.ReadLine();
                if (password!=tempPassword)
                {
                    Console.WriteLine("Passwod is not Matching...");
                    goto getPassword;
                }
                return password;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Occur : {0}\n{1}", e.GetType(), e.Message);
                goto getPassword;
            }
        }
    }
}
