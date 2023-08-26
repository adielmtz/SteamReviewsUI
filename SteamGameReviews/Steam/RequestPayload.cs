using SteamGameReviews.Steam.Entities;

namespace SteamGameReviews.Steam
{
    internal sealed class RequestPayload
    {
        public AppInfo AppInfo { get; set; }

        public int NumReviews { get; set; }

        public string Language { get; set; }

        public string ReviewType { get; set; }

        public bool FilterOfftopic { get; set; }
    }
}
