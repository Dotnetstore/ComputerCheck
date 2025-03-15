using CommunityToolkit.Mvvm.ComponentModel;
using UI.Services;

namespace UI.ViewModels;

internal sealed class LiveMonitoringViewModel : ObservableObject, ILiveMonitoringViewModel
{
    private HardwareMonitorService _monitorService = null!;

    public HardwareMonitorService MonitorService
    {
        get => _monitorService;
        set => SetProperty(ref _monitorService, value);
    }

    public LiveMonitoringViewModel()
    {
        MonitorService = new HardwareMonitorService();
    }
}