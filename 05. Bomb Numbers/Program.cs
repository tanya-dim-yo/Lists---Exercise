namespace _05.Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> bombInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int bomb = bombInfo[0];
            int power = bombInfo[1];

            while (numbers.Contains(bomb))
            {
                int bombIndex = numbers.IndexOf(bomb);
                int startIndex = bombIndex - power;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int endIndex = bombIndex + power;

                if (endIndex > numbers.Count - 1)
                {
                    endIndex = numbers.Count - 1;
                }

                numbers.RemoveRange(startIndex, endIndex - startIndex + 1);
            }

            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}