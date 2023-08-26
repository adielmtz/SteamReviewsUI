using SteamGameReviews.Steam.Converters;
using System;
using System.Text.Json.Serialization;

namespace SteamGameReviews.Steam.Entities
{
    internal sealed class Author
    {
        [JsonPropertyName("steamid")]
        [JsonConverter(typeof(StringToLongConverter))]
        public required long Id { get; init; }

        [JsonPropertyName("num_games_owned")]
        public required int GamesOwned { get; init; }

        [JsonPropertyName("num_reviews")]
        public required int WrittenReviews { get; init; }

        [JsonPropertyName("playtime_forever")]
        [JsonConverter(typeof(NumberToTimeSpanConverter))]
        public required TimeSpan PlaytimeForever { get; init; }

        [JsonPropertyName("playtime_last_two_weeks")]
        [JsonConverter(typeof(NumberToTimeSpanConverter))]
        public required TimeSpan PlaytimeLastTwoWeeks { get; init; }

        [JsonPropertyName("playtime_at_review")]
        [JsonConverter(typeof(NumberToTimeSpanConverter))]
        public required TimeSpan PlaytimeAtReview { get; init; }

        [JsonPropertyName("last_played")]
        [JsonConverter(typeof(NumberToDateTimeConverter))]
        public required DateTime LastPlayed { get; init; }
    }
}
