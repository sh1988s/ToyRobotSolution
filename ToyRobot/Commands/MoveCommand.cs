namespace ToyRobot.Commands
{
    internal class MoveCommand : ICommand
    {
        private readonly IMoveable _moveableObj;

        public MoveCommand(IMoveable moveableObj) 
        {
            this._moveableObj = moveableObj;
        }

        public void Execute()
        {
            _moveableObj.MoveForward();
        }

    }
}
