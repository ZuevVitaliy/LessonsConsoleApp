using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp.OverrideOperators
{
    public class GayFamily : Family
    {
        public GayFamily(Human human1, Human human2)
        {
            Husband = human1;
            Wife = human2;
        }

        public override string ToString()
        {
            return $"Какая-то гейская хуйня: типа муж {Husband.Name} и типа жена {Wife.Name}";
        }
    }
}
