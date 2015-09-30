using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;

namespace NuGetBuilder.Core
{
    public interface IPackageContentUtils
    {
        ManifestMetadata ReadRepositoryMetadata(string repoPath);
        ManifestMetadata GetPackageMetadata(PackageDefinition package);
        List<ManifestFile> MakeFilesList(PackageDefinition package);
    }
}
