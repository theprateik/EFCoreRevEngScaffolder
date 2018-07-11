using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRevEngScaffolder.Pipelines
{
    public class CustomCandidateNamingService : ICandidateNamingService
    {
        public string GenerateCandidateIdentifier(DatabaseTable originalTable)
        {
            throw new NotImplementedException();
        }

        public string GenerateCandidateIdentifier(DatabaseColumn originalColumn)
        {
            throw new NotImplementedException();
        }

        public string GetDependentEndCandidateNavigationPropertyName(IForeignKey foreignKey)
        {
            throw new NotImplementedException();
        }

        public string GetPrincipalEndCandidateNavigationPropertyName(IForeignKey foreignKey, string dependentEndNavigationPropertyName)
        {
            throw new NotImplementedException();
        }
    }
}
