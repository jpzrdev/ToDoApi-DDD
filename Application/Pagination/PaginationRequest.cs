using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Pagination
{
    public class PaginatedRequest
    {
        public int Page { get; set; }
        public int Take { get; set; }
    }
}