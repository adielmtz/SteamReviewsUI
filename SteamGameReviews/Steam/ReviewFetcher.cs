using SteamGameReviews.Steam.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SteamGameReviews.Steam
{
    internal static class ReviewFetcher
    {
        public static async Task FetchReviewsAsync(RequestPayload payload)
        {
            AppInfo app = payload.AppInfo;
            string cursor = "*";
            var reviews = new List<Review>(payload.NumReviews);

            if (app.Reviews != null && app.Reviews.Count >= payload.NumReviews)
            {
                return;
            }

            Debug.WriteLine("Fetching reviews [{0}] \"{1}\"", app.Id, app.Name);

            while (reviews.Count < payload.NumReviews)
            {
                Response? response = await MakeRequestAsync(payload, cursor);
                if (response != null)
                {
                    if (response.Reviews.Count == 0)
                    {
                        break;
                    }

                    reviews.AddRange(response.Reviews);
                    cursor = response.Cursor;
                    Debug.WriteLine("Got {0} reviews. Total: {1}", response.Reviews.Count, reviews.Count);
                }
            }

            app.Reviews = reviews;
        }

        private static async Task<Response?> MakeRequestAsync(RequestPayload payload, string cursor)
        {
            var parameters = new Dictionary<string, string>
            {
                { "json", "1" },
                { "filter", "recent" },
                { "language", payload.Language },
                { "cursor", cursor },
                { "review_type", payload.ReviewType },
                { "purchase_type", "all" },
                { "num_per_page", "100" },
            };

            if (!payload.FilterOfftopic)
            {
                parameters["filter_offtopic_activity"] = "0";
            }

            using var encoder = new FormUrlEncodedContent(parameters);
            string query = await encoder.ReadAsStringAsync();

            Debug.WriteLine($"GET {SteamConstants.ApiEndpoint}{payload.AppInfo.Id}?{query}");

            using var client = new HttpClient();
            client.BaseAddress = new Uri(SteamConstants.ApiEndpoint);

            await using var stream = await client.GetStreamAsync($"{payload.AppInfo.Id}?{query}");

            // Deserialize JSON
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            return await JsonSerializer.DeserializeAsync<Response>(stream, options);
        }
    }
}
