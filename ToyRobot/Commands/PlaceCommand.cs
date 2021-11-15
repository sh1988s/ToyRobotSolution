using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;
using ToyRobot.Helpers;

namespace ToyRobot.Commands
{
    public class PlaceCommand : Command
    {
        private IMoveable _moveableObj;
        public PlaceCommand(IMoveable moveableObj, string[] args) : base(CommandType.PLACE, args)
        {
            _moveableObj = moveableObj;
            this.ValidateParams();     
        }

        public override void Execute()
        {
            var targetPosition = new FlatVector() { Xaxis = int.Parse(Parameters[0].Value), Yaxis = int.Parse(Parameters[1].Value) };
            var previousPosition = _moveableObj.GetCurrentPosition();

            if( Parameters.Count > 2 )
            {               
                Enum.TryParse(Parameters[2].Value, true, out Orientation newOrientation);
                targetPosition.Orientation = newOrientation;
            }
            else if(previousPosition != null)
            {
                targetPosition.Orientation = previousPosition.Orientation;
            }

            _moveableObj.PlaceOnPosition(targetPosition);
            
        }
        
        public override void ValidateParams()
        {
            if (Parameters.Count == 3)
            {
                CommandHelper.ValidateOrientationType(Parameters[2].Value);

            }
            else if(Parameters.Count == 2)
            {
                _moveableObj.CheckIsPlacedOnPosition(); 
            }
            else
            {
                throw new ArgumentException("Wrong param number, correct format example: PLACE 1,1 or PLACE 1,1,NORTH");
            }

            CommandHelper.ValidateFlatPositionArg(Parameters[0].Value);
            CommandHelper.ValidateFlatPositionArg(Parameters[1].Value);
            
        }
    }
}
