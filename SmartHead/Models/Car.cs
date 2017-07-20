namespace MvcApplication.Models
{
    using System;
    using System.Data.Entity;

    public class Car
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата изменения
        /// </summary>
        public DateTime ChangeDate { get; set; }
    }

    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}