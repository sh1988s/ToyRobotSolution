using System;
using ToyRobot.Enums;

namespace ToyRobot.Helpers
{
    public static class CommandHelper
    {
        public static void ValidateOrientationType(string str)
        {
            if (!Enum.IsDefined(typeof(Orientation), str.ToUpper()))
            {
                throw new ArgumentException($"{str} is not a valid Orientation");
            }
        }

        public static void ValidateFlatPositionArg(string str)
        {
            if (!int.TryParse(str, out int intNum))
            {
                throw new ArgumentException($"{str} is not a valid integer");
            }
        }

        public static void PrintPosition(FlatVector position)
        {
            Console.WriteLine($"Output: {position.Xaxis},{position.Yaxis},{position.Orientation}");
        }
    }
}
