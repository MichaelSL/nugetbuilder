﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public interface IPackageDefinitionsRepository
    {
        IList<PackageDefinition> GetPackages();
        void AddPackage(PackageDefinition packageDefinition);
    }
}
