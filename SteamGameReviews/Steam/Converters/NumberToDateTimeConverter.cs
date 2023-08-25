using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamGameReviews.Steam.Converters
{
    internal sealed class NumberToDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64()).UtcDateTime;
            }

            throw new JsonException("Conversion not implemented for type: " + reader.TokenType);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            var offset = new DateTimeOffset(value);
            writer.WriteNumberValue(offset.ToUnixTimeSeconds());
        }
    }
}
