using CommunityToolkit.Mvvm.ComponentModel;
using UI.Services;

namespace UI.ViewModels;

internal sealed class LiveMonitoringViewModel : ObservableObject, ILiveMonitoringViewModel
{
    private HardwareMonitorService _monitorService;
    // private readonly HardwareMonitorService _monitorService;

    public HardwareMonitorService MonitorService
    {
        get => _monitorService;
        set => SetProperty(ref _monitorService, value);
    }

    public LiveMonitoringViewModel()
    {
        MonitorService = new HardwareMonitorService();
    }
    // private Computer _computer = new();
    // private Timer _timer;
    // private ObservableCollection<HardwareDataModel> _sensors = [];
    //
    // public ObservableCollection<HardwareDataModel> Sensors
    // {
    //     get => _sensors;
    //     set => SetProperty(ref _sensors, value);
    // }
    //
    // void ILiveMonitoringViewModel.Load()
    // {
    //     OpenComputer();
    //     SetTimer();
    // }
    //
    // private void OpenComputer()
    // {
    //     _computer = new Computer
    //     {
    //         IsCpuEnabled = true,
    //         IsGpuEnabled = true,
    //         IsMemoryEnabled = true,
    //         IsMotherboardEnabled = true,
    //         IsControllerEnabled = true,
    //         IsNetworkEnabled = true,
    //         IsStorageEnabled = true,
    //         IsPsuEnabled = true,
    //         IsBatteryEnabled = true
    //     };
    //     
    //     _computer.Open();
    // }
    //
    // private void SetTimer()
    // {
    //     _timer = new Timer(UpdateHardwareData, null, 0, 1000);
    // }
    //
    // private void UpdateHardwareData(object? state)
    // {
    //     Sensors.Clear();
    //     var list = new List<HardwareDataModel>();
    //     
    //     foreach (var hardware in _computer.Hardware)
    //     {
    //         hardware.Update();
    //         
    //         foreach (var sensor in hardware.Sensors)
    //         {
    //             if (sensor.SensorType is SensorType.Temperature or SensorType.Load or SensorType.Fan)
    //             {
    //                 list.Add(new HardwareDataModel
    //                 {
    //                     Name = $"{hardware.Name} - {sensor.Name}",
    //                     Value = sensor.Value?.ToString("0.0") ?? "N/A",
    //                     SensorType = sensor.SensorType.ToString()
    //                 });
    //             }
    //         }
    //     }
    //     
    //     Application.Current.Dispatcher.Invoke(() => { Sensors = new ObservableCollection<HardwareDataModel>(list); });
    // }
    //
    // public void Dispose()
    // {
    //     _computer.Close();
    //     _timer.Dispose();
    // }
}