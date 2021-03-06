﻿using System;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zoltu.JsonNet.Converters
{
	public class MillisecondTimeSpanJsonConverter : JsonConverter
	{
		public override Boolean CanConvert(Type objectType)
		{
			if (objectType == typeof(TimeSpan))
				return true;
			else
				return false;
		}

		public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			var jToken = JToken.Load(reader);
			Contract.Assume(jToken != null);
			return TimeSpan.FromMilliseconds((Double)jToken.ToObject<Int64>());
		}

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			Contract.Assume(writer != null);
			Contract.Assume(value != null);
			var timeSpan = (TimeSpan)value;
			writer.WriteValue((Int64)timeSpan.TotalMilliseconds);
		}
	}
}
