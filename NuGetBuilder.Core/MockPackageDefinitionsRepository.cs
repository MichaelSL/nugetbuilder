using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class MockPackageDefinitionsRepository : IPackageDefinitionsRepository
    {
        public List<PackageDefinition> Packages { get; set; } = new List<PackageDefinition>();

        public void AddPackage(PackageDefinition packageDefinition)
        {
            if (!this.Packages.Contains(packageDefinition))
            {
                this.Packages.Add(packageDefinition);
            }
        }

        public IList<PackageDefinition> GetPackages()
        {
            return this.Packages;
        }
    }
}
