﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class PagedList<T>
    {
        public List<T> Content { get; set; }
        public int CurrentPage { get; set; }
        public string PageName { get; set; }
        public int Count { get; set; }
    }
}
