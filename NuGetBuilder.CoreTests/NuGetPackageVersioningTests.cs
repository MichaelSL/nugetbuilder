using NuGet;
using System;
using System.Linq;
using Xunit;

namespace NuGetBuilder.CoreTests
{
    public class NuGetPackageVersioningTests
    {
        [Fact]
        public void TestFindPackageCommand()
        {
            IPackageRepository repo = PackageRepositoryFactory.Default.CreateRepository("http://go.microsoft.com/fwlink/?LinkID=206669");
            var package = repo.FindPackage("maskInput");
            Assert.True(package.IsLatestVersion);
        }
    }
}
