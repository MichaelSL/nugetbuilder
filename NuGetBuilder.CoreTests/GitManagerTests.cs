using Xunit;
using NuGetBuilder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ninject;

namespace NuGetBuilder.Core.Tests
{
    public class GitManagerTests
    {
        private IKernel ninject = new StandardKernel(new CoreModule());

        [Fact()]
        public void CloneRepositoryTest()
        {
            string repoUrl = @"https://github.com/tamtakoe/oi.select.git";
            string destinationUrl = Path.Combine(GitManager.DEFAULT_CLONE_ROOT, "oi.select");

            if (Directory.Exists(destinationUrl))
            {
                var repoFiles = Directory.EnumerateFiles(destinationUrl);
                Assert.Empty(repoFiles);
            }
            try
            {
                IGitManager manager = ninject.Get<GitManager>();
                manager.CloneRepository(repoUrl);
            }
            catch (Exception cloneException)
            {
                Assert.True(false, cloneException.Message);
            }
            var clonedFiles = Directory.EnumerateFiles(destinationUrl);
            Assert.Contains(clonedFiles, file => file.EndsWith("package.json"));
        }

        [Fact]
        public void FetchChangesTest()
        {
            string repoPath = Path.Combine(GitManager.DEFAULT_CLONE_ROOT, "oi.select");
            Assert.True(Directory.Exists(repoPath), "Repository not found");
            try
            {
                IGitManager manager = ninject.Get<GitManager>();
                manager.FetchChanges(repoPath);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}