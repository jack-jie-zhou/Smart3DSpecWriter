using System;
using System.Collections.Generic;

namespace dbtrans.siteModel;

public partial class CodelistValueView
{
    public Guid Oid { get; set; }

    public Guid TableId { get; set; }

    public Guid? ParentTableId { get; set; }

    public string TableName { get; set; } = null!;

    public string? TableUserName { get; set; }

    public string? ParentTableName { get; set; }

    public string? ParentTableUserName { get; set; }

    public int ValueId { get; set; }

    public string ShortStringValue { get; set; } = null!;

    public string LongStringValue { get; set; } = null!;

    public int? ParentValueId { get; set; }

    public int? SortIndex { get; set; }

    public string? Namespace { get; set; }

    public string? DateCreated { get; set; }

    public string? DateModified { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Author { get; set; }
}
