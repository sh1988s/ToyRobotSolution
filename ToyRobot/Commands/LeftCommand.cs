using ToyRobot.Enums;

namespace ToyRobot.Commands
{
    public class LeftCommand : ICommand
    {
        private readonly IMoveable _moveableObj;

        public LeftCommand(IMoveable moveableObj) 
        {
            _moveableObj = moveableObj;
        }

        public  void Execute()
        {
            _moveableObj.RotateOrientation(RotateType.LEFT);
        }

  
    }
}
