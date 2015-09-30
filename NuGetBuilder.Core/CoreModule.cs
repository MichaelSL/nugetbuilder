using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPackageDefinitionsRepository>().To<MockPackageDefinitionsRepository>();
            Bind<IComponentVersionChecker>().To<PackageJsonVersionChecker>();
            Bind<IPackageContentUtils>().To<PackageJsonContentUtils>();
            Bind<IPackagePublisher>().To<PackagePublisher>();
            Bind<IGitManager>().To<GitManager>();
            Bind<IPackageBuilder>().To<PackageBuilder>();
        }
    }
}
