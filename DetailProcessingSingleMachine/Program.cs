using System;
using System.Collections.Generic;
using System.Linq;

namespace DetailProcessingSingleMachine
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var count = 0;
                var minTime = 0;
                var maxTime = 0;
                var minFine = 0;
                var maxFine = 0;

                ReadSettings(out count, out  minTime, out maxTime, out minFine, out maxFine);

                var details = new Detail[count];
                for (var i = 0; i < details.Length; i++)
                    details[i] = new Detail(minTime, maxTime, minFine, maxFine);

                var machine = new Machine(details.ToList());
                Console.WriteLine("UNSORTED");
                machine.PrintDetails();
                machine.SortDetails();
                Console.WriteLine("SORTED");
                machine.PrintDetails();

                Console.WriteLine("Press any key for restart");
                Console.ReadKey();
            }
        }

        private static void ReadSettings(out int count, out int minTime, out int maxTime, out int minFine, out int maxFine)
        {
            while (true)
            {
                Console.WriteLine("Details Count: ");
                if (!int.TryParse(Console.ReadLine(), out count))
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input");
                    continue;
                }

                Console.WriteLine("Min Detail Processing Time: ");
                if (!int.TryParse(Console.ReadLine(), out minTime))
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input");
                    continue;
                }

                Console.WriteLine("Max Detail Processing Time: ");
                if (!int.TryParse(Console.ReadLine(), out maxTime))
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input");
                    continue;
                }

                if (minTime > maxTime)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input (min > max)");
                    continue;
                }

                Console.WriteLine("Min Detail Idle Fine: ");
                if (!int.TryParse(Console.ReadLine(), out minFine))
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input");
                    continue;
                }

                Console.WriteLine("Max Detail Idle Fine: ");
                if (!int.TryParse(Console.ReadLine(), out maxFine))
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input");
                    continue;
                }

                if (minFine > maxFine)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Input (min > max)");
                    continue;
                }
                
                break;
            }
        }
    }
}