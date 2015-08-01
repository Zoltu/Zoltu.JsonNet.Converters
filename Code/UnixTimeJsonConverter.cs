using System;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zoltu.JsonNet.Converters
{
	public class UnixTimeJsonConverter : JsonConverter
	{
		private static readonly DateTimeOffset UnixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

		public override Boolean CanConvert(Type objectType)
		{
			if (objectType == typeof(DateTimeOffset))
				return true;
			else
				return false;
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var jToken = JToken.Load(reader);
			Contract.Assume(jToken != null);
			var secondsSinceEpoch = TimeSpan.FromSeconds(jToken.ToObject<Int64>());
			return UnixEpoch + secondsSinceEpoch;
		}

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			Contract.Assume(writer != null);
			Contract.Assume(value != null);
			var dateTime = (DateTimeOffset)value;
			var timeSinceEpoch = dateTime - UnixEpoch;
			writer.WriteValue((Int64)timeSinceEpoch.TotalSeconds);
		}
	}
}
