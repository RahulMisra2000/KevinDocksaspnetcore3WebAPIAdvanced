using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Helpers
{
    public class PagedList<T>: List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => (CurrentPage > 1);
        public bool HasNext => (CurrentPage < TotalPages);

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            /* ***  IQueryable helps do DEFERRED EXECUTION. It helps you build query piecemeal and then it defers execution 
                    until you do a singleton like .count() .sum() etc OR you have the query iterate by iterating OR using method calls
                    that require an iteration to happen like .ToList() .ToDictionary()
            */
            var count = source.Count();                                                                     // executes query
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();                   // executes query
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
