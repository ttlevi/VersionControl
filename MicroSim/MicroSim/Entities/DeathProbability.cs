using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroSim.Entities
{
    public class DeathProbability
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double P { get; set; }
    }
}
