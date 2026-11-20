using System;

namespace SmartHomeHub
{
    public class SmartThermostat : SmartDevice, IAdjustable, IReportable
    {
        public int Level { get; private set; } // Температура 15–30

        public SmartThermostat(string id, string name) : base(id, name) { }

        public void SetLevel(int level)
        {
            if (level < 15 || level > 30)
                throw new ArgumentOutOfRangeException(nameof(level), "Температура должна быть от 15 до 30°C.");
            Level = level;
        }

        public override string GetStatus() => $"{base.GetStatus()}, Температура: {Level}°C";
        public string GetShortReport() => $"Термостат [{Name}]: {Level}°C";
    }
}
