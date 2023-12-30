namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs.Length > 1)
                {
                    wagons.Add(int.Parse(cmdArgs[1]));
                    continue;
                }
                else
                {
                    int incomingPassengers = int.Parse(cmdArgs[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((maxCapacity - wagons[i]) >= incomingPassengers)
                        {
                            wagons[i] += incomingPassengers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}