using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project.Common
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalCount { get; private set; }
        public static int TempTotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            TempTotalPages = TotalPages;
            this.AddRange(items);
        }
        //Add active class on current/ check previous page, test it, issues
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public int MiddleIndex
        {
            get
            {
                if (PageIndex < 3)
                {
                    return 3;
                }
                else if (PageIndex > (TotalPages - 2))
                {
                    return (TotalPages - 2);
                }
                else
                {
                    return PageIndex;
                }
            }
        }

        public static async Task<Tuple<PaginatedList<T>, bool, int>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize = 0)
        {
            if (pageSize == 0)
            {
                pageSize = Constants.DefaultPageSize;
            }

            if (TempTotalPages != 0 && pageIndex > TempTotalPages)
            {
                return new Tuple<PaginatedList<T>, bool, int>(null, false, TempTotalPages);
            }
            else
            {
                var count = await source.CountAsync();
                var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

                var tempResult = new PaginatedList<T>(items, count, pageIndex, pageSize);

                return new Tuple<PaginatedList<T>, bool, int>(tempResult, true, TempTotalPages);
            }
        }
    }
}
