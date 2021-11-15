using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;
using ToyRobot.Helpers;

namespace ToyRobot.Commands
{
    internal class MoveCommand : Command
    {
        private IMoveable _moveableObj;

        public MoveCommand(IMoveable moveableObj) : base(CommandType.MOVE, new string[] { })
        {
            this._moveableObj = moveableObj;
        }

        public override void Execute()
        {
            _moveableObj.MoveForward();
        }


        public override void ValidateParams()
        {
            throw new NotImplementedException();
        }
    }
}
