namespace MvcApplication.Models
{
    using System;

    public class PageInfo
    {
        /// <summary>
        /// номер текущей страницы
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// кол-во объектов на странице
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Все объектов
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Всего страниц
        /// </summary>
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}