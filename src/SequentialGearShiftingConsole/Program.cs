using System;
using System.Collections.Generic;

namespace SequentialGearShiftingConsole
{
    class Program
    {
        static void PrintMainMenu()
        {
            Console.WriteLine("\tEnter n to create new bike");
            Console.WriteLine("\tEnter g to get current bike");
            Console.WriteLine("\tEnter x to exit");
            Console.Write("Selection: ");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Bicycle sequential gear shitting simulator");

            char input = '_';
            Bike myBike = new Bike();

            while (input != 'x')
            {
                PrintMainMenu();
                input = char.ToLower(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'n':
                        Console.WriteLine("\nCreating new bike");
                        var chainring = new List<int>() { 32 };
                        myBike.SetShifterRings("front", chainring);
                        var cassette = new List<int>() {11, 13, 15, 17, 19, 21, 24, 28, 32, 37, 46 };
                        myBike.SetShifterRings("rear", cassette);

                        break;

                    case 'g':
                        Console.WriteLine("\nGetting current bike");
                        Console.WriteLine($"Current bike has {myBike.GetShifter("front").GetRingCount()} chainring(s)");
                        Console.WriteLine($"Front shifter is current at {myBike.GetShifter("front").GetCurGear()+1} chainring");
                        Console.WriteLine($"Current bike has {myBike.GetShifter("rear").GetRingCount()} ring(s)");
                        Console.WriteLine($"Rear shifter is current at {myBike.GetShifter("rear").GetCurGear()+1} ring");
                        break;

                    default:
                        Console.WriteLine($"\nUnknown input char: {input}");
                        break;

                }





            }

        }
    }
}
