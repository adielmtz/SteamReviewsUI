using System;

namespace SteamGameReviews.Extensions
{
    internal static class DateTimeExtensions
    {
        public static string ToISO8601String(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
