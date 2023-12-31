﻿namespace AlgorithmicToolbox
{
    public class MaximumPairwiseProduct
    {
        public static void ExecuteTesting()
        {
            var input = Console.ReadLine();
            var arrayInput = Console.ReadLine();
            var arrayNumbers = arrayInput.Split(" ").Select(x => long.Parse(x)).ToArray();
            Console.WriteLine(MaximumPairwiseProductUsingGreedy(arrayNumbers));
        }

        private static long MaximumPairwiseProductUsingSorting(long[] arrayNumbers)
        {
            Array.Sort(arrayNumbers);
            return arrayNumbers[arrayNumbers.Length - 1] * arrayNumbers[arrayNumbers.Length - 2];
        }

        private static long MaximumPairwiseProductUsingGreedy(long[] arrayNumbers)
        {
            long highestNumber = 0;
            long secondHighestNumber = 0;

            for (long i = 0; i < arrayNumbers.Length; i++)
            {
                if (arrayNumbers[i] > highestNumber)
                {
                    secondHighestNumber = highestNumber;
                    highestNumber = arrayNumbers[i];
                }
                else if (arrayNumbers[i] > secondHighestNumber)
                {
                    secondHighestNumber = arrayNumbers[i];
                }
            }

            return highestNumber * secondHighestNumber;
        }
    }
}