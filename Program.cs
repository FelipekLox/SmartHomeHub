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

            light.TurnOn();
            thermo.TurnOn();

            manager.AddDevice(light);
            manager.AddDevice(thermo);

            manager.SetLevelForAllAdjustable(22);
            manager.PrintAllStatuses();

            Console.ReadKey();
        }
    }
}