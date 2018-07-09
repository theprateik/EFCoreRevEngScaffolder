using Microsoft.EntityFrameworkCore.Scaffolding;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreRevEngScaffolder.Pipelines
{
    public class Scaffolder : IReverseEngineerScaffolder
    {

        public ScaffoldedModel ScaffoldModel(string connectionString, IEnumerable<string> tables, IEnumerable<string> schemas, string @namespace, string language, string contextDir, string contextName, ModelReverseEngineerOptions modelOptions, ModelCodeGenerationOptions codeOptions)
        {
            throw new NotImplementedException();
        }
        public SavedModelFiles Save(ScaffoldedModel scaffoldedModel, string outputDir, bool overwriteFiles)
        {
            throw new NotImplementedException();
        }
    }
}
