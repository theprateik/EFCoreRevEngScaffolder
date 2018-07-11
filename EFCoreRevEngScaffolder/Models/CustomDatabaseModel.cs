using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EFCoreRevEngScaffolder.Models
{
    public class CustomDatabaseModel : DatabaseModel
    {
        public new IList<CustomDatabaseTable> Tables { get; set; } = new List<CustomDatabaseTable>();
    }
}
