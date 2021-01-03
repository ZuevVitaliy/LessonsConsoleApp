using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitLib.Parkan
{
    internal class StarSystem
    {
        private static readonly List<string> mStarsNames= new List<string>
        {
            "alpha",
            "beta",
            "gamma",
            "delta",
            "epsilon",
            "zeta",
            "eta",
            "theta",
            "iota",
            "kappa"
        };

        public string Name { get; }
        private StarSystem(string name)
        {
            Name = name;
        }

        public static StarSystem[] CreateStarSystems(int count)
        {
            return mStarsNames.Take(count).Select(x => new StarSystem(x)).ToArray();
        }
    }
}
