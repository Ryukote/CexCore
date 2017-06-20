using CEXIO.Api.MarketEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CEXIO.Api.Helpers
{
    public class EntityJsonConverter<TEntity> : JsonConverter
        where TEntity : EntityBase
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TEntity));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                return token.ToObject<TEntity>();
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
