using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_FinalExam_SE245
{
    class Student
    {
        private string fName;
        private string lName;
        private double gpa;
        private int credits;
        private DateTime dob;

        protected string feedback = "";

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

        public double GPA
        {
            get
            {
                return gpa;
            }

            set
            {
                if (value >= 0 && value <= 4)
                {
                    gpa = value;
                }

                else
                {
                    feedback += "ERROR: Invalid GPA, enter a number between 0 and 4.0";
                }
            }
        }

        public int Credits
        {
            get
            {
                return credits;
            }

            set
            {
                credits = value;
            }

        }

        public DateTime DOB
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
            }
        }


    }
}
