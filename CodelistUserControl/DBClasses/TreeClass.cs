using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodelistUserControl.DBClasses
{
    class TreeClass
    {
        public string Name { get; set; }
        public int? ValueId { get; set; }
        public string ShortStringValue { get; set; }
        public string LongStringValue { get; set; }
        public void SetValue(ValueClass value)
        {
            ValueId = value.ValueId;
            ShortStringValue = value.ShortStringValue;
            LongStringValue = value.LongStringValue;
        }
    }
}
