namespace Utilities.Extensions;

public class LoggingExtension
{
    public static async Task Log(string logMessage)
    {
        try
        {
            var dirPath = @"D:\RiderProjects\ManagementBackEndTestBranch";
            var fileName = Path.Combine(@"D:\Log", "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            await WriteToLog(dirPath, fileName, logMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static async Task WriteToLog(string dir, string file, string content)
    {
        await using var outputFile = new StreamWriter(Path.Combine(dir, file), true);
        await outputFile.WriteLineAsync(
            $"Logged on: {DateTime.Now.ToLongDateString()} " +
            $"at: {DateTime.Now.ToLongTimeString()}" +
            $"{Environment.NewLine}" +
            $"Message: {content} " +
            $"at {DateTime.Now:dddd, dd MMMM yyyy HH:mm:ss.fff}" +
            $"{Environment.NewLine}--------------------{Environment.NewLine}");
    }
}