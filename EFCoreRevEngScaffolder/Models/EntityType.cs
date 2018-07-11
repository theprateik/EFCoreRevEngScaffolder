using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRevEngScaffolder.Models
{
    public class EntityType
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string FileName { get; set; }
        public string DbSetName { get; set; }
        public IEnumerable<EntityPropertyType> TableProperties { get; set; } = new List<EntityPropertyType>();
    }
}
