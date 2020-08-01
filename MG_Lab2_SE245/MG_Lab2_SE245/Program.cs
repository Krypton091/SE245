using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_Lab2_SE245
{
    class Program
    {

        static string calcLtr(double avg)
        {
            //Take grade average and convert it into a letter grade
            string ltr;

            if (avg >= 90)
            {
                ltr = "A";
            }
            else if (avg >= 80 && avg < 90)
            {
                ltr = "B";
            }
            else if (avg >= 70 && avg < 80)
            {
                ltr = "C";
            }
            else if (avg >= 60 && avg < 70)
            {
                ltr = "D";
            }
            else
            {
                ltr = "F";
            }

            return ltr;
        }

        static void Main(string[] args)
        {
            //Create necessary lists/variables
            List<String> studentName = new List<String>();
            List<Int32> labOneGrade = new List<Int32>();
            List<Int32> labTwoGrade = new List<Int32>();
            List<Int32> labThreeGrade = new List<Int32>();
            List<Int32> labFourGrade = new List<Int32>();
            List<Int32> labFiveGrade = new List<Int32>();

            //strGrade used to convert entered grade into a double
            String strGrade;
            String userChoice;

            Int32 studentCount = 0;
            Int32 intGrade;
            var enterInfo = 1;

            while (enterInfo == 1)
            {

                studentCount++;

                Console.Write("Please enter student's full name: ");
                studentName.Add(Console.ReadLine());

                Console.Write("Please enter the Lab 1 grade: ");
                strGrade = Console.ReadLine();
                intGrade = Int32.Parse(strGrade);
                labOneGrade.Add(intGrade);

                Console.Write("Please enter the Lab 2 grade: ");
                strGrade = Console.ReadLine();
                intGrade = Int32.Parse(strGrade);
                labTwoGrade.Add(intGrade);

                Console.Write("Please enter the Lab 3 grade: ");
                strGrade = Console.ReadLine();
                intGrade = Int32.Parse(strGrade);
                labThreeGrade.Add(intGrade);

                Console.Write("Please enter the Lab 4 grade: ");
                strGrade = Console.ReadLine();
                intGrade = Int32.Parse(strGrade);
                labFourGrade.Add(intGrade);

                Console.Write("Please enter the Lab 5 grade: ");
                strGrade = Console.ReadLine();
                intGrade = Int32.Parse(strGrade);
                labFiveGrade.Add(intGrade);

                Console.Clear();

                Console.WriteLine("Thank you. You may now enter more students or show your results");
                Console.Write("Would you like to enter more students? [y/n]: ");
                userChoice = Console.ReadLine();



                if (userChoice == "y")
                {
                    enterInfo = 1;
                }

                else
                {
                    enterInfo = 0;
                }

            }

            Console.Clear();
            Console.WriteLine("Average grades for each student: ");

            for (int i = 0; i < studentCount; i++)
            {
                Int32 avgGrade = (labOneGrade[i] + labTwoGrade[i] + labThreeGrade[i] + labFourGrade[i] + labFiveGrade[i]) / 5;
                Console.WriteLine("The average grade for " + studentName[i] + " is: " + avgGrade + $"({calcLtr(avgGrade)})");
            }

            Console.WriteLine("\n\nAverage grades for each lab: ");

            Console.WriteLine("The average grade for Lab One is: " + Convert.ToInt32(labOneGrade.Average()));
            Console.WriteLine("The average grade for Lab Two is: " + Convert.ToInt32(labTwoGrade.Average()));
            Console.WriteLine("The average grade for Lab Three is: " + Convert.ToInt32(labThreeGrade.Average()));
            Console.WriteLine("The average grade for Lab Four is: " + Convert.ToInt32(labFourGrade.Average()));
            Console.WriteLine("The average grade for Lab Five is: " + Convert.ToInt32(labFiveGrade.Average()));

            Console.Write("Press any key to exit");
            Console.ReadKey();
        }

    }
}
