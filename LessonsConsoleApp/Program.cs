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
using LessonsConsoleApp.OverrideEquals;
using LessonsConsoleApp.OverrideOperators;

namespace LessonsConsoleApp
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(10, new Point(3,4));
            Circle circle2 = new Circle(10, new Point(3,4));

            Console.WriteLine(circle1.Equals(circle2));

            Console.ReadKey();
        }
    }
}
