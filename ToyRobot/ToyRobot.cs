using System;
using ToyRobot.Enums;

namespace ToyRobot
{
    /// <summary>
    /// A robot could sitting on a flat and move around to different flat position
    /// </summary>
    public class ToyRobot : IMoveable
    {
        private FlatVector Position { get; set; }
        private readonly FlatTable _table;
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
            switch (Position.Orientation)
            {
                case Orientation.NORTH:
                    newPosition =  new FlatVector() {Xaxis = Position.Xaxis ,Yaxis = Position.Yaxis + 1, Orientation = Orientation.NORTH};
                    break;
                case Orientation.EAST:
                    newPosition = new FlatVector() { Xaxis = Position.Xaxis + 1, Yaxis = Position.Yaxis, Orientation = Orientation.EAST };
                    break;
                case Orientation.SOUTH:
                    newPosition = new FlatVector() { Xaxis = Position.Xaxis, Yaxis = Position.Yaxis - 1, Orientation = Orientation.SOUTH };
                    break;
                case Orientation.WEST:
                    newPosition = new FlatVector() { Xaxis = Position.Xaxis - 1, Yaxis = Position.Yaxis, Orientation = Orientation.WEST };
                    break;
            }

            if (_table.IsOutOfBoundary(newPosition))
            {
                throw new InvalidOperationException($"Failed Operation: [{newPosition.Xaxis},{newPosition.Yaxis}] is out of the boundary");
            }
            else
            {
                Position = newPosition;
            }
            

        }
        public void PlaceOnPosition(FlatVector position)
        {
            if (_table.IsOutOfBoundary(position))
            {
                throw new InvalidOperationException($"Failed Operation: [{position.Xaxis},{position.Yaxis}] is out of the boundary");
            }
            if(this.Position == null && position.Orientation == null)
            {
                throw new InvalidOperationException($"Failed Operation: Please specify the orientation");
            }
            this.Position = position;
        }

        public FlatVector GetCurrentPosition()
        {
            return Position;
        }

        public void RotateOrientation(RotateType rotateType)
        {
            CheckIsPlacedOnPosition();
            switch (rotateType)
            {
                case RotateType.LEFT:
                    switch (Position.Orientation)
                    {
                        case Orientation.NORTH:
                            Position.Orientation = Orientation.WEST;
                            break;
                        case Orientation.WEST:
                            Position.Orientation = Orientation.SOUTH;
                            break;
                        case Orientation.SOUTH:
                            Position.Orientation = Orientation.EAST;
                            break;
                        case Orientation.EAST:
                            Position.Orientation = Orientation.NORTH;
                            break;
                    }
                    break;
                case RotateType.RIGHT:
                    switch (Position.Orientation)
                    {
                        case Orientation.NORTH:
                            Position.Orientation = Orientation.EAST;
                            break;
                        case Orientation.EAST:
                            Position.Orientation = Orientation.SOUTH;
                            break;
                        case Orientation.SOUTH:
                            Position.Orientation = Orientation.WEST;
                            break;
                        case Orientation.WEST:
                            Position.Orientation = Orientation.NORTH;
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
