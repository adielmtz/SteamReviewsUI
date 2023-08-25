using System.Text.Json.Serialization;

namespace SteamGameReviews.Steam.Entities
{
    internal sealed class QuerySummary
    {
        [JsonPropertyName("num_reviews")]
        public required int NumReviews { get; init; }

        [JsonPropertyName("review_score")]
        public int ReviewScore { get; init; }

        [JsonPropertyName("review_score_desc")]
        public string? ReviewScoreDescription { get; init; }

        [JsonPropertyName("total_positive")]
        public int TotalPositive { get; init; }

        [JsonPropertyName("total_negative")]
        public int TotalNegative { get; init; }

        [JsonPropertyName("total_reviews")]
        public int TotalReviews { get; init; }
    }
}
