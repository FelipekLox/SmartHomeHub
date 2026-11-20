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

            manager.SetLevelForAllAdjustable(4);
            manager.PrintAllStatuses();
            Console.WriteLine();
            manager.PrintScheduledDevices();
            Console.WriteLine();
            manager.PrintTotalEnergy();

            Console.ReadKey();
        }
    }
}
