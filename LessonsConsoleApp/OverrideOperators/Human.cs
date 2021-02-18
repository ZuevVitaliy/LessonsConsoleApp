using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp.OverrideOperators
{
    public class Human
    {
        public string Name { get; }
        public Sexes Sex { get; }

        public Human(string name, Sexes sex)
        {
            Name = name;
            Sex = sex;
        }

        public static Family operator +(Human human1, Human human2)
        {
            Human[] pair = {human1, human2};
            if (pair.All(x => x.Sex == Sexes.Male))
                return new GayFamily(human1, human2);
            if(pair.All(x=>x.Sex == Sexes.Female))
                return new LesbianFamily(human1,human2);

            if (human1.Sex == Sexes.Male)
                return new StandardFamily(human1, human2);
            return new StandardFamily(human2, human1);
        }
    }

    public enum Sexes
    {
        Male,
        Female
    }
}
