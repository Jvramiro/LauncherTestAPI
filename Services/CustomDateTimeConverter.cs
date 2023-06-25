using Newtonsoft.Json;
using System.Globalization;

namespace LauncherTestAPI.Services {
    public class CustomDateTimeConverter : JsonConverter<DateTime> {
        private readonly string[] formats = { "dd/MM/yyyy HH:mm:ss", "yyyy-MM-ddTHH:mm:ssZ" };

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer) {
            if (reader.Value == null || string.IsNullOrEmpty(reader.Value.ToString())) {
                return DateTime.MinValue;
            }

            string dateString = reader.Value.ToString();
            DateTime result;

            if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result)) {
                return result;
            }

            return DateTime.MinValue;
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer) {
            writer.WriteValue(value.ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }
    }


}
