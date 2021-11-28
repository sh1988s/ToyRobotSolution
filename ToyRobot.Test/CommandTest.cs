using Moq;
using System;
using ToyRobot.Commands;
using ToyRobot.Enums;
using Xunit;

namespace ToyRobot.Test
{
    public class CommandTest
    {

        [Theory]
        [InlineData("a","0","north")]
        [InlineData("1", "a", "north")]
        [InlineData("1", "1", "northwest")]
        public void TestPlaceCommand_Params_Validation(string param1,string param2,string param3)
        {
            var mockMoveable = new Mock<IMoveable>();
            Assert.Throws<ArgumentException>(() => new PlaceCommand(mockMoveable.Object, new string[] { param1, param2, param3 }));
         
        }


        [Fact]
        public void TestPlaceCommand_NotChangingOrientation()
        {
            var _robot = new Mock<IMoveable>();
            var cmd = new PlaceCommand(_robot.Object, new string[] { "3","3"});
            
            _robot.Setup(_ => _.GetCurrentPosition()).Returns(new FlatVector() { Xaxis =0, Yaxis =0, Orientation = Orientation.NORTH });
        
            cmd.Execute();

            Assert.Equal(Orientation.NORTH, _robot.Object.GetCurrentPosition().Orientation);
           
        }

        [Fact]
        public void TestPlaceCommand_ChangingOrientation()
        {
            var _robot = new Mock<IMoveable>();
            var cmd = new PlaceCommand(_robot.Object, new string[] { "3", "3","west" });

            _robot.Setup(_ => _.GetCurrentPosition()).Returns(new FlatVector() { Xaxis = 0, Yaxis = 0, Orientation = Orientation.NORTH });
            _robot.Setup(_ => _.PlaceOnPosition(It.IsAny<FlatVector>())).Verifiable();
            cmd.Execute();
            _robot.Setup(_ => _.GetCurrentPosition()).Returns(new FlatVector() { Xaxis = 3, Yaxis = 3, Orientation = Orientation.WEST });

            Assert.Equal(Orientation.WEST, _robot.Object.GetCurrentPosition().Orientation);

        }
    }
}
