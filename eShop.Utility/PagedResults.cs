using System;
using System.Collections.Generic;

namespace eShop.Utility
{
    public class PagedResults<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }      
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }   
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalCount / PageSize); }
        }
        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }



    }
}
