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

        public void PublishNewPackageVersion(string packagePath)
        {
            
            //string nugetSource = "nuget.org";
            //packageServer.PushPackage("key", null, -1, 60 * 1000, false);

            PushCommand cmd = new PushCommand();
            cmd.Arguments.Add(packagePath);
            cmd.Source = "nuget.org";
            cmd.ApiKey = "4f3ad946-b109-44a7-849e-cc19d799f719";
            cmd.Timeout = 10 * 1000;
            cmd.Execute();

            throw new NotImplementedException();
        }
    }
}
