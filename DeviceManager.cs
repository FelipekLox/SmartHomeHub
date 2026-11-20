using System;
using System.Collections.Generic;

namespace SmartHomeHub
{
    public class DeviceManager
    {
        public List<SmartDevice> Devices { get; } = new List<SmartDevice>();

        public void AddDevice(SmartDevice device) => Devices.Add(device);

        public void PrintAllStatuses()
        {
            foreach (var d in Devices)
                Console.WriteLine(d.GetStatus());
        }

        public void SetLevelForAllAdjustable(int level)
        {
            foreach (var d in Devices)
            {
                if (d is IAdjustable adjustable)
                {
                    try
                    {
                        adjustable.SetLevel(level);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine($"[{d.Name}] Пропущено: {ex.Message}");
                    }
                }
            }
        }

        public void PrintAllReports()
        {
            foreach (var d in Devices)
            {
                if (d is IReportable reportable)
                    Console.WriteLine(reportable.GetShortReport());
            }
        }
    }
}
