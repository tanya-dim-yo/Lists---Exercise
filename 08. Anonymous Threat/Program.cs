namespace _08.Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "merge")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    FixInvalidIndexes(words, ref startIndex, ref endIndex);
                    MergeWords(words, startIndex, endIndex);
                }
                else if (cmdType == "divide")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int partitions = int.Parse(cmdArgs[2]);

                    string word = words[index];

                    List<string> partitionList = DivideWord(word, partitions);
                    words.RemoveAt(index);
                    words.InsertRange(index, partitionList);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", words));
        }

        private static List<string> DivideWord(string word, int partitions)
        {
            int substringsLength = word.Length / partitions;
            int lastSubstringLength = word.Length - ((partitions - 1) * substringsLength);

            List<string> partitionsList = new List<string>();

            for (int i = 0; i < partitions; i++)
            {
                int desiredLength = substringsLength;

                if (i == partitions - 1)
                {
                    desiredLength = lastSubstringLength;
                }

                char[] newPartitionArr = word
                    .Skip(i * substringsLength)
                    .Take(desiredLength)
                    .ToArray();

                string newPartition = String.Join(" ", newPartitionArr);
                partitionsList.Add(newPartition);
            }

            return partitionsList;
        }

        private static void MergeWords(List<string> words, int startIndex, int endIndex)
        {
            string mergedText = string.Empty;

            for (int i = startIndex; i <= endIndex; i++)
            {
                string currWord = words[startIndex];
                mergedText += currWord;
                words.RemoveAt(startIndex);
            }

            words.Insert(startIndex, mergedText);
        }

        private static void FixInvalidIndexes(List<string> words, ref int startIndex, ref int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (startIndex >= words.Count)
            { 
                startIndex = words.Count - 1;
            }

            if (endIndex <= 0)
            {
                endIndex = 0;
            }

            if (endIndex >= words.Count)
            {
                endIndex = words.Count - 1;
            }
        }
    }
}