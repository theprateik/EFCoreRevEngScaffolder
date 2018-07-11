using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using EFCoreRevEngScaffolder.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EFCoreRevEngScaffolder.Abstractions
{
    public interface ICustomScaffoldingModelFactory : IScaffoldingModelFactory
    {
        IModel Create([NotNull] CustomDatabaseModel databaseModel, bool useDatabaseNames);
    }
}
