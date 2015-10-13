using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;
using System.IO;
using Newtonsoft.Json;

namespace NuGetBuilder.Core
{
    public class PackageJsonContentUtils : IPackageContentUtils
    {
        public ManifestMetadata GetPackageMetadata(PackageDefinition package)
        {
            throw new NotImplementedException();
        }

        public List<ManifestFile> MakeFilesList(PackageDefinition package)
        {
            throw new NotImplementedException();
        }

        public ManifestMetadata ReadRepositoryMetadata(string repoPath)
        {
            var packageDefinitionFilePath = Path.Combine(repoPath, "package.json");
            if (File.Exists(packageDefinitionFilePath))
            {
                ManifestMetadata resMetadata = new ManifestMetadata();

                dynamic packageDef = JsonConvert.DeserializeObject(File.ReadAllText(packageDefinitionFilePath));

                resMetadata.Authors = this.GetAuthors(packageDef);
                resMetadata.Owners = this.GetOwners(packageDef);
                resMetadata.Id = packageDef.name;
                resMetadata.Summary = "Summary";
                resMetadata.Description = "Description";
                resMetadata.Version = SemanticVersion.Parse(packageDef.version);

                return resMetadata;
            }
            else
            {
                throw new NotSupportedException("This Content Utils implementation supports 'package.json' files only.");
            }
        }

        private string GetOwners(dynamic packageDef)
        {
            return String.Format("{0},{1}", this.GetAuthors(packageDef), "NugetPackageBuilder");
        }

        private string GetAuthors(dynamic packageDef)
        {
            string result = string.Empty;
            try
            {
                result = packageDef.author;
            }
            catch { }
            result = "author"; //also we can try to parse repository field and extract author from url
            return result;
        }
    }
}
