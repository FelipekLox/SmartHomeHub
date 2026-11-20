using System;

namespace SmartHomeHub
{
    public class SmartThermostat : SmartDevice, IAdjustable, IReportable, ISchedulable
    {
        public int Level { get; private set; } // Температура 15–30
        public TimeSpan? ScheduledOn { get; private set; }
        public TimeSpan? ScheduledOff { get; private set; }

        public SmartThermostat(string id, string name) : base(id, name) { }

        public void SetLevel(int level)
        {
            if (level < 15 || level > 30)
                throw new ArgumentOutOfRangeException(nameof(level), "Температура должна быть от 15 до 30°C.");
            Level = level;
        }

        public void ScheduleOn(TimeSpan time) => ScheduledOn = time;
        public void ScheduleOff(TimeSpan time) => ScheduledOff = time;

        public override string GetStatus() => $"{base.GetStatus()}, Температура: {Level}°C";
        public string GetShortReport() => $"Термостат [{Name}]: {Level}°C";
    }
}