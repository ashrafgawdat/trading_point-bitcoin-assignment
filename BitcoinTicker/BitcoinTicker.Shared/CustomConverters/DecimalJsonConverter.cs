using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitcoinTicker.Shared.CustomConverters
{
    public class DecimalJsonConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var invalidFormatException = new FormatException($"Value {reader.GetString()} is not a valid decimal value");

            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (decimal.TryParse(reader.GetString(), out var result))
                        return result;

                    throw invalidFormatException;
                case JsonTokenType.Number:
                    return reader.GetDecimal();
                default:
                    throw invalidFormatException;
            }
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options) =>
            writer.WriteNumberValue(value);
    }
}
