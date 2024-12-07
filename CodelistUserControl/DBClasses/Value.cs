using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodelistUserControl.DBClasses
{
    class ValueClass
    {
        public ValueClass(int? valueId, string shortstring, string longString)
        {
            ValueId = valueId;
            ShortStringValue = shortstring;
            LongStringValue = longString;
        }
        public int? ValueId { get; set; }
        public string ShortStringValue { get; set; }
        public string LongStringValue { get; set; }
    }
}
