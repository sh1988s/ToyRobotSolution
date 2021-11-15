using ToyRobot.Enums;

namespace ToyRobot
{
    public interface IMoveable
    {
        void MoveForward();
        FlatVector GetCurrentPosition();

        void RotateOrientation(RotateType rotateType);

        void PlaceOnPosition(FlatVector position);

        void CheckIsPlacedOnPosition();
    }
}
