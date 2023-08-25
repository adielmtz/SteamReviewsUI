using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamGameReviews.Steam.Converters
{
    internal sealed class StringToLongConverter : JsonConverter<long>
    {
        public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return long.Parse(reader.GetString()!);
            }

            throw new JsonException("Conversion not implemented for type: " + reader.TokenType);
        }

        public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
