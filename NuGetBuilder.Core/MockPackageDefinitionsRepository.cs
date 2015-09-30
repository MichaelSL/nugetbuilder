using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class MockPackageDefinitionsRepository : IPackageDefinitionsRepository
    {
        public void AddPackage(PackageDefinition packageDefinition)
        {
            throw new NotImplementedException();
        }

        public IList<PackageDefinition> GetPackages()
        {
            throw new NotImplementedException();
        }
    }
}
