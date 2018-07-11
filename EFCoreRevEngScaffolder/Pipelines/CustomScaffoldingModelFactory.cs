using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;
using EFCoreRevEngScaffolder.Abstractions;
using EFCoreRevEngScaffolder.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace EFCoreRevEngScaffolder.Pipelines
{
    public class CustomScaffoldingModelFactory : RelationalScaffoldingModelFactory, ICustomScaffoldingModelFactory
    {
        public IModel Create(CustomDatabaseModel databaseModel, bool useDatabaseNames)
        {
            throw new NotImplementedException();
        }

        public CustomScaffoldingModelFactory([NotNull] IOperationReporter reporter, [NotNull] ICandidateNamingService candidateNamingService, [NotNull] IPluralizer pluralizer, [NotNull] ICSharpUtilities cSharpUtilities, [NotNull] IScaffoldingTypeMapper scaffoldingTypeMapper) : base(reporter, candidateNamingService, pluralizer, cSharpUtilities, scaffoldingTypeMapper)
        {
        }
    }
}
