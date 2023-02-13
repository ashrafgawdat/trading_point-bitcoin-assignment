using BitcoinTicker.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitcoinTicker.Shared.CustomConverters
{
    public class UnixTimeStampJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var invalidFormatException = new FormatException($"Value {reader.GetString()} is not a valid decimal value");
            var strValue = reader.GetString();

            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (double.TryParse(strValue, out var dblResult))
                        return DateTimeHelpers.UnixTimeStampToDateTime(dblResult);
                    if (DateTime.TryParse(strValue, out var dateResult))
                        return dateResult;

                    throw invalidFormatException;
                case JsonTokenType.Number:
                    dblResult = reader.GetDouble();
                    return DateTimeHelpers.UnixTimeStampToDateTime(dblResult);
                default:
                    throw invalidFormatException;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime dateTimeValue, JsonSerializerOptions options) =>
                writer.WriteStringValue(dateTimeValue.ToString(
                    "u", CultureInfo.InvariantCulture));
    }
}
