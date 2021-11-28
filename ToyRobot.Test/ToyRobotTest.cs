using System;
using ToyRobot.Enums;
using Xunit;

namespace ToyRobot.Test
{
    public class ToyRobotTest
    {
        readonly ToyRobot _robot = new(new FlatTable(5, 5));

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
        [InlineData(1, 1, Orientation.NORTH,1,2)]
        [InlineData(3, 4, Orientation.WEST,2,4)]
        [InlineData(2, 3, Orientation.SOUTH,2,2)]
        [InlineData(2, 2, Orientation.EAST,3,2)]
        public void TestMoveInsideBoudary(int xAxis, int yAxis, Orientation orientation,int expectedXAxis,int expectedYAxis)
        {
            _robot.PlaceOnPosition(new FlatVector() { Xaxis = xAxis, Yaxis = yAxis, Orientation = orientation });
            _robot.MoveForward();

            var currentPosition = _robot.GetCurrentPosition();

            Assert.Equal(expectedXAxis, currentPosition.Xaxis);
            Assert.Equal(expectedYAxis, currentPosition.Yaxis);

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
