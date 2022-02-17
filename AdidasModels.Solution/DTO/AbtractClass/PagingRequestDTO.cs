using System;
using System.Collections.Generic;
using System.Text;

namespace AdidasModels.Solution.DTO.AbtractClass
{
    /// <summary>
    /// Paging Base Dto.
    /// </summary>
    public abstract class PagingRequestDTO
    {
        private int pageIndex = 1;
        private int pageSize = 10;

        /// <summary>
        /// Gets or sets Page Index.
        /// </summary>
        public int PageIndex
        {
            get => pageIndex;

            set => pageIndex = value <= 0 ? 1 : value;
        }

        /// <summary>
        /// Gets or sets Page Size.
        /// </summary>
        public int PageSize
        {
            get => pageSize;

            set => pageSize = value > 50 ? 50 : value;
        }
    }
}
