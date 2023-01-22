namespace Utilities.ServiceExtensions.Scheduler.Lib;

public class ScheduledJob
{
    public ScheduledJob(Type type, string scheduleExpession)
    {
        Type = type;
        ScheduleExpession = scheduleExpession;
    }

    public Type Type { get; }
    public string ScheduleExpession { get; }
}