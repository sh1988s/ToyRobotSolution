using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;

namespace ToyRobot
{
    /// <summary>
    /// Class represents the position on a flat with x and y axis
    /// </summary>
    public class FlatVector
    {
        public int Xaxis { get; set; }
        public int Yaxis { get; set; }

        public Orientation? Orientation {get;set;}

    }
}
