using System;
using Newtonsoft.Json;
using Xunit;
using Zoltu.JsonNet.Converters;

namespace Tests
{
	public class UnixTimeJsonConverterTests
	{
		[Fact]
		public void serialize_epoch_with_built_in_serializer()
		{
			const String expected = @"""1980-01-01T00:00:00+00:00""";
			var model = new DateTimeOffset(1980, 1, 1, 0, 0, 0, TimeSpan.Zero);

			var actual = JsonConvert.SerializeObject(model);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void deserialize_epoch_with_built_in_serializer()
		{
			const String json = @"""0001-01-01T00:00:00+00:00""";
			var expected = new DateTimeOffset(1, 1, 1, 0, 0, 0, TimeSpan.Zero);

			var actual = JsonConvert.DeserializeObject<DateTimeOffset>(json);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void serialize_epoch_as_unixtime()
		{
			const String expected = @"0";
			var model = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

			var actual = JsonConvert.SerializeObject(model, new UnixTimeJsonConverter());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void deserialize_epoch_as_unixtime()
		{
			var expected = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
			const String inputJson = @"0";

			var actual = JsonConvert.DeserializeObject<DateTimeOffset>(inputJson, new UnixTimeJsonConverter());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void serialize_nowish_as_unixtime()
		{
			const String expected = @"1438434855";
			var model = new DateTimeOffset(2015, 08, 1, 13, 14, 15, TimeSpan.Zero);

			var actual = JsonConvert.SerializeObject(model, new UnixTimeJsonConverter());

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void deserialize_nowish_as_unixtime()
		{
			var expected = new DateTimeOffset(2015, 08, 1, 13, 14, 15, TimeSpan.Zero);
			const String inputJson = @"1438434855";

			var actual = JsonConvert.DeserializeObject<DateTimeOffset>(inputJson, new UnixTimeJsonConverter());

			Assert.Equal(expected, actual);
		}
	}
}
