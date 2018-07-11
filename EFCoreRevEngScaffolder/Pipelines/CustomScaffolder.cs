using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreRevEngScaffolder.Abstractions;
using EFCoreRevEngScaffolder.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Diagnostics.Contracts;

namespace EFCoreRevEngScaffolder.Pipelines
{
    public class CustomScaffolder : ReverseEngineerScaffolder, ICustomReverseEngineerScaffolder
    {
        [NotNull] private readonly IDatabaseModelFactory _databaseModelFactory;
        [NotNull] private readonly ICustomScaffoldingModelFactory _scaffoldingModelFactory;
        [NotNull] private readonly IModelCodeGeneratorSelector _modelCodeGeneratorSelector;
        [NotNull] private readonly ICSharpUtilities _cSharpUtilities;
        [NotNull] private readonly ICSharpHelper _cSharpHelper;
        [NotNull] private readonly INamedConnectionStringResolver _connectionStringResolver;
        private const string DbContextSuffix = "Context";
        private const string DefaultDbContextName = "Model" + DbContextSuffix;

        public CustomScaffolder([NotNull] IDatabaseModelFactory databaseModelFactory, [NotNull] ICustomScaffoldingModelFactory scaffoldingModelFactory, [NotNull] IModelCodeGeneratorSelector modelCodeGeneratorSelector, [NotNull] ICSharpUtilities cSharpUtilities, [NotNull] ICSharpHelper cSharpHelper, [NotNull] INamedConnectionStringResolver connectionStringResolver) : base(databaseModelFactory, scaffoldingModelFactory, modelCodeGeneratorSelector, cSharpUtilities, cSharpHelper, connectionStringResolver)
        {
            _databaseModelFactory = databaseModelFactory;
            _scaffoldingModelFactory = scaffoldingModelFactory;
            _modelCodeGeneratorSelector = modelCodeGeneratorSelector;
            _cSharpUtilities = cSharpUtilities;
            _cSharpHelper = cSharpHelper;
            _connectionStringResolver = connectionStringResolver;

        }

        //public ScaffoldedModel ScaffoldModel(string connectionString, IEnumerable<string> tables, IEnumerable<string> schemas, string @namespace,
        //    string language, string contextDir, string contextName, ModelReverseEngineerOptions modelOptions,
        //    ModelCodeGenerationOptions codeOptions)
        //{
        //    var fullTables = tables.Select(x => new EntityType { FileName = x, DisplayName = x, Name = x }).ToList();

        //    return ScaffoldModel(connectionString, fullTables, schemas, @namespace, language, contextDir, contextName,
        //        modelOptions, codeOptions);

        //}

        public ScaffoldedModel ScaffoldModel(string connectionString, [NoEnumeration] IEnumerable<EntityType> tables, IEnumerable<string> schemas, string @namespace,
            string language, string contextDir, string contextName, ModelReverseEngineerOptions modelOptions,
            ModelCodeGenerationOptions codeOptions)
        {
            var entityTypes = tables.ToList();
            var resolvedConnectionString = _connectionStringResolver.ResolveConnectionString(connectionString);
            if (resolvedConnectionString != connectionString)
            {
                codeOptions.SuppressConnectionStringWarning = true;
            }

            var databaseModel = _databaseModelFactory.Create(resolvedConnectionString, entityTypes.Select(x => x.Name).ToList(), schemas);

            var customDatabaseModel = CreateCustomDatabaseModel(databaseModel, entityTypes);
            var model = _scaffoldingModelFactory.Create(customDatabaseModel, modelOptions.UseDatabaseNames);

            if (model == null)
            {
                // TODO: thow some other proper exception
                throw new Exception("Model is null");
                //throw new InvalidOperationException(
                //    DesignStrings.ProviderReturnedNullModel(
                //        _factory.GetType().ShortDisplayName()));
            }

            // TODO: Handle what to do when the contextName is empty
            //if (string.IsNullOrEmpty(contextName))
            //{
            //    contextName = DefaultDbContextName;

            //    var annotatedName = model.Scaffolding().DatabaseName;
            //    if (!string.IsNullOrEmpty(annotatedName))
            //    {
            //        contextName = _cSharpHelper.Identifier(annotatedName + DbContextSuffix);
            //    }
            //}

            var codeGenerator = _modelCodeGeneratorSelector.Select(language);

            return codeGenerator.GenerateModel(model, @namespace, contextDir ?? string.Empty, contextName, connectionString, codeOptions);
        }

        CustomDatabaseModel CreateCustomDatabaseModel([NotNull] DatabaseModel databaseModel, [NotNull][ItemNotNull] IEnumerable<EntityType> tables)
        {
            var entityTypes = tables.ToList();
            var customDatabaseModel = (CustomDatabaseModel) databaseModel;
            customDatabaseModel.Tables = databaseModel.Tables.Cast<CustomDatabaseTable>().ToList();
            for (var i = 0; i < customDatabaseModel.Tables.Count; i++)
            {
                var customEntity = entityTypes.SingleOrDefault(x => x.Name == customDatabaseModel.Tables[i].Name);

                customDatabaseModel.Tables[i].DisplayName = customEntity?.DisplayName;
                customDatabaseModel.Tables[i].Columns =
                    databaseModel.Tables[i].Columns.Cast<CustomDatabaseColumn>().ToList();

                foreach (var column in customDatabaseModel.Tables[i].Columns)
                {
                    column.DisplayName = customEntity?.TableProperties.SingleOrDefault(x => x.Name == column.Name)?.DisplayName;
                }
            }

            return customDatabaseModel;
        }

    }
}
