using Ninject;
using NuGet;
using NuGetBuilder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NuGetBuilder.CoreTests
{
    public class RepositoryWatcherTests
    {
        [Fact]
        public void TestMethod1()
        {
            IKernel ninject = new StandardKernel(new CoreModule());

            IPackageDefinitionsRepository repo = ninject.Get<IPackageDefinitionsRepository>();
            foreach(var package in repo.GetPackages())
            {
                IGitManager man = ninject.Get<IGitManager>();
                var repoPath = man.ActualizeRepositoryContents(package.GitUrl);
                IComponentVersionChecker versionChecker = ninject.Get<IComponentVersionChecker>();
                if (versionChecker.CheckVersion(package.Version, repoPath))
                {
                    IPackageContentUtils packageActualizer = ninject.Get<IPackageContentUtils>();
                    ManifestMetadata packageMetadata = packageActualizer.ReadRepositoryMetadata(repoPath);
                    packageMetadata = packageActualizer.GetPackageMetadata(package);

                    List<ManifestFile> manifestFiles = packageActualizer.MakeFilesList(package);

                    Core.IPackageBuilder builder = ninject.Get<Core.IPackageBuilder>();
                    builder.BuildPackage(repoPath, packageMetadata, manifestFiles.ToArray());

                    IPackagePublisher publisher = ninject.Get<IPackagePublisher>();
                    Assert.Throws<NotImplementedException>(() =>
                    {
                        publisher.PublishNewPackageVersion(packageMetadata);
                    });
                }
            }
        }
    }
}
