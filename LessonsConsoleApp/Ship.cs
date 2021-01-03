using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp
{
    public class Ship
    {
        public bool IsWeaponEnabled { get; set; }
        public bool IsComputerEnabled { get; set; }
        public bool IsRadarEnabled { get; set; }
        public bool IsEngineEnabled { get; set; }
        public bool IsManeuverEnabled { get; set; }
        public bool IsCrewEnabled { get; set; }
        public bool IsDefenseEnabled { get; set; }
        public string ClanName { get; set; }

        public Ship()
        {
            IsComputerEnabled = true;
            IsWeaponEnabled = true;
            IsRadarEnabled = true;
            IsEngineEnabled = true;
            IsManeuverEnabled = true;
            IsCrewEnabled = true;
            IsDefenseEnabled = true;
        }

    }

    public class A_Cruiser : Ship
    {
        public A_Cruiser()
        {
            ClanName = "Astron";
        }
    }

    public class D_Cruiser : Ship
    {
        public D_Cruiser()
        {
            ClanName = "Dagger";
        }
    }
}
