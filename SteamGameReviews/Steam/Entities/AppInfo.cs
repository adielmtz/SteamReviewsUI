namespace SteamGameReviews.Steam.Entities
{
    internal sealed class AppInfo
    {
        public required long Id { get; init; }

        public required string Name { get; init; }

        public required string ImageUrl { get; init; }
    }
}
