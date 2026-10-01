namespace MuseumHomework
{
    internal class Hall
    {
        /// <summary>
        /// Уникальный идентификатор зала.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название зала.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Этаж, на котором находится зал
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// Площадь зала в квадратных метрах.
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// Вычисляемое свойство: находится ли зал выше первого этажа.
        /// </summary>
        public bool IsUpper => Floor > 1;

        public Hall(int id, string name, int floor, int area)
        {

            if (id <= 0)
                throw new ArgumentException("Id зала должен быть больше 0");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название зала не может быть пустым");

            if (area < 0)
                throw new ArgumentException("Площадь не может быть отрицательной");

            Id = id;
            Name = name;
            Floor = floor;
            Area = area;
        }

        /// <summary>
        /// Возвращает строковое представление экспоната.
        /// </summary>
        public string GetInfo()
        {
            return $"{Name} ({Floor} этаж, {Area} м²)";
        }
    }
}
