Zoltu.JsonNet.Converters
========================

JSON.NET converters including: MillisecondTimeSpanJsonConverter

Usage
-----
```c#
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
```
