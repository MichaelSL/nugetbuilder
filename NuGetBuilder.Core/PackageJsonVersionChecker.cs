using NuGet;
using System;
using System.Collections.Generic;
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

            throw new NotImplementedException();
        }
    }
}
