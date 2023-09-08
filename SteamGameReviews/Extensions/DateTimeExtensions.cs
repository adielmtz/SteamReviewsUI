using System;

namespace SteamGameReviews.Extensions
{
    internal static class DateTimeExtensions
    {
        public static string ToISO8601String(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToFileNameString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd_HH.mm.ss");
        }
    }
}
