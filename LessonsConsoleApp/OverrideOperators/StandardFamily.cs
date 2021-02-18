using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp.OverrideOperators
{
    public class StandardFamily : Family
    {
        public StandardFamily(Human human1, Human human2)
        {
            Husband = human1;
            Wife = human2;
        }

        public override string ToString()
        {
            return $"Семья: муж {Husband.Name} и жена {Wife.Name}";
        }
    }
}
