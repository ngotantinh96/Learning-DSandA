namespace AlgorithmicToolbox
{
    public class GreatestCommonDivisor
    {
        public static void ExecuteTesting()
        {
            var input = Console.ReadLine();
            var numbersToCalculate = input.Trim().Split(" ");
            Console.WriteLine(EuclidGCD(long.Parse(numbersToCalculate[0]), long.Parse(numbersToCalculate[1])));
        }

        private static long EuclidGCD(long numberA, long numberB)
        {
            if (numberB == 0) return numberA;

            return EuclidGCD(numberB, numberA % numberB);
        }

        private static long NaiveGCD(long numberA, long numberB)
        {
            long greatestNumber = 0;
            long compareNumber = Math.Min(numberA, numberB);

            for (long i = 1; i <= compareNumber; i++)
            {
                if (numberA % i == 0 && numberB % i == 0) greatestNumber = i;
            }

            return greatestNumber;
        }
    }
}