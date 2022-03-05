using Newtonsoft.Json;
using System.Collections.Generic;

namespace AdidasModels.Solution
{
    /// <summary>
    /// Paging query results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<TEntity> where TEntity: class, new()
    {
        /// <summary>
        /// Total
        /// </summary>
        public long TotalCount {get; set;}

        /// <summary>
        /// Data collection
        /// </summary>
        public IList<TEntity> Rows {get; set;}

        /// <summary>
        /// Other data
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data {get; set;}
    }
}