using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_Lab1_SE245
{
    class Program
    {

        static double calcWeighted(double grade1, double grade2, double grade3, double grade4)
        {
            grade1 = grade1 * 0.2;
            grade2 = grade2 * 0.2;
            grade3 = grade3 * 0.25;
            grade4 = grade4 * 0.35;

            double weightGrade = grade1 + grade2 + grade3 + grade4;

            return weightGrade;
        }

        static int calcAvg(int grade1, int grade2, int grade3, int grade4)
        {
            string ltr;
            int avg = (grade1 + grade2 + grade3 + grade4) / 4;

            return avg;
        }

        static string calcLtr(double avg)
        {
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



            String fullName, strGrade1, strGrade2, strGrade3, strGrade4, ltrGrade, weightLtr;
            Int32 intGrade1, intGrade2, intGrade3, intGrade4, intAvg;
            Double weightAvg;

            Console.WriteLine("Hello, this will calculate your grade average along with your letter grade.\n");
            Console.WriteLine("The weighting scale is as follows:\nFirst grade: 20%\nSecond grade: 20%\nThird grade: 25%\nFourth grade: 35%\n\n");

            Console.Write("Please enter your full name: ");
            fullName = Console.ReadLine();

            Console.Write("Please enter your first grade: ");
            strGrade1 = Console.ReadLine();

            Console.Write("Please enter your second grade: ");
            strGrade2 = Console.ReadLine();

            Console.Write("Please enter your third grade: ");
            strGrade3 = Console.ReadLine();

            Console.Write("Please enter your fourth grade: ");
            strGrade4 = Console.ReadLine();


            intGrade1 = Convert.ToInt32(strGrade1);
            intGrade2 = Convert.ToInt32(strGrade2);
            intGrade3 = Convert.ToInt32(strGrade3);
            intGrade4 = Convert.ToInt32(strGrade4);

            intAvg = calcAvg(intGrade1, intGrade2, intGrade3, intGrade4);
            ltrGrade = calcLtr(intAvg);
            
            weightAvg = calcWeighted(intGrade1, intGrade2, intGrade3, intGrade4);
            weightLtr = calcLtr(weightAvg);

            Console.Write($"\n\nThank you, {fullName}.\nYour unweighted average is {intAvg}, and your letter grade is a(n) {ltrGrade}\n");
            Console.Write($"Your weighted average is {weightAvg}, and your letter grade is a(n) {weightLtr}");
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();

        }

        
    }
}
