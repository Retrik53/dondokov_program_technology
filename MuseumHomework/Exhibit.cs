namespace MuseumHomework
{
    internal class Exhibit
    {
        /// <summary>
        /// Уникальный идентификатор экспоната.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название экспоната (не уникально).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Внешний ключ на куратора экспоната.
        /// </summary>
        public int CuratorId { get; set; }

        /// <summary>
        /// Внешний ключ на зал, где находится экспонат.
        /// </summary>
        public int HallId { get; set; }

        /// <summary>
        /// Год создания (может быть отрицательным — "до н.э.").
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Цена экспоната в рублях (не может быть отрицательной).
        /// </summary>
        public decimal Price { get; set; }

        public bool IsAncient => Year < 1000;
        public bool IsValuable => Price > 1000000;

        public Exhibit(int id, string name, int curatorId, int hallId, int year, decimal price)
        {
            if (id <= 0)
                throw new ArgumentException("Id экспоната должен быть больше 0");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название экспоната не может быть пустым");

            if (curatorId <= 0)
                throw new ArgumentException("Некорректный CuratorId (должен быть больше 0)");

            if (hallId <= 0)
                throw new ArgumentException("Некорректный HallId (должен быть больше 0)");

            if (price < 0)
                throw new ArgumentException("Цена не может быть отрицательной");

            Id = id;
            Name = name;
            CuratorId = curatorId;
            HallId = hallId;
            Year = year;
            Price = price;
        }

        /// <summary>
        /// Возвращает строковое представление экспоната.
        /// </summary>
        public string GetInfo()
        {
            return $"{Name} ({Year} до н.э., {Price.ToString("N0")} руб.)";
        }
    }
}
