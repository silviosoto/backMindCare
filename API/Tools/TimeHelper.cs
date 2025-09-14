namespace API.Tools
{
    public static class TimeHelper
    {
        public static DateTime GetBogotaTimeNow()
        {
            TimeZoneInfo bogotaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time");
            DateTime utcNow = DateTime.UtcNow;
            DateTime bogotaTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, bogotaTimeZone);
            return bogotaTime;
        }

    }
}
