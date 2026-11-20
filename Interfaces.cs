using System;

namespace SmartHomeHub
{
    public interface IAdjustable
    {
        int Level { get; }
        void SetLevel(int level);
    }

    public interface IReportable
    {
        string GetShortReport();
    }

    public interface ISchedulable
    {
        TimeSpan? ScheduledOn { get; }
        TimeSpan? ScheduledOff { get; }
        void ScheduleOn(TimeSpan time);
        void ScheduleOff(TimeSpan time);
    }

    public interface IEnergyConsumer
    {
        double PowerConsumptionWatt { get; }
        double CalculateDailyConsumption();
    }
}