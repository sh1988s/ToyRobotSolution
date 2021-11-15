using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;

namespace ToyRobot.Commands
{
    public abstract class Command : ICommand
    {
        public CommandType Type { get; set; }

        public Command(CommandType type,string[] args)
        {
            var _params = new List<CommandParameter>();
            Type = type;
            foreach (string paramValue in args)
            {
                _params.Add(new CommandParameter(paramValue));
            }
            Parameters = _params;
        }
        public List<CommandParameter> Parameters { get; set; }
        public abstract void Execute();

        public abstract void ValidateParams();


    }
}
