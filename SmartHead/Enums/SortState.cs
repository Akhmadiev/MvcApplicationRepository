namespace MvcApplication.Enums
{
    /// <summary>
    /// Сортировка
    /// </summary>
    public enum SortState
    {
        /// <summary>
        /// по имени
        /// </summary>
        NameAsc,

        ///<summary>
        /// по имени
        /// </summary>   
        NameDesc,

        ///<summary>
        /// по порядковому номеру
        /// </summary>   
        NumberAsc,

        ///<summary>
        /// по порядковому номеру
        /// </summary>
        NumberDesc,

        ///<summary>
        /// по дате создания
        /// </summary>
        CreateDateAsc,

        ///<summary>
        /// по дате создания
        /// </summary>
        CreateDateDesc,

        ///<summary>
        /// по дате изменения
        /// </summary>
        ChangeDateAsc,

        ///<summary>
        /// по дате изменения
        /// </summary>
        ChangeDateDesc
    }
}