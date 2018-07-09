using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRevEngScaffolder.Pipelines
{
    public class ScaffoldingModelFacrory : IScaffoldingModelFactory
    {
        public IModel Create(DatabaseModel databaseModel, bool useDatabaseNames)
        {
            throw new NotImplementedException();
        }
    }
}
