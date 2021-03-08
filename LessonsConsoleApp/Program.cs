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

            Console.WriteLine(family1);
            Console.WriteLine(family2);
            Console.WriteLine(family3);

            Console.ReadKey();
        }
    }
    public class Money
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }

        public Money(decimal amount, string unit)
        {
            Amount = amount;
            Unit = unit;
        }
        public static Money operator +(Money a, Money b)
        {
            if (a.Unit != b.Unit)
                throw new InvalidOperationException("Нельзя суммировать деньги в разных валютах");

            return new Money(a.Amount + b.Amount, a.Unit);
        }
        public static Money operator ++(Money a) // перегрузка «++»
        {
            a.Amount++;
            return a;
        }
        public static Money operator --(Money a) // перегрузка «--»
        {
            a.Amount--;
            return a;
        }

    }
}
