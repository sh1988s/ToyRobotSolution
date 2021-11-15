using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Commands;
using ToyRobot.Enums;

namespace ToyRobot
{
    /// <summary>
    /// A robot could sitting on a flat and move around to different flat position
    /// </summary>
    public class ToyRobot : IMoveable
    {
        private FlatVector _position { get; set; }
        private FlatTable _table;
        public ToyRobot(FlatTable flatTable)
        {
            _table  = flatTable;
        }

        /// <summary>
        /// Move forward step
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void MoveForward()
        {
            CheckIsPlacedOnPosition();
            FlatVector newPosition = null;
            switch (_position.Orientation)
            {
                case Orientation.NORTH:
                    newPosition =  new FlatVector() {Xaxis = _position.Xaxis ,Yaxis = _position.Yaxis + 1, Orientation = Orientation.NORTH};
                    break;
                case Orientation.EAST:
                    newPosition = new FlatVector() { Xaxis = _position.Xaxis + 1, Yaxis = _position.Yaxis, Orientation = Orientation.EAST };
                    break;
                case Orientation.SOUTH:
                    newPosition = new FlatVector() { Xaxis = _position.Xaxis, Yaxis = _position.Yaxis - 1, Orientation = Orientation.SOUTH };
                    break;
                case Orientation.WEST:
                    newPosition = new FlatVector() { Xaxis = _position.Xaxis - 1, Yaxis = _position.Yaxis, Orientation = Orientation.WEST };
                    break;
            }

            if (_table.IsOutOfBoundary(newPosition))
            {
                throw new InvalidOperationException($"Failed Operation: [{newPosition.Xaxis},{newPosition.Yaxis}] is out of the boundary");
            }
            else
            {
                _position = newPosition;
            }
            

        }
        public void PlaceOnPosition(FlatVector position)
        {
            if (_table.IsOutOfBoundary(position))
            {
                throw new InvalidOperationException($"Failed Operation: [{position.Xaxis},{position.Yaxis}] is out of the boundary");
            }
            if(this._position == null && position.Orientation == null)
            {
                throw new InvalidOperationException($"Failed Operation: Please specify the orientation");
            }
            this._position = position;
        }

        public FlatVector GetCurrentPosition()
        {
            return _position;
        }

        public void RotateOrientation(RotateType rotateType)
        {
            CheckIsPlacedOnPosition();
            switch (rotateType)
            {
                case RotateType.LEFT:
                    switch (_position.Orientation)
                    {
                        case Orientation.NORTH:
                            _position.Orientation = Orientation.WEST;
                            break;
                        case Orientation.WEST:
                            _position.Orientation = Orientation.SOUTH;
                            break;
                        case Orientation.SOUTH:
                            _position.Orientation = Orientation.EAST;
                            break;
                        case Orientation.EAST:
                            _position.Orientation = Orientation.NORTH;
                            break;
                    }
                    break;
                case RotateType.RIGHT:
                    switch (_position.Orientation)
                    {
                        case Orientation.NORTH:
                            _position.Orientation = Orientation.EAST;
                            break;
                        case Orientation.EAST:
                            _position.Orientation = Orientation.SOUTH;
                            break;
                        case Orientation.SOUTH:
                            _position.Orientation = Orientation.WEST;
                            break;
                        case Orientation.WEST:
                            _position.Orientation = Orientation.NORTH;
                            break;
                    }
                    break;

            }
        }

        public void CheckIsPlacedOnPosition()
        {
            if(GetCurrentPosition() == null)
            {
                throw new InvalidOperationException($"Robot not in any position at the moment, please place it first.");
            }
        }
    }
}
