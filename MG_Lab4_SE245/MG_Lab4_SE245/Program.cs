using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace MG_Lab4_SE245
{
    class Program
    {
        public class Person
        {
            private string fName;
            private string mName;
            private string lName;
            private string street1;
            private string street2;
            private string city;
            private string state;
            private string zipcode;
            private string phone;
            private string email;

            public string FName
            {
                get
                {
                    return fName;
                }

                set
                {
                    fName = value;
                }
            }

            public string MName
            {
                get
                {
                    return mName;
                }

                set
                {
                    mName = value;
                }
            }

            public string LName
            {
                get
                {
                    return lName;
                }

                set
                {
                    lName = value;
                }
            }

            public string Street1
            {
                get
                {
                    return street1;
                }

                set
                {
                    street1 = value;
                }
            }

            public string Street2
            {
                get
                {
                    return street2;
                }

                set
                {
                    street2 = value;
                }
            }

            public string City
            {
                get
                {
                    return city;
                }

                set
                {
                    city = value;
                }
            }

            public string State
            {
                get
                {
                    return state;
                }

                set
                {
                    state = value;
                }
            }

            public string Zipcode
            {
                get
                {
                    return zipcode;
                }

                set
                {
                    if (value.Length == 5)
                    {
                        zipcode = value;
                    }
                    
                    else
                    {
                        zipcode = "INVALID";
                    }
                }
            }

            public string Phone
            {
                get
                {
                    return phone;
                }

                set
                {
                    if (value.Length == 10)
                    { 
                        phone = value;
                    }
                    
                    else
                    {
                        phone = "INVALID";
                    }    
                }
            }

            public string Email
            {
                get
                {
                    return email;
                }

                set
                {
                    if (value.Length > 8)
                    {
                        email = value;
                    }

                    else
                    {
                        email = "INVALID";
                    }    
                }
            }


        }

        static void Main(string[] args)
        {

            string answer;
            //This boolean allows us to display a second street address, but only when it's actually used
            Boolean hasStreet2 = false;

            Person temp = new Person();

            //Here we enter a bunch of information at once

            Console.Write("Please enter your First Name: ");
            temp.FName = Console.ReadLine();
            
            Console.Write("Please enter your Middle Name: ");
            temp.MName = Console.ReadLine();

            Console.Write("Please enter your Last Name: ");
            temp.LName = Console.ReadLine();

            Console.Write("Please enter your Street Address: ");
            temp.Street1 = Console.ReadLine();

            Console.WriteLine("Do you have a second Street Address? [y/n]: ");
            answer = Console.ReadLine();

            //If the user states they have a second address, prompt them to enter it

            if (answer == "y" || answer == "yes")
            {
                Console.Write("Please enter your 2nd Street Address: ");
                temp.Street2 = Console.ReadLine();
                hasStreet2 = true;
            }

            Console.Write("Please enter your City: ");
            temp.City = Console.ReadLine();

            Console.Write("Please enter your State: ");
            temp.State = Console.ReadLine();

            Console.Write("Please enter your Zipcode: ");
            temp.Zipcode = Console.ReadLine();

            Console.Write("Please enter your Phone Number: ");
            temp.Phone = Console.ReadLine();

            Console.Write("Please enter your Email Address: ");
            temp.Email = Console.ReadLine();

            ////////////////////////////
            //Printing out information//
            ////////////////////////////

            Console.Clear();

            Console.Write($"\n First Name: {temp.FName}");
            Console.Write($"\n Middle Name: {temp.MName}");
            Console.Write($"\n Last Name: {temp.LName}");
            Console.Write($"\n Street Address: {temp.Street1}");

            //Only print out the second address if it actually exists

            if (hasStreet2 == true)
            {
                Console.Write($"\n Street Address 2: {temp.Street2}");
            }
            
            Console.Write($"\n City: {temp.City}");
            Console.Write($"\n State: {temp.State}");
            Console.Write($"\n Zipcode: {temp.Zipcode}");
            Console.Write($"\n Phone Number: {temp.Phone}");
            Console.Write($"\n Email Address: {temp.Email}");

            Console.Write("\n\nPress any key to end program");
            Console.ReadKey();
        }
    }
}
