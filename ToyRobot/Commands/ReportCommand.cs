using ToyRobot.Helpers;

namespace ToyRobot.Commands
{
    internal class ReportCommand : ICommand
    {
        private readonly IMoveable _moveableObj;

        public ReportCommand(IMoveable moveableObj)
        {
            _moveableObj = moveableObj;
        }

        public void Execute()
        {
            _moveableObj.CheckIsPlacedOnPosition();
            var position = _moveableObj.GetCurrentPosition();
            CommandHelper.PrintPosition(position);
        }

    }
}
