using Octokit;
using System;
using System.Threading.Tasks;

namespace ConsoleAppGetGitHubRepos
{
  internal class Program
  {
    static async Task Main()
    {
      // Remplacez par votre jeton personnel GitHub
      var client = new GitHubClient(new ProductHeaderValue("MyApp"));

      var tokenAuth = new Credentials("YOUR_PERSONAL_ACCESS_TOKEN");
      client.Credentials = tokenAuth;

      var user = "octocat"; // Remplacez par le nom d'utilisateur GitHub que vous souhaitez consulter
      var repositories = await client.Repository.GetAllForUser(user);

      foreach (var repo in repositories)
      {
        Console.WriteLine($"Name: {repo.Name}");
        Console.WriteLine($"Description: {repo.Description}");
        Console.WriteLine($"URL: {repo.HtmlUrl}");
        Console.WriteLine();
      }

      Console.WriteLine("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
