namespace MuseumHomework
{
    /// <summary>
    /// Репозиторий с тестовыми данными в памяти.
    /// </summary>
    internal class InMemoryRepository
    {
        /// <summary>
        /// Приватный список кураторов.
        /// </summary>
        private List<Curator> _curators;

        /// <summary>
        /// Приватный список залов.
        /// </summary>
        private List<Hall> _halls;

        /// <summary>
        /// Приватный список экспонатов.
        /// </summary>
        private List<Exhibit> _exhibits;

        /// <summary>
        /// Конструктор, заполняющий списки тестовыми данными.
        /// </summary>
        public InMemoryRepository()
        {
            _curators = new List<Curator>
            {
                new Curator(1, "Смирнова Е.В.", "Реставратор"),
                new Curator(2, "Орлова М.И.", "Искусствовед"),
                new Curator(3, "Петров А.С.", "Историк"),
                new Curator(4, "Иванова О.П.", "Реставратор"),
                new Curator(5, "Сидоров В.К.", "Археолог")
            };

            _halls = new List<Hall>
            {
                new Hall(1, "Античность", 2, 200),
                new Hall(2, "Средневековье", 1, 150),
                new Hall(3, "Ренессанс", 2, 180),
                new Hall(4, "Древний Египет", 1, 120),
                new Hall(5, "Современное искусство", 3, 300)
            };

            _exhibits = new List<Exhibit>
            {
                new Exhibit(1, "Амфора", 1, 1, 412, 50000),
                new Exhibit(2, "Статуя", 1, 1, 243, 80000),
                new Exhibit(3, "Икона", 2, 2, 1503, 2000000),
                new Exhibit(4, "Саркофаг", 5, 4, 993, 5000000),
                new Exhibit(5, "Ваза", 3, 3, 1681, 120000),
                new Exhibit(6, "Мозаика", 4, 3, 1456, 300000)
            };
        }

        /// <summary>
        /// Возвращает список кураторов.
        /// </summary>
        public List<Curator> GetCurators() { return _curators; }

        /// <summary>
        /// Возвращает список залов.
        /// </summary>
        public List<Hall> GetHalls() { return _halls; }

        /// <summary>
        /// Возвращает список экспонатов.
        /// </summary>
        public List<Exhibit> GetExhibits() { return _exhibits; }
    }
}