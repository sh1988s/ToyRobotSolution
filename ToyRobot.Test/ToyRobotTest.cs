using System;
using ToyRobot.Enums;
using Xunit;

namespace ToyRobot.Test
{
    public class ToyRobotTest
    {
        readonly ToyRobot _robot = new(new FlatTable(6, 6));

        [Fact]
        public void TestPlaceInsideBoudary()
        {
            _robot.PlaceOnPosition(new FlatVector() { Xaxis = 0, Yaxis = 0, Orientation = Orientation.NORTH });
            var currentPosition = _robot.GetCurrentPosition();

            Assert.Equal(0, currentPosition.Xaxis);
            Assert.Equal(0, currentPosition.Yaxis);
            Assert.Equal(Orientation.NORTH, currentPosition.Orientation);
        }

        [Fact]
        public void TestPlaceOutsideBoudary()
        {
            Assert.Throws<InvalidOperationException>(() => _robot.PlaceOnPosition(new FlatVector() { Xaxis = 6, Yaxis = 5, Orientation = Orientation.NORTH }));

        }

        [Theory]
        [InlineData(1, 1, Orientation.NORTH)]
        [InlineData(3, 4, Orientation.WEST)]
        [InlineData(2, 3, Orientation.SOUTH)]
        [InlineData(2, 2, Orientation.EAST)]
        public void TestMoveInsideBoudary(int xAxis, int yAxis, Orientation orientation)
        {
            _robot.PlaceOnPosition(new FlatVector() { Xaxis = xAxis, Yaxis = yAxis, Orientation = orientation });
            _robot.MoveForward();

            var currentPosition = _robot.GetCurrentPosition();

            switch (orientation)
            {
                case Orientation.NORTH:
                    Assert.Equal(xAxis, currentPosition.Xaxis);
                    Assert.Equal(yAxis + 1, currentPosition.Yaxis);
                    break;
                case Orientation.WEST:
                    Assert.Equal(xAxis - 1, currentPosition.Xaxis);
                    Assert.Equal(yAxis, currentPosition.Yaxis);
                    break;
                case Orientation.SOUTH:
                    Assert.Equal(xAxis, currentPosition.Xaxis);
                    Assert.Equal(yAxis - 1, currentPosition.Yaxis);
                    break;
                case Orientation.EAST:
                    Assert.Equal(xAxis + 1, currentPosition.Xaxis);
                    Assert.Equal(yAxis, currentPosition.Yaxis);
                    break;

            }
            Assert.Equal(orientation, currentPosition.Orientation);
        }

        [Fact]
        public void TestMoveOutsideBoudary()
        {
            _robot.PlaceOnPosition(new FlatVector() { Xaxis = 5, Yaxis = 5, Orientation = Orientation.NORTH });
            Assert.Throws<InvalidOperationException>(() => _robot.MoveForward());

            var currentPosition = _robot.GetCurrentPosition();

            Assert.Equal(5, currentPosition.Xaxis);
            Assert.Equal(5, currentPosition.Yaxis);
            Assert.Equal(Orientation.NORTH, currentPosition.Orientation);
        }

        [Theory]
        [InlineData(1, 1, Orientation.NORTH, RotateType.LEFT, Orientation.WEST)]
        [InlineData(1, 1, Orientation.NORTH, RotateType.RIGHT, Orientation.EAST)]
        [InlineData(1, 1, Orientation.WEST, RotateType.LEFT, Orientation.SOUTH)]
        [InlineData(1, 1, Orientation.WEST, RotateType.RIGHT, Orientation.NORTH)]
        [InlineData(1, 1, Orientation.SOUTH, RotateType.LEFT, Orientation.EAST)]
        [InlineData(1, 1, Orientation.SOUTH, RotateType.RIGHT, Orientation.WEST)]
        [InlineData(1, 1, Orientation.EAST, RotateType.LEFT, Orientation.NORTH)]
        [InlineData(1, 1, Orientation.EAST, RotateType.RIGHT, Orientation.SOUTH)]
        public void TestRotate(int xAxis, int yAxis, Orientation orientation, RotateType rotateType, Orientation expectedOrientation)
        {
            _robot.PlaceOnPosition(new FlatVector() { Xaxis = xAxis, Yaxis = yAxis, Orientation = orientation });
            _robot.RotateOrientation(rotateType);
            var currentPosition = _robot.GetCurrentPosition();

            Assert.Equal(xAxis, currentPosition.Xaxis);
            Assert.Equal(yAxis, currentPosition.Yaxis);
            Assert.Equal(expectedOrientation, currentPosition.Orientation);

        }
    }

}
