using System.Text;

namespace _07.Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<int> output = new List<int>();

            for (int i = input.Count - 1; i >= 0; i--)
            {
                string current = input[i];
                List<int> currentString = current
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                foreach (int currentInt in currentString)
                {
                    output.Add(currentInt);
                }
            }

            Console.WriteLine(string.Join(" ", output));
        }
    }
}