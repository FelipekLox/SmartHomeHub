using System;

namespace SmartHomeHub
{
    public class SmartLight : SmartDevice, IAdjustable, IReportable, ISchedulable
    {
        public int Level { get; private set; } // Яркость 0–100
        public TimeSpan? ScheduledOn { get; private set; }
        public TimeSpan? ScheduledOff { get; private set; }

        public SmartLight(string id, string name) : base(id, name) { }

        public void SetLevel(int level)
        {
            if (level < 0 || level > 100)
                throw new ArgumentOutOfRangeException(nameof(level), "Яркость должна быть от 0 до 100.");
            Level = level;
        }

        public void ScheduleOn(TimeSpan time) => ScheduledOn = time;
        public void ScheduleOff(TimeSpan time) => ScheduledOff = time;

        public override string GetStatus() => $"{base.GetStatus()}, Яркость: {Level}%";
        public string GetShortReport() => $"Лампа [{Name}]: яркость {Level}%";
    }
}