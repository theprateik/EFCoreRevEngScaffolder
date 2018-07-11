using EFCoreRevEngScaffolder.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Scaffolding;
using System.Collections.Generic;

namespace EFCoreRevEngScaffolder.Abstractions
{
    public interface ICustomReverseEngineerScaffolder : IReverseEngineerScaffolder
    {
        ScaffoldedModel ScaffoldModel(
            [NotNull]string connectionString,
            [NotNull][ItemNotNull]IEnumerable<EntityType> tables,
            [NotNull]IEnumerable<string> schemas,
            [NotNull]string @namespace,
            [CanBeNull] string language,
            [CanBeNull] string contextDir,
            [CanBeNull] string contextName,
            [NotNull] ModelReverseEngineerOptions modelOptions,
            [NotNull] ModelCodeGenerationOptions codeOptions);
    }
}
