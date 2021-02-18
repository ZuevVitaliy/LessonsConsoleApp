using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp.OverrideOperators
{
    public class LesbianFamily : Family
    {
        public LesbianFamily(Human human1, Human human2)
        {
            Husband = human1;
            Wife = human2;
        }

        public override string ToString()
        {
            return $"Какая-то лесбийская херня: доминаторша {Husband.Name} и пассивная {Wife.Name}";
        }
    }
}
