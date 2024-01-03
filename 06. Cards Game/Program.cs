namespace _06.Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
            {
                if (firstPlayer[0] > secondPlayer[0])
                {
                    firstPlayer.Add(secondPlayer[0]);
                    secondPlayer.RemoveAt(0);

                    int winningCard = firstPlayer[0];
                    firstPlayer.RemoveAt(0);
                    firstPlayer.Add(winningCard);
                    continue;
                }
                else if (firstPlayer[0] < secondPlayer[0])
                {
                    secondPlayer.Add(firstPlayer[0]);
                    firstPlayer.RemoveAt(0);

                    int winningCard = secondPlayer[0];
                    secondPlayer.RemoveAt(0);
                    secondPlayer.Add(winningCard);
                    continue;
                }
                else if (firstPlayer[0] == secondPlayer[0])
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                    continue;
                }
            }

            if (firstPlayer.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else if (secondPlayer.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
        }
    }
}