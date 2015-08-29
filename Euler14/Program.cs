using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler14
{
    class Program
    {
        static Dictionary<uint, uint> chainLengths;

        static void Main(string[] args)
        {
            chainLengths = new Dictionary<uint, uint>();
            chainLengths.Add(1, 1);

            uint maxIndex = 1;
            uint maxLen = 1;

            foreach (uint i in Enumerable.Range(2, 999999)) {
                uint len = CollatzLength(i);
                if(len > maxLen)
                {
                    maxLen = len;
                    maxIndex = i;
                }
            }

            Console.WriteLine("Max length is " + maxLen + " at index " + maxIndex);
            Console.ReadLine();
        }

        static uint CollatzLength(uint n)
        {
            if (n == 1)
                return 1;

            if (chainLengths.ContainsKey(n))
                return chainLengths[n];

            uint next;

            if (n % 2 == 0)
                next = n / 2;
            else
                next = 3 * n + 1;

            uint len = 1 + CollatzLength(next);
            chainLengths.Add(n, len);
            return len;
        }
    }
}
