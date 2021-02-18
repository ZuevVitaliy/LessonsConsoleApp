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
using LessonsConsoleApp.OverrideOperators;

namespace LessonsConsoleApp
{
    public delegate void MessageHandler(double value);

    public partial class Program
    {
        static void Main(string[] args)
        {
            Human vitaliy = new Human("Виталий", Sexes.Male);
            Human julia = new Human("Юлия", Sexes.Female);
            Human vladimir = new Human("Вовка", Sexes.Male);
            Human stanislav = new Human("Стас х.", Sexes.Male);
            Human irina = new Human("Ирина Б.", Sexes.Female);
            Human elena = new Human("Ленка", Sexes.Female);

            Family family1 = vitaliy + julia;
            Family family2 = stanislav + vladimir;
            Family family3 = elena + irina;

            Console.WriteLine(family1.ToString());
            Console.WriteLine(family2.ToString());
            Console.WriteLine(family3.ToString());

            Console.ReadKey();
        }
    }
}
