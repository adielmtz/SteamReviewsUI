using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamGameReviews.Steam.Converters
{
    internal sealed class StringToDoubleConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return double.Parse(reader.GetString()!);
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetDouble();
            }

            throw new JsonException("Conversion not implemented for type: " + reader.TokenType);
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
