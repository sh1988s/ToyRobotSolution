using ToyRobot.Enums;

namespace ToyRobot.Commands
{
    public class RightCommand : ICommand
    {
        private readonly IMoveable _moveableObj;

        public RightCommand(IMoveable moveableObj)
        {
             _moveableObj = moveableObj;
        }

        public void Execute()
        {
            _moveableObj.RotateOrientation(RotateType.RIGHT);
        }
    }
}
