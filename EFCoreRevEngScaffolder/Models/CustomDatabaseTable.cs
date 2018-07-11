using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EFCoreRevEngScaffolder.Models
{
    public class CustomDatabaseTable : DatabaseTable
    {
        public virtual string DisplayName { get; [param: CanBeNull] set; }
        public new IList<CustomDatabaseColumn> Columns { get; set; } = new List<CustomDatabaseColumn>();
    }
}
