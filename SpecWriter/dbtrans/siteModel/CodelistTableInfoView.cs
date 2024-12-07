using System;
using System.Collections.Generic;

namespace dbtrans.siteModel;

public partial class CodelistTableInfoView
{
    public Guid Oid { get; set; }

    public Guid TableId { get; set; }

    public Guid? ParentTableId { get; set; }

    public Guid? ChildTableId { get; set; }

    public string? Name { get; set; }

    public string? UserName { get; set; }

    public string? ParentTableName { get; set; }

    public string? ParentTableUserName { get; set; }

    public string? ChildTableName { get; set; }

    public string? ChildTableUsername { get; set; }

    public string? Description { get; set; }

    public string? Namespace { get; set; }

    public string? DateCreated { get; set; }

    public string? DateModified { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Author { get; set; }
}
