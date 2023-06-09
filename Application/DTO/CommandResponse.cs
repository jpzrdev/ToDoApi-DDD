using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class CommandResponse<T>
    {
        public bool Success { get; set; }
        public T Item { get; set; }
    }
}