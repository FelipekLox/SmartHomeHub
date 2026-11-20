using System;

namespace SmartHomeHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new DeviceManager();
            var light = new SmartLight("L1", "Люстра в гостиной");
            var thermo = new SmartThermostat("T1", "Термостат в спальне");
            var fan = new SmartFan("F1", "Напольный вентилятор");

            light.TurnOn();
            thermo.TurnOn();
            fan.TurnOn();

            light.ScheduleOn(new TimeSpan(18, 30, 0));
            light.ScheduleOff(new TimeSpan(23, 0, 0));
            thermo.ScheduleOn(new TimeSpan(7, 0, 0));

            manager.AddDevice(light);
            manager.AddDevice(thermo);
            manager.AddDevice(fan);

            // Добавляем сенсоры
            manager.AddSensor(new TemperatureSensor("S1", "Термометр на улице", -3.5));
            manager.AddSensor(new MotionSensor("S2", "Датчик движения в прихожей", true));

            manager.SetLevelForAllAdjustable(4);
            manager.PrintAllStatuses();
            Console.WriteLine();
            manager.PrintScheduledDevices();
            Console.WriteLine();
            manager.PrintTotalEnergy();
            Console.WriteLine();
            manager.PrintAllMeasurements();

            Console.ReadKey();
        }
    }
}