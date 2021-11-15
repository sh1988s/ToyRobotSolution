using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Commands
{
    public class CommandParameter
    {

        public CommandParameter(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
    }
}
