using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YB_Create_Web_Api.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
