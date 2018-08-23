using System;
using System.Collections.Generic;
using System.Linq;

namespace MySchool.ViewModels
{
    public class PaginatedListViewModel<Entity> : List<Entity> where Entity : class
    {
        //Default Paging Size
        private const int PAGE_SIZE = 3;

        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public PaginatedListViewModel(List<Entity> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        public bool HasPreviousPage { get => PageIndex > 1; }

        public bool HasNextPage { get => PageIndex < TotalPages; }

        public static PaginatedListViewModel<Entity> CreateAsync(IEnumerable<Entity> source, int pageIndex)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();
            return new PaginatedListViewModel<Entity>(items, count, pageIndex, PAGE_SIZE);
        }
    }
}