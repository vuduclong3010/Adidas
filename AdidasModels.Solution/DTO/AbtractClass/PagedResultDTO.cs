using System.Collections.Generic;

namespace AdidasModels.Solution.DTO.AbtractClass
{
    /// <summary>
    /// Paging Result.
    /// </summary>
    /// <typeparam name="T">T: Class.</typeparam>
    public abstract class PagedResultDTO<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}
