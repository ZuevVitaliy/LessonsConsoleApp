using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsConsoleApp.OverrideOperators
{
    public abstract class Family
    {
        public Human Husband { get; protected set; }
        public Human Wife { get; protected set; }
    }
}
