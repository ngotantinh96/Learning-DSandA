﻿using System.Numerics;

namespace AlgorithmicToolbox
{
    public class Fibonacci
    {
        public static void ExecuteTesting()
        {
            var input = Console.ReadLine();
            Console.WriteLine(MemoryEfficientFibonacci(long.Parse(input)));
        }

        public static long EfficientFibonacci(long input)
        {
            if (input <= 1) return input;

            long[] fiboNumbers = new long[input + 1];
            fiboNumbers[0] = 0;
            fiboNumbers[1] = 1;

            for (long i = 2; i <= input; i++)
            {
                fiboNumbers[i] = fiboNumbers[i - 1] + fiboNumbers[i - 2];
            }

            return fiboNumbers[input];
        }

        public static BigInteger MemoryEfficientFibonacci(BigInteger input)
        {
            if (input <= 1) return input;

            BigInteger prev = 0;
            BigInteger curr = 1;

            for (int i = 2; i <= input; i++)
            {
                BigInteger tempPrev = curr;
                curr += prev;
                prev = tempPrev;
            }

            return curr;
        }

        private static BigInteger NaiveFibonacci(long input)
        {
            if (input <= 1) return input;
            return NaiveFibonacci(input - 1) + NaiveFibonacci(input - 2);
        }

        private static long CalculateHugeFibonacciModulus(long input, long modulus)
        {
            if (input <= 1) return input % modulus;

            long prev = 0;
            long curr = 1;

            for (long i = 2; i <= input; i++)
            {
                long temp = curr;
                curr = (prev + curr) % modulus;
                prev = temp;
            }

            return curr;
        }

        private static int LastDigitFibonacci(int input)
        {
            int a = 0, b = 1, c = 0;

            for (int i = 1; i < input; i++)
            {
                c = (a + b) % 10;
                a = b;
                b = c;
            }

            return c;
        }
    }
}