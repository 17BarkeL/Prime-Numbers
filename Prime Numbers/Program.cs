using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            /*for (int i = 1; i < 1000; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }*/

            int input = int.Parse(Console.ReadLine());

            if (IsPrime(input))
            {
                Console.WriteLine("Prime");
            }

            else
            {
                Console.WriteLine("Not Prime");
            }

            Console.ReadLine();
        }

        static bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }

            for (int i = 2; i < number; i++)
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
