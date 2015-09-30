using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuGetBuilder.Core
{
    public class GitManager : IGitManager
    {
        public const string DEFAULT_CLONE_ROOT = @"c:\NuGetBuilder\Git";

        public string GitPath { get; set; }

        public string CloneRepository(string repoUrl, string login = null, string password = null, string destination = DEFAULT_CLONE_ROOT, string branchName = "master")
        {
            var repoName = repoUrl.Substring(repoUrl.LastIndexOf('/') + 1).Replace(".git", "");
            if (login == null && password == null && branchName == "master")
            {
                return LibGit2Sharp.Repository.Clone(repoUrl, Path.Combine(destination, repoName));
            }
            else
            {
                return LibGit2Sharp.Repository.Clone(repoUrl, Path.Combine(destination, repoName), new CloneOptions
                {
                    BranchName = branchName,
                    CredentialsProvider = new CredentialsHandler((url, username, credentialsType) =>
                    {
                        switch (credentialsType)
                        {
                            case SupportedCredentialTypes.Default:
                                return new DefaultCredentials();
                            case SupportedCredentialTypes.UsernamePassword:
                                return new UsernamePasswordCredentials()
                                {
                                    Password = password,
                                    Username = username ?? login
                                };
                        }
                        throw new NotImplementedException();
                    })
                });
            }
        }

        public string ActualizeRepositoryContents(string url)
        {
            throw new NotImplementedException();
        }

        public void FetchChanges(string repoPath)
        {
            Repository repository = new Repository(repoPath);
            repository.Fetch("origin");
        }
    }
}
