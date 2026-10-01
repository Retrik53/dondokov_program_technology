namespace MuseumHomework
{
    internal class Curator
    {
        /// <summary>
        /// Уникальный идентификатор куратора.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя куратора.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Специальность куратора (например, "Реставратор").
        /// </summary>
        public string Specialty { get; set; }

        /// <summary>
        /// Вычисляемое свойство: является ли куратор реставратором.
        /// </summary>
        public bool IsRestorer => Specialty == "Реставратор";

        public Curator(int id, string fullName, string specialty)
        {
            if (id <= 0)
                throw new ArgumentException("Id куратора должен быть больше 0");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("ФИО куратора не может быть пустым");

            if (string.IsNullOrWhiteSpace(specialty))
                throw new ArgumentException("Специальность не может быть пустой");

            Id = id;
            FullName = fullName;
            Specialty = specialty;
        }

        /// <summary>
        /// Возвращает строковое представление экспоната.
        /// </summary>
        public string GetInfo()
        {
            return $"{FullName} ({Specialty.ToLower()})";
        }
    }
}
