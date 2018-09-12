namespace Questar.OneRoster.Serialization
{
    using System;
    using Common;
    using Newtonsoft.Json;

    public class YearConverter : JsonConverter<Year>
    {
        public override void WriteJson(JsonWriter writer, Year value, JsonSerializer serializer)
            => serializer.Serialize(writer, (int)value);

        public override Year ReadJson(JsonReader reader, Type objectType, Year existingValue, bool hasExistingValue, JsonSerializer serializer)
            => (Year)serializer.Deserialize(reader);
    }
}