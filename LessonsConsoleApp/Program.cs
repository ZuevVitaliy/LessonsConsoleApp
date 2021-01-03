using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LessonsConsoleApp
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //VitProgram.Start(); глянуть на потом
            //List<Ship> listOfShips = new List<Ship>();
            //listOfShips.Add(new D_Cruiser());
            //listOfShips.Add(new A_Cruiser());
            //foreach (var ship in listOfShips)
            //{
            //    Console.WriteLine(ship.ClanName);
            //}
            //Console.ReadKey();
            while (true)
            {

                Console.WriteLine("Введите аргументы: ");
                double a, b, c;
                Console.Write("a = ");
                try
                {
                    a = double.Parse(Console.ReadLine());

                    Console.Write("b = ");

                    b = double.Parse(Console.ReadLine());
                    Console.Write("c = ");

                    c = double.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Вы ввели не число.");
                    Console.ReadKey();
                    return;
                }

                double x1 = ((-b + Math.Sqrt(FindDiscriminant(a, b, c))) / (2 * a));
                double x2 = ((-b - Math.Sqrt(FindDiscriminant(a, b, c))) / (2 * a));
                if (FindDiscriminant(a, b, c) < 0)
                {
                    Console.WriteLine("Корней нет");
                }
                else if (FindDiscriminant(a, b, c) == 0)
                {
                    double x = x1;
                    Console.WriteLine("x =" + x);
                }
                else
                {
                    Console.WriteLine("x1 = " + x1);
                    Console.WriteLine("x2 = " + x2);
                }
                Console.ReadKey();
            }
        }

        public static double FindDiscriminant(double arg1, double arg2, double arg3)
        {
            double D = Math.Pow(arg2,2) - 4 * arg1 * arg3;
            return D;
        }

        public class Student
        {
            private string mName;
            private int mCourse;
            private bool mStudentship;

            public Student()
            {
                this.mName = "";
                this.mCourse = 0;
                this.mStudentship = false;
            }

            public Student(string name, int course, bool studentship)
            {
                this.mName = name;
                if (course < 1)
                {
                    this.mCourse = 1;

                }
                else if (course > 6)
                {
                    this.mCourse = 6;
                }
                else
                {
                    this.mCourse = course;
                }
                this.mStudentship = studentship;
            }
        }
       
    }
}
