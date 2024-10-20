﻿using System.Text.Json.Serialization;
using System.Text.Json;
using GTFuckingXP.Information.Level;
using GTFuckingXP.Enums;
using GTFuckingXP.Managers;

namespace GTFuckingXP.Extensions.Information.Level.Json
{
    public sealed class SingleBuffConverter : JsonConverter<SingleUseBuff>
    {
        public override SingleUseBuff? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException("Expected CustomBuff to be an object");
            reader.Read();

            if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException("Expected CustomBuff name or \"CustomBuff\" property");

            SingleUseBuff buff;
            string name = reader.GetString()!;

            // Name:Value case
            if (name.TryToEnum<SingleBuff>(out var singleBuff))
            {
                reader.Read();
                if (reader.TokenType != JsonTokenType.Number) throw new JsonException("Expected CustomBuff name to be followed by a value");

                float value = reader.GetSingle();
                reader.Read();
                buff = new SingleUseBuff(singleBuff, value);
            }
            else // Separate properties case
            {
                buff = new SingleUseBuff(SingleBuff.Invalid, 1f);
                do
                {
                    if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException("Expected property name when parsing CustomBuff");
                    string propertyName = reader.GetString()!;
                    reader.Read();
                    switch (propertyName)
                    {
                        case nameof(SingleUseBuff.SingleBuff):
                            buff.SingleBuff = reader.GetString().ToEnum(SingleBuff.Invalid);
                            break;
                        case nameof(SingleUseBuff.Value):
                            buff.Value = reader.GetSingle();
                            break;
                    }
                } while (reader.Read() && reader.TokenType != JsonTokenType.EndObject);
            }

            if (reader.TokenType == JsonTokenType.EndObject)
                return buff;

            throw new JsonException("Expected EndObject token when parsing CustomBuff");
        }

        public override void Write(Utf8JsonWriter writer, SingleUseBuff value, JsonSerializerOptions options)
        {
            writer.WriteNumber(value.SingleBuff.ToString(), value.Value);
        }
    }
}