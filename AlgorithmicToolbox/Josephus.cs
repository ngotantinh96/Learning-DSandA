namespace AlgorithmicToolbox
{
    public class Josephus
    {
        public static void ExecuteTesting()
        {
            var input = Console.ReadLine();
            var numbersToCalculate = input.Trim().Split(" ");
            Console.WriteLine(OnJosephus(int.Parse(numbersToCalculate[0]), int.Parse(numbersToCalculate[1])));
            //var people = Enumerable.Range(1, int.Parse(numbersToCalculate[0])).ToList();
            //Console.WriteLine(NaiveJosephus(ref people, int.Parse(numbersToCalculate[1])));
        }

        private static int NaiveJosephus(ref List<int> people, int step, int index = 0)
        {
            if(people.Count <= 1) return people[0];

            index = (index + step - 1) % people.Count;
            people.RemoveAt(index);

            return NaiveJosephus(ref people, step, index);
        }

        public static int OnJosephus(int n, int k)
        {
            int survivor = 0;

            // Calculate Josephus position for n and k
            for (int i = 2; i <= n; i++)
            {
                survivor = (survivor + k) % i;
            }

            // Adjust survivor position to be 1-based index
            return survivor + 1;
        }

    }
}