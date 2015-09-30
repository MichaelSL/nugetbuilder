using NuGet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class PackageDefinition
    {
        public string GitUrl { get; set; }
        public SemanticVersion Version { get; set; }
    }
}
