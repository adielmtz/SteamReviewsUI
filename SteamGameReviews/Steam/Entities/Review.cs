using SteamGameReviews.Steam.Converters;
using System;
using System.Text.Json.Serialization;

namespace SteamGameReviews.Steam.Entities
{
    internal sealed class Review
    {
        [JsonPropertyName("recommendationid")]
        [JsonConverter(typeof(StringToLongConverter))]
        public required long Id { get; init; }

        [JsonPropertyName("author")]
        public required Author Author { get; init; }

        [JsonPropertyName("language")]
        public required string Language { get; init; }

        [JsonPropertyName("review")]
        public required string Text { get; init; }

        [JsonPropertyName("timestamp_created")]
        [JsonConverter(typeof(NumberToDateTimeConverter))]
        public required DateTime DateWritten { get; init; }

        [JsonPropertyName("timestamp_updated")]
        [JsonConverter(typeof(NumberToDateTimeConverter))]
        public required DateTime DateUpdated { get; init; }

        [JsonPropertyName("voted_up")]
        public required bool VotedUp { get; init; }

        [JsonPropertyName("votes_up")]
        public required int VotesUp { get; init; }

        [JsonPropertyName("votes_funny")]
        public required int VotesFunny { get; init; }

        [JsonPropertyName("weighted_vote_score")]
        [JsonConverter(typeof(StringToDoubleConverter))]
        public required double WeightedVoteScore { get; init; }

        [JsonPropertyName("comment_count")]
        public required int CommentCount { get; init; }

        [JsonPropertyName("steam_purchase")]
        public required bool PurchasedOnSteam { get; init; }

        [JsonPropertyName("received_for_free")]
        public required bool ReceivedForFree { get; init; }

        [JsonPropertyName("written_during_early_access")]
        public required bool WrittenDuringEarlyAccess { get; init; }

        [JsonPropertyName("hidden_in_steam_china")]
        public required bool HiddenInChina { get; init; }
    }
}
