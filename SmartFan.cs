using System;

namespace SmartHomeHub
{
    public class SmartFan : SmartDevice, IAdjustable
    {
        public int Level { get; private set; } // Скорость 0–5

        public SmartFan(string id, string name) : base(id, name) { }

        public void SetLevel(int level)
        {
            if (level < 0 || level > 5)
                throw new ArgumentOutOfRangeException(nameof(level), "Скорость вентилятора должна быть от 0 до 5.");
            Level = level;
        }

        public override string GetStatus()
        {
            return $"{base.GetStatus()}, Скорость: {Level}/5";
        }
    }
}
