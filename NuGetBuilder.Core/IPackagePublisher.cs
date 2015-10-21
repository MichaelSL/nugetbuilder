using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;

namespace NuGetBuilder.Core
{
    public interface IPackagePublisher
    {
        void PublishNewPackageVersion(string packagePath);
    }
}
