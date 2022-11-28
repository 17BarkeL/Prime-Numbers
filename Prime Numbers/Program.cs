using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Prime_Numbers
{
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {

            int primes = 0;

            stopwatch.Start();

            TestInThreads(2, 0, 1000000);

            stopwatch.Stop();

            Console.WriteLine($"There are {primes} primes between {minimum} and {maximum}");
            Console.WriteLine($"Took {stopwatch.Elapsed} time");

            Console.ReadLine();
        }

        static void TestInThreads(int numberOfThreads, int minimum, int maximum)
        {
            int primes = 0;
            Task[] tasks = new Task[numberOfThreads];

            for (int j = 0; j < numberOfThreads; j++)
            {
                tasks[j] = Task.Run(() =>
                {
                    for (int i = (maximum / numberOfThreads) * j; i < (maximum / numberOfThreads) * (j + 1); i++)
                    {
                        if (IsPrime(i))
                        {
                            primes++;
                        }
                    }
                });
            }
        }

        static bool IsPrime(int number)
        {
            switch (number)
            {
                case 0:
                    return false;
                case 1:
                    return false;
                case 2:
                    return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            double numberSquareRoot = Math.Sqrt(number);

            for (int i = 3; i <= numberSquareRoot; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
