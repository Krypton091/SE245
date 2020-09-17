using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_Midterm_SE245
{
    class Person
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
        private string cellphone;
        private string instagramURL;

        private string feedback = "";

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

        public string Feedback
        {
            get
            {
                return feedback;
            }

            set
            {
                feedback = value;
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
                if (value.Length == 2)
                {
                    state = value;
                }

                else
                {
                    feedback += "INVALID STATE, USE 2 LETTER ABV";
                }
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
                    feedback += "INVALID ZIP, USE 5 DIGITS";
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
                    feedback += "INVALID PHONE, DON'T USE DASHES";
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
                if (Validation.IsValidEmail(value))
                {
                    email = value;
                }

                else
                {
                    feedback += "INVALID EMAIL";
                }
            }
        }

        public string Cellphone
        {
            get
            {
                return cellphone;
            }

            set
            {
                if (value.Length == 10)
                {
                    cellphone = value;
                }

                else
                {
                    cellphone += "INVALID CELL, DO NOT USE DASHES";
                }
            }
        }

        public string InstagramURL
        {
            get
            {
                return instagramURL;
            }

            set
            {
                instagramURL = value;
            }
        }
    }
}
