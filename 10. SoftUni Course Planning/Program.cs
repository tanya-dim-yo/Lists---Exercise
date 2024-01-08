using System;

namespace _10.SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] command = input.Split(":");
                string cmdType = command[0];
                string lessonName = command[1];

                if (cmdType == "Add")
                {
                    if (!lessons.Contains(lessonName))
                    {
                        lessons.Add(lessonName);
                    }
                }
                else if (cmdType == "Insert")
                {
                    int index = int.Parse(command[2]);

                    if (!lessons.Contains(lessonName))
                    {
                        lessons.Insert(index, lessonName);
                    }
                }
                else if (cmdType == "Remove")
                {
                    if (lessons.Contains(lessonName))
                    {
                        lessons.Remove(lessonName);
                    }

                    if (lessons.Contains($"{lessonName}-Exercise"))
                    {
                        lessons.Remove($"{lessonName}-Exercise");
                    }
                }
                else if (cmdType == "Swap")
                {
                    string secondLessonName = command[2];

                    if (lessons.Contains(lessonName) && lessons.Contains(secondLessonName))
                    {
                        int firstLessonIndex = lessons.IndexOf(lessonName);
                        int secondLessonIndex = lessons.IndexOf(secondLessonName);
                        lessons[firstLessonIndex] = secondLessonName;
                        lessons[secondLessonIndex] = lessonName;

                        if (lessons.Contains($"{lessonName}-Exercise"))
                        {
                            int indexFirstLessonExercise = lessons.IndexOf($"{lessonName}-Exercise");
                            lessons.Insert(secondLessonIndex + 1, $"{lessonName}-Exercise");
                            lessons.RemoveAt(indexFirstLessonExercise);
                        }

                        if (lessons.Contains($"{secondLessonName}-Exercise"))
                        {
                            int indexSecondLessonExercise = lessons.IndexOf($"{secondLessonName}-Exercise");
                            lessons.Insert(firstLessonIndex + 1, $"{secondLessonName}-Exercise");
                            lessons.RemoveAt(indexSecondLessonExercise);
                        }
                    }
                }
                else if (cmdType == "Exercise")
                {
                    if (lessons.Contains(lessonName))
                    {
                        if (!lessons.Contains($"{lessonName}-Exercise"))
                        {
                            int index = lessons.IndexOf(lessonName);
                            lessons.Insert(index + 1, $"{lessonName}-Exercise");
                        }
                    }
                    else
                    {
                        lessons.Add(lessonName);
                        lessons.Add($"{lessonName}-Exercise");
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, lessons));

        }
    }
}