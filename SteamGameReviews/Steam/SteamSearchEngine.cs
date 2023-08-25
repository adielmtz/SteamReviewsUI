using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SteamGameReviews.Steam
{
    internal static class SteamSearchEngine
    {
        private const string STEAM_API_SEARCH_ENDPOINT = "https://store.steampowered.com/search/suggest";
        private const string TRADEMARK_SYMBOL = "™";

        private static readonly Regex AppIdRegex = new Regex(@"data-ds-appid=""(\d+)""");
        private static readonly Regex AppNameRegex = new Regex(@"<div\s+class=""match_name\s*""\>(.[^<]+)</div>");
        private static readonly Regex ImageUrlRegex = new Regex(@"<img\s+src=""(.[^""]+)"">");

        public static async Task<IList<SearchResult>> SearchAsync(string term)
        {
            var parameters = new Dictionary<string, string>
            {
                { "term", term },
                { "f", "games" },
                { "cc", "MX" },
                { "realm", "1" },
                { "l", "spanish" },
                { "use_store_query", "1" },
                { "use_search_spellcheck", "1" },
            };

            using var encoder = new FormUrlEncodedContent(parameters);
            string query = await encoder.ReadAsStringAsync();

            Debug.WriteLine($"GET {STEAM_API_SEARCH_ENDPOINT}?{query}");

            using var client = new HttpClient();
            client.BaseAddress = new Uri(STEAM_API_SEARCH_ENDPOINT);

            string response = await client.GetStringAsync($"?{query}");
            return ParseResponseHtml(response);
        }

        private static IList<SearchResult> ParseResponseHtml(string response)
        {
            string[] segments = response.Split("</a>", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var apps = new List<SearchResult>(segments.Length);

            for (int i = 0; i < segments.Length; i++)
            {
                string segment = segments[i].Replace(TRADEMARK_SYMBOL, string.Empty);

                Match appIdMatch = AppIdRegex.Match(segment);
                Match appNameMatch = AppNameRegex.Match(segment);
                Match imageUrlMatch = ImageUrlRegex.Match(segment);

                if (appIdMatch.Success && appNameMatch.Success && imageUrlMatch.Success)
                {
                    var result = new SearchResult
                    {
                        AppId = long.Parse(appIdMatch.Groups[1].Value.Trim()),
                        AppName = appNameMatch.Groups[1].Value.Trim(),
                        ImageUrl = imageUrlMatch.Groups[1].Value.Trim(),
                    };

                    apps.Add(result);
                }
            }

            return apps;
        }
    }
}
