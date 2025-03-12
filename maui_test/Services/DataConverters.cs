namespace maui_test.Services
{
    public static class DataConverters
    {
        public static DateTimeOffset UnixTimeStapToDataTimeOffset(long unixTimeStamp)
        {
            DateTimeOffset dateTimeOffset = new(1970, 1, 1, 0, 0, 0, 0, default);
            return dateTimeOffset.AddSeconds(unixTimeStamp);
        }

    }
}
