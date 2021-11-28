using System;
using ToyRobot.Enums;
using ToyRobot.Helpers;

namespace ToyRobot.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly IMoveable _moveableObj;
        private readonly string[] _parameterValues;
        public PlaceCommand(IMoveable moveableObj, string[] args)
        {
            _moveableObj = moveableObj;
            _parameterValues = args;
            this.ValidateParams();     
        }

        public void Execute()
        {
            var targetPosition = new FlatVector() { Xaxis = int.Parse(_parameterValues[0]), Yaxis = int.Parse(_parameterValues[1]) };
            var previousPosition = _moveableObj.GetCurrentPosition();

            if(_parameterValues.Length > 2 )
            {               
                Enum.TryParse(_parameterValues[2], true, out Orientation newOrientation);
                targetPosition.Orientation = newOrientation;
            }
            else if(previousPosition != null)
            {
                targetPosition.Orientation = previousPosition.Orientation;
            }

            _moveableObj.PlaceOnPosition(targetPosition);
            
        }
        /// <summary>
        /// Validate the the place params
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void ValidateParams()
        {
            if (_parameterValues.Length == 3)
            {
                CommandHelper.ValidateOrientationType(_parameterValues[2]);

            }
            else if(_parameterValues.Length == 2)
            {
                _moveableObj.CheckIsPlacedOnPosition(); 
            }
            else
            {
                throw new ArgumentException("Wrong param number, correct format example: PLACE 1,1 or PLACE 1,1,NORTH");
            }

            CommandHelper.ValidateFlatPositionArg(_parameterValues[0]);
            CommandHelper.ValidateFlatPositionArg(_parameterValues[1]);
            
        }
    }
}
