﻿using System;
using System.Collections.Generic;

namespace SequentialGearShiftingConsole
{
    class Program
    {
        static void PrintMainMenu()
        {
            Console.WriteLine("Bicycle sequential gear shitting simulator");
            Console.WriteLine("\tEnter n to create new bike");
            Console.WriteLine("\tEnter g to get current bike");
            Console.WriteLine("\tEnter x to exit");
            Console.Write("Selection: ");
        }

        //static void PrintGearCombinations(IGearBox gearBox)
        //{
        //    foreach (var t in gearBox.Gears)
        //    {
        //        Console.WriteLine($"Gear ratio {t.Ratio} can be generated by the following combinations");
        //        foreach(int[] combination in t.Combinations)
        //        {
        //            Console.WriteLine($"\tFront: {combination[0]}, Rear: {combination[1]}");
        //        }
        //    }
        //}

        static void Main(string[] args)
        {
            char input = '_';

            //RingSet chainring = new RingSet {Rings = new int[]{} };
            //RingSet cassette = new RingSet {Rings = new int[]{} };

            //Bike myBike = new Bike();
            Drivetrain myDrivetrain;

            while (input != 'x')
            {
                PrintMainMenu();
                input = char.ToLower(Console.ReadKey().KeyChar);

                switch (input)
                {
                    case 'n':
                        Console.WriteLine("\nCreating new bike");
                        var chainring = new int[] { 32, 22 };
                        var cassette = new int[] { 24, 36, 40 };
                        myDrivetrain = new Drivetrain(chainring, cassette);
                        Console.WriteLine($"\tGears: ");
                        foreach(var gear in myDrivetrain._gears._gearRatios)
                            Console.WriteLine($"\t\t{gear}");
                        for(int i=0; i< myDrivetrain._gears._gearRatios.Length; i++)
                            Console.WriteLine($"\t\t{myDrivetrain._gears._gearRatios[i]}");
                        Console.WriteLine($"\tCurrent Combination: {myDrivetrain.CurrentGearCombination()[0]} : {myDrivetrain.CurrentGearCombination()[1]}");
                        //myBike.SetBike(chainring, cassette);
                        //PrintGearCombinations(myBike.GetGearBox());
                        break;

                    case 'g':
                        Console.WriteLine("\nGetting current bike");
                        //Console.WriteLine($"Current bike has {myBike.GetShifterRingCounts("front")} chainring(s)");
                        //Console.WriteLine($"Front shifter is current at {myBike.GetShifter("front").CurPos+1} chainring");
                        //Console.WriteLine($"Current bike has {myBike.GetShifterRingCounts("rear")} ring(s)");
                        //Console.WriteLine($"Rear shifter is current at {myBike.GetShifter("rear").CurPos+1} ring");
                        //PrintGearCombinations(myBike.GetGearBox());
                        break;

                    default:
                        Console.WriteLine($"\nUnknown input char: {input}");
                        break;

                }





            }

        }
    }
}
