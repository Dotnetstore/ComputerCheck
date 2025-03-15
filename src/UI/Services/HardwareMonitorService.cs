using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using LibreHardwareMonitor.Hardware;
using UI.Models;

namespace UI.Services;

internal sealed class HardwareMonitorService : ObservableObject, IDisposable
{
    private readonly Computer _computer;
    private readonly Timer _updateTimer;
    private ObservableCollection<HardwareDataModel> _sensors = [];

    public ObservableCollection<HardwareDataModel> Sensors
    {
        get => _sensors;
        set => SetProperty(ref _sensors, value);
    }

    public HardwareMonitorService()
    {
        _computer = new Computer
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = true,
            IsMotherboardEnabled = true,
            IsStorageEnabled = true,
            IsBatteryEnabled = true
        };

        _computer.Open();

        _updateTimer = new Timer(UpdateHardwareData, null, 0, 1000);
    }
    
    private void UpdateHardwareData(object? state)
    {
        var list = new List<HardwareDataModel>();
        
        foreach (var hardware in _computer.Hardware)
        {
            hardware.Update();
            
            foreach (var sensor in hardware.Sensors)
            {
                if (sensor.SensorType is SensorType.Temperature or SensorType.Load or SensorType.Fan)
                {
                    list.Add(new HardwareDataModel
                    {
                        Name = $"{hardware.Name} - {sensor.Name}",
                        Value = sensor.Value?.ToString("0.0") ?? "N/A",
                        SensorType = sensor.SensorType.ToString()
                    });
                }
            }
        }
        
        Application.Current.Dispatcher.Invoke(() =>
        {
            Sensors.Clear();
            Sensors = new ObservableCollection<HardwareDataModel>(list);
        });
    }

    public void Dispose()
    {
        _computer.Close();
        _updateTimer.Dispose();
    }
}