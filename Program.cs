using System;
using DotFlix.Classes;

namespace DotFlix
{
    class Program
    {
        static LessonRepository repository = new LessonRepository();

        static void Main(string[] args)
        {
            string userMenu = Menu();

            while (userMenu.ToUpper() != "X")
            {
                switch (userMenu)
                {
                    case "1":
                        ListLessons();
                        break;
                    case "2":
                        InsertLesson();
                        break;
                    case "3":
                        UpdateLesson();
                        break;
                    case "4":
                        RemoveLesson();
                        break;
                    case "5":
                        ViewLesson();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userMenu = Menu();
            }
            System.Console.WriteLine("Thanks for use our services");
            System.Console.WriteLine();
        }

        private static void ViewLesson()
        {
            System.Console.Write("Write the Id of Lesson:");
            int indexLesson = int.Parse(Console.ReadLine());

            var lesson = repository.ReturnById(indexLesson);

            Console.WriteLine (lesson);
        }

        private static void RemoveLesson()
        {
            System.Console.Write("Write the Id of Lesson:");
            int indexLesson = int.Parse(Console.ReadLine());

            repository.Delete (indexLesson);
        }

        private static void UpdateLesson()
        {
            System.Console.Write("Write the id of the Lesson: ");
            int indexLesson = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof (Category)))
            {
                System
                    .Console
                    .WriteLine($"{i}-{Enum.GetName(typeof (Category), i)}");
            }

            System
                .Console
                .Write("Choose the category to insert of top options: ");
            int enterCategory = int.Parse(Console.ReadLine());

            System.Console.Write("Write the title of Lesson: ");
            string enterTitle = Console.ReadLine();

            System.Console.Write("Write the year of Lesson: ");
            int enterYear = int.Parse(Console.ReadLine());

            System.Console.Write("Write the description of Lesson: ");
            string enterDescription = Console.ReadLine();

            Lesson updateLesson =
                new Lesson(id: indexLesson,
                    category: (Category) enterCategory,
                    title: enterTitle,
                    year: enterYear,
                    description: enterDescription);

            repository.Update (indexLesson, updateLesson);
        }

        private static void InsertLesson()
        {
            System.Console.WriteLine("Insert new Lesson");

            foreach (int i in Enum.GetValues(typeof (Category)))
            {
                System
                    .Console
                    .WriteLine($"{i}-{Enum.GetName(typeof (Category), i)}");
            }

            System
                .Console
                .Write("Choose the category to insert of top options: ");
            int enterCategory = int.Parse(Console.ReadLine());

            System.Console.Write("Write the title of Lesson: ");
            string enterTitle = Console.ReadLine();

            System.Console.Write("Write the year of Lesson: ");
            int enterYear = int.Parse(Console.ReadLine());

            System.Console.Write("Write the description of Lesson: ");
            string enterDescription = Console.ReadLine();

            Lesson newLesson =
                new Lesson(id: repository.NextId(),
                    category: (Category) enterCategory,
                    title: enterTitle,
                    year: enterYear,
                    description: enterDescription);

            repository.Insert (newLesson);
        }

        private static void ListLessons()
        {
            System.Console.WriteLine("List Lessons");

            var list = repository.Relation();

            if (list.Count == 0)
            {
                System.Console.WriteLine("Dont have a lesson yet!");
                return;
            }

            foreach (var lesson in list)
            {
                var excluded = lesson.returnExcluded();

                if (!excluded)
                {
                    Console.WriteLine($"#Id {lesson.returnId()}: - {lesson.resturnTitle()} ");
                }
            }
        }

        private static string Menu()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Welcome to DotFlix Lessons");
            System.Console.WriteLine("Choose an option:");

            System.Console.WriteLine("1 - List Lessons");
            System.Console.WriteLine("2 - Insert a new Lesson");
            System.Console.WriteLine("3 - Update the Lesson");
            System.Console.WriteLine("4 - Delete the Lesson");
            System.Console.WriteLine("5 - View the Lesson");
            System.Console.WriteLine("C - Screen clear");
            System.Console.WriteLine("X - Exit");
            System.Console.WriteLine();

            string userMenu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userMenu;
        }
    }
}
