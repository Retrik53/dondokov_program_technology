
namespace MuseumHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Выберите источник данных:");
                Console.WriteLine("1 - InMemoryRepository");
                Console.WriteLine("2 - CsvRepository");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Выбор не сделан");
                    return;
                }

                List<Curator> curators;
                List<Hall> halls;
                List<Exhibit> exhibits;

                switch (choice)
                {
                    case "1":
                        var memRepo = new InMemoryRepository();
                        curators = memRepo.GetCurators();
                        halls = memRepo.GetHalls();
                        exhibits = memRepo.GetExhibits();
                        break;
                    case "2":
                        var csvRepo = new CsvRepository("C:\\Users\\Bazar\\source\\repos\\AlgoritmAndDataStructures\\MuseumHomework\\data");
                        curators = csvRepo.GetCurators();
                        halls = csvRepo.GetHalls();
                        exhibits = csvRepo.GetExhibits();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        return;
                }

                if (curators == null || halls == null || exhibits == null)
                {
                    Console.WriteLine("Ошибка загрузки данных");
                    return;
                }

                string targetExhibitName = "Амфора";
                Curator foundCurator = FindCurator(exhibits, curators, targetExhibitName);
                Console.Write($"1. {targetExhibitName}: ");
                if (foundCurator != null)
                    Console.WriteLine(foundCurator.GetInfo());
                else
                    Console.WriteLine("Не найдено");

                Hall foundHall = FindHall(exhibits, halls, targetExhibitName);
                Console.Write($"2. {targetExhibitName}: ");
                if (foundHall != null)
                    Console.WriteLine(foundHall.GetInfo());
                else
                    Console.WriteLine("Не найдено");

                decimal totalPrice = GetTotalPrice(exhibits);
                Console.WriteLine($"3. {totalPrice.ToString("N0")} руб.");

                string targetHallName = "Античность";
                List<Exhibit> sortedExhibits = GetExhibitsByHallSortedByYear(exhibits, halls, targetHallName);
                Console.WriteLine($"4. {targetHallName}:");
                if (sortedExhibits != null && sortedExhibits.Count > 0)
                {
                    foreach (var ex in sortedExhibits)
                    {
                        Console.WriteLine($"{ex.Name} ({ex.Year}, {ex.Price.ToString("N0")} руб.)");
                    }
                }
                else
                {
                    Console.WriteLine("Не найдено");
                }

                Console.WriteLine("5.");
                PrintAllExhibits(exhibits, curators, halls);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                return;
            }
        }

        /// <summary>
        /// Находит куратора по названию экспоната.
        /// </summary>
        static Curator FindCurator(List<Exhibit> exhibits, List<Curator> curators, string exhibitName)
        {
            if (exhibits == null || curators == null || string.IsNullOrWhiteSpace(exhibitName))
                return null;

            Exhibit targetExhibit = null;
            for (int i = 0; i < exhibits.Count; i++)
            {
                if (exhibits[i] != null && exhibits[i].Name == exhibitName)
                {
                    targetExhibit = exhibits[i];
                    break;
                }
            }

            if (targetExhibit == null) return null;

            for (int i = 0; i < curators.Count; i++)
            {
                if (curators[i] != null && curators[i].Id == targetExhibit.CuratorId)
                {
                    return curators[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Находит зал по названию экспоната.
        /// </summary>
        static Hall FindHall(List<Exhibit> exhibits, List<Hall> halls, string exhibitName)
        {
            if (exhibits == null || halls == null || string.IsNullOrWhiteSpace(exhibitName))
                return null;

            Exhibit targetExhibit = null;
            for (int i = 0; i < exhibits.Count; i++)
            {
                if (exhibits[i] != null && exhibits[i].Name == exhibitName)
                {
                    targetExhibit = exhibits[i];
                    break;
                }
            }

            if (targetExhibit == null) return null;

            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i] != null && halls[i].Id == targetExhibit.HallId)
                {
                    return halls[i];
                }
            }

            return null;
        }
        
        /// <summary>
        /// Подсчитывает общую стоимость всех экспонатов.
        /// </summary>
        static decimal GetTotalPrice(List<Exhibit> exhibits)
        {
            if (exhibits == null) return 0;

            decimal sum = 0;
            for (int i = 0; i < exhibits.Count; i++)
            {
                if (exhibits[i] != null)
                    sum += exhibits[i].Price;
            }
            return sum;
        }

        /// <summary>
        /// Возвращает экспонаты указанного зала, отсортированные по году (пузырьковая сортировка).
        /// </summary>
        static List<Exhibit> GetExhibitsByHallSortedByYear(List<Exhibit> exhibits, List<Hall> halls, string hallName)
        {
            List<Exhibit> filtered = new List<Exhibit>();
            if (exhibits == null || halls == null || string.IsNullOrWhiteSpace(hallName))
                return filtered;

            int hallId = -1;
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i] != null && halls[i].Name == hallName)
                {
                    hallId = halls[i].Id;
                    break;
                }
            }

            if (hallId == -1) return filtered;

            for (int i = 0; i < exhibits.Count; i++)
            {
                if (exhibits[i] != null && exhibits[i].HallId == hallId)
                {
                    filtered.Add(exhibits[i]);
                }
            }

            for (int i = 0; i < filtered.Count - 1; i++)
            {
                for (int j = 0; j < filtered.Count - i - 1; j++)
                {
                    if (filtered[j].Year > filtered[j + 1].Year)
                    {
                        Exhibit temp = filtered[j];
                        filtered[j] = filtered[j + 1];
                        filtered[j + 1] = temp;
                    }
                }
            }

            return filtered;
        }

        /// <summary>
        /// Выводит все экспонаты с информацией о кураторе и зале.
        /// </summary>
        static void PrintAllExhibits(List<Exhibit> exhibits, List<Curator> curators, List<Hall> halls)
        {
            if (exhibits == null || curators == null || halls == null)
            {
                Console.WriteLine("Данные отсутствуют");
                return;
            }

            for (int i = 0; i < exhibits.Count; i++)
            {
                Exhibit ex = exhibits[i];
                if (ex == null) continue;

                Curator curator = null;
                for (int j = 0; j < curators.Count; j++)
                {
                    if (curators[j] != null && curators[j].Id == ex.CuratorId)
                    {
                        curator = curators[j];
                        break;
                    }
                }

                Hall hall = null;
                for (int j = 0; j < halls.Count; j++)
                {
                    if (halls[j] != null && halls[j].Id == ex.HallId)
                    {
                        hall = halls[j];
                        break;
                    }
                }

                string curatorInfo = curator != null ? curator.FullName : "Не найден";
                string hallInfo = hall != null ? $"{hall.Name} ({hall.Floor} этаж)" : "Не найден";

                Console.WriteLine($"\"{ex.GetInfo()}\" — куратор {curatorInfo}, зал \"{hallInfo}\".");
            }
        }

    }
}
