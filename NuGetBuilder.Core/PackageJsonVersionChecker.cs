using Newtonsoft.Json;
using NuGet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class NugetPackageVersionChecker
        : IComponentVersionChecker
    {
        public bool CheckVersion(string packageId, string repoPath)
        {
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("http://go.microsoft.com/fwlink/?LinkID=206669");
            var package = repo.FindPackage("maskInput");
            var publishedVersion = package.Version;

            var packageDefinitionFilePath = Path.Combine(repoPath, "package.json");
            if (File.Exists(packageDefinitionFilePath))
            {
                dynamic packageDef = JsonConvert.DeserializeObject(File.ReadAllText(packageDefinitionFilePath));
                var gitVersion = SemanticVersion.Parse(packageDef.version);
                return publishedVersion.CompareTo(gitVersion) < 0;
            }
            else
            {
                throw new NotSupportedException("This Version Checker supports 'package.json' files only.");
            }            
        }
    }
}
