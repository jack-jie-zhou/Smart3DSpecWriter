using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodelistUserControl.DBClasses
{
    public class CodelistTableInfoView
    {
        public string Oid { get; set; }

        public string TableId { get; set; }

        public string ParentTableId { get; set; }

        public string ChildTableId { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string ParentTableName { get; set; }

        public string ParentTableUserName { get; set; }

        public string ChildTableName { get; set; }

        public string ChildTableUsername { get; set; }

        public string Description { get; set; }

        public string Namespace { get; set; }

        public string DateCreated { get; set; }

        public string DateModified { get; set; }

        public bool IsDeleted { get; set; }

        public string Author { get; set; }
    }
}
