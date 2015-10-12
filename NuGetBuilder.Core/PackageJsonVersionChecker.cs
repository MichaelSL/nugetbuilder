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
    public class PackageJsonVersionChecker : IComponentVersionChecker
    {
        public bool CheckVersion(SemanticVersion version, string repoPath)
        {
            var packageDefinitionFilePath = Path.Combine(repoPath, "package.json");
            if (File.Exists(packageDefinitionFilePath))
            {
                dynamic packageDef = JsonConvert.DeserializeObject(File.ReadAllText(packageDefinitionFilePath));
                var gitVersion = SemanticVersion.Parse(packageDef.version);
                return version.CompareTo(gitVersion) < 0;
            }
            else
            {
                throw new NotSupportedException("This Version Checker supports 'package.json' files only.");
            }
        }
    }
}
