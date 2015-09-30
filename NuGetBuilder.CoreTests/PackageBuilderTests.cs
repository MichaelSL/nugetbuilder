using Xunit;
using NuGetBuilder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;
using System.IO;
using Ninject;

namespace NuGetBuilder.Core.Tests
{
    public class PackageBuilderTests
    {
        private IKernel ninject = new StandardKernel(new CoreModule());

        [Fact()]
        public void BuildPackageTest()
        {
            Assert.False(File.Exists(Path.Combine(PackageBuilder.DEFAULT_PACKAGES_SAVE_PATH, "BuildPackageTest", "0_0_0_1", "BuildPackageTest.nupkg")), "Test package already exists");

            ManifestMetadata metadata = new ManifestMetadata
            {
                Id = "BuildPackageTest",
                Summary = "Summary",
                Description = "Description",
                Version = "0.0.0.1",
                Authors = "Michael,xUnit",
                Owners = "Michael,xUnit"
            };

            List<ManifestFile> manifestFiles = new List<ManifestFile>();
            manifestFiles.Add(new ManifestFile
            {
                Source = "dist/select.js",
                Target = "content/Scripts/oi.select"
            });
            manifestFiles.Add(new ManifestFile
            {
                Source = "dist/select.css",
                Target = "content/Content/oi.select"
            });

            try
            {
                IPackageBuilder pkgBuilder = ninject.Get<IPackageBuilder>();
                pkgBuilder.BuildPackage(Path.Combine(GitManager.DEFAULT_CLONE_ROOT, "oi.select"), metadata, manifestFiles.ToArray());
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            Assert.True(File.Exists(Path.Combine(PackageBuilder.DEFAULT_PACKAGES_SAVE_PATH, "BuildPackageTest", "0_0_0_1", "BuildPackageTest.nupkg")), "Package file is missing");
        }
    }
}