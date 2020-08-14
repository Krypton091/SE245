using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_Lab2_SE245
{
    class Program
    {

        static void printLabAvg(List<int> lab1, List<int> lab2, List<int> lab3, List<int> lab4, List<int> lab5)
        {
            Console.WriteLine("The average grade for Lab One is: " + Convert.ToInt32(lab1.Average()));
            Console.WriteLine("The average grade for Lab Two is: " + Convert.ToInt32(lab2.Average()));
            Console.WriteLine("The average grade for Lab Three is: " + Convert.ToInt32(lab3.Average()));
            Console.WriteLine("The average grade for Lab Four is: " + Convert.ToInt32(lab4.Average()));
            Console.WriteLine("The average grade for Lab Five is: " + Convert.ToInt32(lab5.Average()));
        }


        static string calcLtr(ref int avgGrade)
        {
            //Take grade average and convert it into a letter grade
            string ltr;

            if (avgGrade >= 90)
            {
                ltr = "A";
            }
            else if (avgGrade >= 80 && avgGrade < 90)
            {
                ltr = "B";
            }
            else if (avgGrade >= 70 && avgGrade < 80)
            {
                ltr = "C";
            }
            else if (avgGrade >= 60 && avgGrade < 70)
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
                Console.WriteLine("The average grade for " + studentName[i] + " is: " + avgGrade + $"({calcLtr(ref avgGrade)})");
            }

            Console.WriteLine("\n\nAverage grades for each lab: ");



            printLabAvg(labOneGrade, labTwoGrade, labThreeGrade, labFourGrade, labFiveGrade);
            

            Console.Write("\nPress any key to exit");
            Console.ReadKey();
        }

    }
}
