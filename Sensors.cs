namespace SmartHomeHub
{
    public class TemperatureSensor : SmartSensor
    {
        public double CurrentTemperature { get; set; }

        public TemperatureSensor(string id, string name, double currentTemperature)
            : base(id, name)
        {
            CurrentTemperature = currentTemperature;
        }

        public override string GetMeasurement()
        {
            return $"{CurrentTemperature:F1} °C";
        }
    }

    public class MotionSensor : SmartSensor
    {
        public bool IsMotionDetected { get; set; }

        public MotionSensor(string id, string name, bool isMotionDetected)
            : base(id, name)
        {
            IsMotionDetected = isMotionDetected;
        }

        public override string GetMeasurement()
        {
            return IsMotionDetected ? "Обнаружено движение" : "Движения нет";
        }
    }
}
