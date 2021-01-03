using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace VitLib.Parkan
{
    internal class Constelation
    {
        private static readonly List<string> mConstelationsNames = new List<string>
        {
            "Лихо",
            "Агишер",
            "Нертис",
            "Бабир",
            "Каванах",
            "Дабог",
            "Метатрон",
            "Мориган",
            "Ярек",
            "Чистур",
            "Веллес",
            "Билкис",
            "Суглоба",
            "Англибол",
            "Теноч",
            "Вабор",
            "Оструг",
            "Хаузер",
            "Бомез",
            "Хелл",
            "Амида",
            ""
        };

        public string Name { get; }
        public IReadOnlyList<StarSystem> StarSystems { get; }
        private Constelation(string name)
        {
            Name = name;
            StarSystems = StarSystem.CreateStarSystems(Extensions.GetRandom.Next(10) + 1);
        }

        public static Constelation[] CreateConstelations(int count)
        {
            var result = new List<Constelation>();
            for (int i = 0; i < count; i++)
            {
                if (mConstelationsNames.Count <= 0) return result.ToArray();
                result.Add(CreateConstelation());
            }

            return result.ToArray();
        }

        public static Constelation CreateConstelation()
        {
            if (mConstelationsNames.Count <= 0) return null;

            string createdConstelationName = mConstelationsNames[Extensions.GetRandom.Next(mConstelationsNames.Count)];
            mConstelationsNames.Remove(createdConstelationName);
            return new Constelation(createdConstelationName);
        }
    }
}
