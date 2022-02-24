using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

namespace aiola
{
    public static class Packages
    {
        public static async Task ReplacePackageFromGist(string id, string user = "aiola13")
        {
            var url = GetGistUrl(id, user);
            var contents = await GetContents(url);
            ReplacePackageFile(contents);
        }
        public static string GetGistUrl(string id, string user = "aiola13") =>
            $"https://gist.githubusercontent.com/{user}/{id}/raw";

        public static async Task<string> GetContents(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static void ReplacePackageFile(string contents)
        {
            var existing = Path.Combine(Application.dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing,contents);
            UnityEditor.PackageManager.Client.Resolve();
        }

        public static void InstallUnityPackage(string packageName)
        {
            UnityEditor.PackageManager.Client.Add($"com.unity.{packageName}");
        }
    }
}