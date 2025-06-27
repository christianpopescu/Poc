using LibGit2Sharp;
using LibGit2Sharp.Handlers;
namespace PocCSharpGitSsh
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Path to your local repo
            var repoPath = @"D:\ccp_wrks\CsvCompareTool";

            // Path to your SSH keys
            var sshDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh");

            using var repo = new Repository(repoPath);

            var remote = repo.Network.Remotes["origin"];
            var fetchOptions = new FetchOptions
            {
                CredentialsProvider = (_url, _user, _cred) =>
                    new SshUserKeyCredentials
                    {
                        Username = "git",
                        PublicKey = Path.Combine(sshDir, "github_credentials.pub"),
                        PrivateKey = Path.Combine(sshDir, "github_credentials"),
                        Passphrase = "" // Add if your key is encrypted
                    }
            };

            Commands.Fetch(repo, remote.Name, remote.FetchRefSpecs.Select(x => x.Specification), fetchOptions, null);
        }
    }
}
