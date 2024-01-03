namespace _02.Change_List
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

            while (input != "end")
            {
                string[] cmdArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];
                int element = int.Parse(cmdArgs[1]);

                if (command == "Delete")
                {
                    numbers.RemoveAll(x => x == element);
                }
                else if (command == "Insert")
                {
                    int position = int.Parse(cmdArgs[2]);
                    numbers.Insert(position, element);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}