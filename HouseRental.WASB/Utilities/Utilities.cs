namespace HouseRental.WASB.Utilities
{
    public static class CustomFunctions
    {
        public static void WriteConsoleLog(string errorLevel, string logLine)
        {
            Console.WriteLine($"[{DateTime.Now:yyyy/MM/dd HH:mm:ss}] [{errorLevel}]> {logLine}");
        }
    }
}
