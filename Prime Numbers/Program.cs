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
            stopwatch.Reset();
            int primes = 0;
            int minimum = 0;
            int maximum = 10000000;
            int threads = 12;
            Task[] tasks = new Task[threads];

            stopwatch.Start();


            for (int i = 0; i < threads; i++)
            {
                tasks[i] = Task.Factory.StartNew((arg) =>
                {
                    int threadNumber = (int)arg;

                    int threadPrimes = 0;
                    int sliceSize = (maximum - minimum) / threads;
                    int threadMinimum = minimum + (sliceSize * threadNumber);
                    int threadMaximum = threadMinimum + sliceSize;

                    for (int j = threadMinimum; j < threadMaximum; j++)
                    {
                        if (IsPrime(j))
                        {
                            threadPrimes++;
                        }
                    }

                    primes += threadPrimes;
                }, i);
            }

            Task.WaitAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"There are {primes} primes between {minimum} and {maximum}");
            Console.WriteLine($"Took {stopwatch.ElapsedMilliseconds} milliseconds");

            Console.ReadLine();
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
