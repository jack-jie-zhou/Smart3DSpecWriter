using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodelistUserControl.DBClasses
{
    public class CodelistValueView
    {
        public string Oid { get; set; }

        public string TableId { get; set; }

        public string ParentTableId { get; set; }

        public string TableName { get; set; }

        public string TableUserName { get; set; }

        public string ParentTableName { get; set; }

        public string ParentTableUserName { get; set; }

        public int ValueId { get; set; }

        public string ShortStringValue { get; set; }

        public string LongStringValue { get; set; }

        public int ParentValueId { get; set; }

        public int SortIndex { get; set; }

        public string Namespace { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public string Author { get; set; }
    }
}
