namespace SpaceObserver.Framework.JsonConverters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class JsonStringIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    var intStr = reader.GetString();
                    return int.Parse(intStr);

                case JsonTokenType.Number:
                    return reader.GetInt32();

                default:
                    return 0;
            }
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
