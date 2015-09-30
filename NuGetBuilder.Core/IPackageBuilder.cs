using NuGet;

namespace NuGetBuilder.Core
{
    public interface IPackageBuilder
    {
        void BuildPackage(string baseUrl, ManifestMetadata metadata, ManifestFile[] files);
    }
}