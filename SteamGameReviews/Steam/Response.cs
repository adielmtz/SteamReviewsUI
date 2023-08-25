using SteamGameReviews.Steam.Converters;
using SteamGameReviews.Steam.Entities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SteamGameReviews.Steam
{
    internal sealed class Response
    {
        [JsonPropertyName("success")]
        [JsonConverter(typeof(NumberToBoolConverter))]
        public required bool Success { get; init; }

        [JsonPropertyName("cursor")]
        public required string Cursor { get; init; }

        [JsonPropertyName("query_summary")]
        public required QuerySummary Summar { get; init; }

        [JsonPropertyName("reviews")]
        public required IList<Review> Reviews { get; init; }
    }
}
