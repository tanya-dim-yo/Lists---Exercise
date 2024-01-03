namespace _03.House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] instructions = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = instructions[0];

                if (instructions.Length == 3)
                {
                    if (guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }

                    guests.Add(name);
                }
                else if (instructions.Length == 4)
                {
                    if (!guests.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                        continue;
                    }

                    guests.Remove(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }
    }
}