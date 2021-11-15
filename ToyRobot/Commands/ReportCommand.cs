using System;
using ToyRobot.Enums;
using ToyRobot.Helpers;

namespace ToyRobot.Commands
{
    internal class ReportCommand : Command
    {
        private IMoveable _moveableObj;

        public ReportCommand(IMoveable moveableObj) : base(CommandType.REPORT, new string[] { })
        {
            _moveableObj = moveableObj;
        }

        public override void Execute()
        {
            _moveableObj.CheckIsPlacedOnPosition();
            var position = _moveableObj.GetCurrentPosition();
            CommandHelper.PrintPosition(position);
        }

        public override void ValidateParams()
        {
            throw new NotImplementedException();
        }
    }
}
