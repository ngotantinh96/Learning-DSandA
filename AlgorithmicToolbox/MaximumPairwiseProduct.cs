using System;
namespace MaximumPairwiseProduct
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

        public static long MaximumPairwiseProductUsingSorting(long[] arrayNumbers)
        {
            Array.Sort(arrayNumbers);
            return arrayNumbers[arrayNumbers.Length - 1] * arrayNumbers[arrayNumbers.Length - 2];
        }

        public static long MaximumPairwiseProductUsingGreedy(long[] arrayNumbers)
        {
            long highestNumber = 0;
            long secondHighestNumber = 0;

            for (int i = 0; i < arrayNumbers.Length; i++)
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