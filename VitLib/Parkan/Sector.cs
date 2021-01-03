using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace VitLib.Parkan
{
    internal class Sector
    {
        public static Sector Green => new Sector("Green");
        public static Sector Red => new Sector("Red");
        public static Sector Blue => new Sector("Blue");
        public static Sector Gray => new Sector("Gray");
        public static Sector Purple => new Sector("Purple");
        public static Sector Yellow => new Sector("Yellow");

        public string Color { get; }
        public IReadOnlyList<Constelation> Constelations { get; }

        private Sector(string color)
        {
            Color = color;
            Constelations = Constelation.CreateConstelations(Extensions.GetRandom.Next(5));
        }
    }
}
