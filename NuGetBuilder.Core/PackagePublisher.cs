using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;
using NuGet.Commands;

namespace NuGetBuilder.Core
{
    public class PackagePublisher : IPackagePublisher
    {
        PackageServer packageServer = new PackageServer("", "");

        public void PublishNewPackageVersion(ManifestMetadata packageMetadata)
        {
            string packagePath = "";
            string nugetSource = "nuget.org";
            packageServer.PushPackage("key", null, -1, 60 * 1000, false);

            PushCommand cmd = new PushCommand();
            cmd.Arguments.Add("C:\\Packages\\MyPkg.nupkg");
            cmd.Source = "nuget.org";
            cmd.ApiKey = "key";
            cmd.Timeout = 10 * 1000;
            cmd.Execute();

            throw new NotImplementedException();
        }
    }
}
