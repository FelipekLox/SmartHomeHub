using System;

namespace SmartHomeHub
{
    public class SmartLight : SmartDevice, IAdjustable, IReportable
    {
        public int Level { get; private set; } // Яркость 0–100

        public SmartLight(string id, string name) : base(id, name) { }

        public void SetLevel(int level)
        {
            if (level < 0 || level > 100)
                throw new ArgumentOutOfRangeException(nameof(level), "Яркость должна быть от 0 до 100.");
            Level = level;
        }

        public override string GetStatus() => $"{base.GetStatus()}, Яркость: {Level}%";
        public string GetShortReport() => $"Лампа [{Name}]: яркость {Level}%";
    }
}