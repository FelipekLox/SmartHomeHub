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

        public void PrintScheduledDevices()
        {
            Console.WriteLine("=== Устройства с активным расписанием ===");
            foreach (var d in Devices)
            {
                if (d is ISchedulable schedulable && (schedulable.ScheduledOn.HasValue || schedulable.ScheduledOff.HasValue))
                {
                    string onStr = schedulable.ScheduledOn?.ToString(@"hh\:mm") ?? "не задано";
                    string offStr = schedulable.ScheduledOff?.ToString(@"hh\:mm") ?? "не задано";
                    Console.WriteLine($"- {d.Name} [{d.Id}]: Вкл в {onStr}, Выкл в {offStr}");
                }
            }
        }

        public void PrintTotalEnergy()
        {
            double totalDailyKwh = 0;
            Console.WriteLine("=== Потребление электроэнергии ===");
            foreach (var d in Devices)
            {
                if (d is IEnergyConsumer consumer)
                {
                    double daily = consumer.CalculateDailyConsumption();
                    totalDailyKwh += daily;
                    Console.WriteLine($"- {d.Name} ({consumer.PowerConsumptionWatt} Вт): {daily:F2} кВт·ч/сутки");
                }
            }
            Console.WriteLine($"Итого за сутки: {totalDailyKwh:F2} кВт·ч");
        }
    }
}