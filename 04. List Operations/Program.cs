namespace _04.List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmdArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];

                if (command == "Add")
                {
                    numbers.Add(int.Parse(cmdArgs[1]));
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(cmdArgs[1]);
                    int index = int.Parse(cmdArgs[2]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.Insert(index, number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "Remove")
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (index >= 0 && index < numbers.Count)
                    {
                        numbers.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                }
                else if (command == "Shift")
                {
                    int count = int.Parse(cmdArgs[2]);

                    if (cmdArgs[1] == "left")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int firstDigit = numbers[0];
                            numbers.RemoveAt(0);
                            numbers.Add(firstDigit);
                        }
                    }
                    else if (cmdArgs[1] == "right")
                    {
                        for (int i = 0; i < count; i++)
                        {
                            int lastDigit = numbers[numbers.Count - 1];
                            numbers.RemoveAt(numbers.Count - 1);
                            numbers.Insert(0, lastDigit);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}