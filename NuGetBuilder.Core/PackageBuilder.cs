using NuGet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class PackageBuilder : IPackageBuilder
    {
        public const string DEFAULT_PACKAGES_SAVE_PATH = @"c:\NuGetBuilder\NuGetPackages";

        public void BuildPackage(string baseUrl, ManifestMetadata metadata, ManifestFile[] files)
        {
            NuGet.PackageBuilder packageBuilder = new NuGet.PackageBuilder();
            packageBuilder.Populate(metadata);
            packageBuilder.PopulateFiles(baseUrl, files);
            var saveDir = Path.Combine(DEFAULT_PACKAGES_SAVE_PATH, packageBuilder.Id, packageBuilder.Version.ToString().Replace('.', '_'));
            Directory.CreateDirectory(saveDir);
            var saveStream = File.Create(Path.Combine(saveDir, packageBuilder.Id + ".nupkg"));
            packageBuilder.Save(saveStream);
        }
    }
}
