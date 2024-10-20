using System.Text.Json.Serialization;
using System.Text.Json;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Enums;

namespace GTFuckingXP.Extensions.Information.Level.Json
{
    public sealed class CustomBuffConverter : JsonConverter<CustomScalingBuff>
    {
        public override CustomScalingBuff? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException("Expected CustomBuff to be an object");
            reader.Read();

            if (reader.TokenType == JsonTokenType.EndObject)
                return new CustomScalingBuff(CustomScaling.Invalid, 1f);

            if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException("Expected CustomBuff name or \"CustomBuff\" property");

            CustomScalingBuff buff;
            string name = reader.GetString()!;

            // Name:Value case
            if (name.TryToEnum<CustomScaling>(out var customScaling))
            {
                reader.Read();
                if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected CustomBuff name to be followed by a value");

                float value = reader.GetSingle();
                reader.Read();
                buff = new CustomScalingBuff(customScaling, value);
            }
            else // Separate properties case
            {
                buff = new CustomScalingBuff(CustomScaling.Invalid, 1f);
                do
                {
                    if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException("Expected property name when parsing CustomBuff");
                    string propertyName = reader.GetString()!;
                    reader.Read();
                    switch (propertyName)
                    {
                        case nameof(CustomScalingBuff.CustomBuff):
                            if (reader.TokenType == JsonTokenType.String)
                                buff.CustomBuff = reader.GetString().ToEnum(CustomScaling.Invalid);
                            else
                                buff.CustomBuff = (CustomScaling) reader.GetInt32();
                            break;
                        case nameof(CustomScalingBuff.Value):
                            buff.Value = reader.GetSingle();
                            break;
                    }
                } while (reader.Read() && reader.TokenType != JsonTokenType.EndObject);
            }

            if (reader.TokenType == JsonTokenType.EndObject)
                return buff;

            throw new JsonException("Expected EndObject token when parsing CustomBuff");
        }

        public override void Write(Utf8JsonWriter writer, CustomScalingBuff value, JsonSerializerOptions options)
        {
            writer.WriteNumber(value.CustomBuff.ToString(), value.Value);
        }
    }
}
