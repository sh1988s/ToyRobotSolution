using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;

namespace ToyRobot.Commands
{
    public class LeftCommand : Command
    {
        private IMoveable _moveableObj;

        public LeftCommand(IMoveable moveableObj) : base(CommandType.LEFT, new string[] { })
        {
            _moveableObj = moveableObj;
        }

        public override void Execute()
        {
            _moveableObj.RotateOrientation(RotateType.LEFT);
        }

        public override void ValidateParams()
        {
            throw new NotImplementedException();
        }
    }
}
