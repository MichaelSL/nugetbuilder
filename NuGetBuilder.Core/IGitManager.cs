namespace NuGetBuilder.Core
{
    public interface IGitManager
    {
        string ActualizeRepositoryContents(string url);
        string CloneRepository(string repoUrl, string login = null, string password = null, string destination = "c:\\NuGetBuilder\\Git", string branchName = "master");
        void FetchChanges(string repoPath);
    }
}