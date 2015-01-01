using System;
using Newtonsoft.Json;
using Xunit;
using Zoltu.JsonNet.Converters;

namespace Tests
{
	public class MillisecondTimeSpanJsonConverterTests
	{
		[Fact]
		public void serialize_timespan()
		{
			const String expected = @"""1.02:03:04.0050000""";
			var model = new TimeSpan(1, 2, 3, 4, 5);

			var actual = JsonConvert.SerializeObject(model);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void deserialize_timespan()
		{
			const String json = @"""1.02:03:04.005""";
			var expected = new TimeSpan(1, 2, 3, 4, 5);

			var actual = JsonConvert.DeserializeObject<TimeSpan>(json);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void serialize_timespan_as_milliseconds()
		{
			const String expected = @"5000";
			var inputTimeSpan = TimeSpan.FromMilliseconds(5000);

			var actual = JsonConvert.SerializeObject(inputTimeSpan, new MillisecondTimeSpanJsonConverter());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void deserialize_timespan_as_milliseconds()
		{
			var expected = TimeSpan.FromMilliseconds(5000);
			const String inputJson = @"5000";

			var actual = JsonConvert.DeserializeObject<TimeSpan>(inputJson, new MillisecondTimeSpanJsonConverter());

			Assert.Equal(expected, actual);
		}
	}
}
