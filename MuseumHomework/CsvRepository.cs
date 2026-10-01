namespace MuseumHomework
{
    /// <summary>
    /// Репозиторий, читающий данные из CSV-файлов.
    /// </summary>
    internal class CsvRepository
    {
        /// <summary>
        /// Приватное поле — путь к папке с CSV-файлами.
        /// </summary>
        private string _basePath;

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        public CsvRepository(string basePath)
        {
            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Путь к папке с данными не может быть пустым");

            _basePath = basePath;
        }

        /// <summary>
        /// Читает кураторов из файла curators.csv.
        /// </summary>
        public List<Curator> GetCurators()
        {
            List<Curator> result = new List<Curator>();
            string path = Path.Combine(_basePath, "curators.csv");

            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines == null || lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 3) continue;

                try
                {
                    Curator c = new Curator(
                        int.Parse(parts[0]),
                        parts[1],
                        parts[2]
                    );
                    result.Add(c);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в строке {i + 1} файла curators.csv: {ex.Message}");
                }
            }
            return result;
        }

        /// <summary>
        /// Читает залы из файла halls.csv.
        /// </summary>
        public List<Hall> GetHalls()
        {
            List<Hall> result = new List<Hall>();
            string path = Path.Combine(_basePath, "halls.csv");

            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines == null || lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 4) continue;

                try
                {
                    Hall h = new Hall(
                        int.Parse(parts[0]),
                        parts[1],
                        int.Parse(parts[2]),
                        int.Parse(parts[3])
                    );
                    result.Add(h);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в строке {i + 1} файла halls.csv: {ex.Message}");
                }
            }
            return result;
        }

        /// <summary>
        /// Читает экспонаты из файла exhibits.csv.
        /// </summary>
        public List<Exhibit> GetExhibits()
        {
            List<Exhibit> result = new List<Exhibit>();
            string path = Path.Combine(_basePath, "exhibits.csv");

            if (!File.Exists(path)) return result;

            string[] lines = File.ReadAllLines(path);
            if (lines == null || lines.Length < 2) return result;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length < 6) continue;

                try
                {
                    Exhibit e = new Exhibit(
                        int.Parse(parts[0]),
                        parts[1],
                        int.Parse(parts[2]),
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        decimal.Parse(parts[5].Replace(',', '.'))
                    );
                    result.Add(e);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в строке {i + 1} файла exhibits.csv: {ex.Message}");
                }
            }
            return result;
        }
    }
}