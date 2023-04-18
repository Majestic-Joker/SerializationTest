using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_Test
{
    public class ItemHolder
    {   
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ListItem>? Items { get; set; }
        public DateTime Date { get; set; }
    }
}
