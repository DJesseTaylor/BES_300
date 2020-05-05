using ShoppingAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Models
{
    public class CreateCurbsideOrder
    {
        public string For { get; set; }
        public List<string> Items { get; set; }
    }

    public class CurbsideOrder
    {
        public int Id { get; set; }
        public string For { get; set; }
        public List<string> Items { get; set; }
        public CurbsideOrderStatus Status { get; set; }
    }
}
