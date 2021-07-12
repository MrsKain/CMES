using System;
using System.Collections.Generic;
using System.Text;

namespace Cnty.Core.Model
{
    public class TableColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
