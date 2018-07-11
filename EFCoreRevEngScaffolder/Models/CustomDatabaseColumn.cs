using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EFCoreRevEngScaffolder.Models
{
    public class CustomDatabaseColumn : DatabaseColumn
    {
        public virtual string DisplayName { get; [param: CanBeNull] set; }
    }
}
