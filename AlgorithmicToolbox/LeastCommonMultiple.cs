namespace AlgorithmicToolbox
{
    public class LeastCommonMultiple
    {
        public static void ExecuteTesting()
        {
            var input = Console.ReadLine();
            var numbersToCalculate = input.Trim().Split(" ");
            Console.WriteLine(EuclidLCM(long.Parse(numbersToCalculate[0]), long.Parse(numbersToCalculate[1])));
        }

        private static long EuclidLCM(long numberA, long numberB)
        {
            return numberA * numberB / EuclidGCD(numberA, numberB);
        }

        private static long EuclidGCD(long numberA, long numberB)
        {
            if (numberB == 0) return numberA;

            return EuclidGCD(numberB, numberA % numberB);
        }

        private static long NaiveLCM(long numberA, long numberB)
        {
            long leastLCM = Math.Max(numberA, numberB);

            for (long i = leastLCM; i <= numberA * numberB; i++)
            {
                if (i % numberA == 0 && i % numberB == 0) return i;
            }

            return numberA * numberB;
        }
    }
}