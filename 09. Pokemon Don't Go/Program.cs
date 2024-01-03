namespace _09.Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sumOfRemovedElements = 0;

            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int elementToBeRemoved = 0;

                if (index < 0)
                {
                    elementToBeRemoved = pokemons[0];
                    sumOfRemovedElements += elementToBeRemoved;
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);

                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= elementToBeRemoved)
                        {
                            pokemons[i] += elementToBeRemoved;
                        }
                        else
                        {
                            pokemons[i] -= elementToBeRemoved;
                        }
                    }
                }
                else if (index > pokemons.Count - 1)
                {
                    elementToBeRemoved = pokemons[pokemons.Count - 1];
                    sumOfRemovedElements += elementToBeRemoved;
                    pokemons.RemoveAt(pokemons.Count - 1);
                    int firstElement = pokemons[0];
                    pokemons.Add(firstElement);

                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= elementToBeRemoved)
                        {
                            pokemons[i] += elementToBeRemoved;
                        }
                        else
                        {
                            pokemons[i] -= elementToBeRemoved;
                        }
                    }
                }
                else
                {
                    elementToBeRemoved = pokemons[index];
                    sumOfRemovedElements += elementToBeRemoved;
                    pokemons.RemoveAt(index);

                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= elementToBeRemoved)
                        {
                            pokemons[i] += elementToBeRemoved;
                        }
                        else
                        {
                            pokemons[i] -= elementToBeRemoved;
                        }
                    }
                }
            }

            Console.WriteLine(sumOfRemovedElements);
        }
    }
}