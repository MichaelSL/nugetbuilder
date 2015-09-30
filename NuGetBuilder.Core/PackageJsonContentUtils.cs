using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;

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
            throw new NotImplementedException();
        }
    }
}
