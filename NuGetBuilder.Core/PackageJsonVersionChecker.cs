using NuGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class PackageJsonVersionChecker : IComponentVersionChecker
    {
        public bool CheckVersion(SemanticVersion version, string repoPath)
        {
            throw new NotImplementedException();
        }
    }
}
