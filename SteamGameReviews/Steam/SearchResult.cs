namespace SteamGameReviews.Steam
{
    internal sealed class SearchResult
    {
        public required long AppId { get; init; }

        public required string AppName { get; init; }

        public required string ImageUrl { get; init; }
    }
}
