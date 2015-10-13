using NuGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public interface IComponentVersionChecker
    {
        bool CheckVersion(string packageId, string repoPath);
    }
}
