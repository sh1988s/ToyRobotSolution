using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;

namespace ToyRobot.Commands
{
    public class RightCommand : Command
    {
        private IMoveable _moveableObj;

        public RightCommand(IMoveable moveableObj) : base(CommandType.RIGHT, new string[] { })
        {
             _moveableObj = moveableObj;
        }

        public override void Execute()
        {
            _moveableObj.RotateOrientation(RotateType.RIGHT);
        }

        public override void ValidateParams()
        {
            throw new NotImplementedException();
        }
    }
}
