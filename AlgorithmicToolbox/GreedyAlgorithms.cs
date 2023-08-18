namespace AlgorithmicToolbox
{
    public class GreedyAlgorithms
    {
        public static void ExecuteTesting()
        {
            ExecuteMaximumLootValueTesting();
        }

        public static void ExecuteMaximumLootValueTesting()
        {
            var inputs = Console.ReadLine().Split(" ");
            var n = int.Parse(inputs[0]);
            var capacity = int.Parse(inputs[1]);
            int[,] loops = new int[n, 2];

            for (int i = 0; i < n; i++)
            {
                inputs = Console.ReadLine().Split(" ");
                loops[i, 0] = int.Parse(inputs[0]);
                loops[i, 1] = int.Parse(inputs[1]);
            }

            Console.WriteLine(MaximumLootValue(capacity, loops));
        }

        public static void ExecuteMinimumMoneyChangeTesting()
        {
            var money = int.Parse(Console.ReadLine());
            Console.WriteLine(MinimumMoneyChange(money));
        }

        private static int MinimumMoneyChange(int money)
        {
            return money / 10 + money % 10 / 5 + money % 10 % 5;
        }

        private static int MaximumLootValue(int capacity, int[,] loops)
        {
            Dictionary<int, int> loopsVault = new();
            for (int i = 0; i < loops.Length; i++)
            {
                loops[i, 1] = loops[i, 0] / loops[i, 1];
                loopsVault.Add(loops[i, 1], loops[i, 0] / loops[i, 1]);
            }

            loopsVault = loopsVault.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            var result = 0;

            return result;
        }
        
    }
}