namespace SteamGameReviews.Steam
{
    internal static class SteamConstants
    {
        public static readonly string ApiEndpoint = "https://store.steampowered.com/appreviews/";

        public static readonly int MaxReviewsPerRequest = 100;
        public static readonly int MinReviews = 20;
        public static readonly int MaxReviews = 10000;
    }
}
