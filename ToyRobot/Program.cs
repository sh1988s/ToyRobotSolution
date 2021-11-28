using System;

namespace ToyRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _commandHandler = new CommandHandler(new ToyRobot(new FlatTable(5, 5)));
            bool exitApp = false;
            Console.WriteLine("Please enter commands:PLACE/MOVE/LEFT/RIGHT/REPORT, EXIT for quit");
            do
            {
                try
                {
                   
                    var cmdStr = Console.ReadLine();
                    if (cmdStr == null) continue;

                    if (cmdStr.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
                    {
                        exitApp = true;
                    }
                    else
                    {
                        _commandHandler.HandleCommand(cmdStr);
                    }
   
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine($"Invalid operation:{ex.Message}");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine($"Invalid argument:{ex.Message}");
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message);}
                
            }
            while (!exitApp);
            


            Console.ReadKey();
        





        }
    }
}
