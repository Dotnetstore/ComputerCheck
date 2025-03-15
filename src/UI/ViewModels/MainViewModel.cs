using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels;

internal sealed class MainViewModel : ObservableObject, IMainViewModel
{
    private readonly ICpuViewModel _cpuViewModel;
    private readonly IDashboardViewModel _dashboardViewModel;
    private readonly ILiveMonitoringViewModel _liveMonitoringViewModel;
    private readonly IMemoryViewModel _memoryViewModel;
    private IBaseViewModel _currentView = null!;

    public IBaseViewModel CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    public IRelayCommand NavigateToDashboardViewCommand { get; set; }
    public IRelayCommand NavigateToCpuViewCommand { get; set; }
    public IRelayCommand NavigateToLiveMonitoringViewCommand { get; set; }
    public IRelayCommand NavigateToMemoryViewCommand { get; set; }
    public IRelayCommand CloseApplicationCommand { get; set; }
    
    public MainViewModel(
        ICpuViewModel cpuViewModel,
        IDashboardViewModel dashboardViewModel,
        ILiveMonitoringViewModel liveMonitoringViewModel,
        IMemoryViewModel memoryViewModel)
    {
        _cpuViewModel = cpuViewModel;
        _dashboardViewModel = dashboardViewModel;
        _liveMonitoringViewModel = liveMonitoringViewModel;
        _memoryViewModel = memoryViewModel;
        
        NavigateToDashboardViewCommand = new RelayCommand(NavigateToDashboardView);
        NavigateToCpuViewCommand = new RelayCommand(NavigateToCpuView);
        NavigateToLiveMonitoringViewCommand = new RelayCommand(NavigateToLiveMonitoringView);
        NavigateToMemoryViewCommand = new RelayCommand(NavigateToMemoryView);
        CloseApplicationCommand = new RelayCommand(CloseApplication);
    }

    void IMainViewModel.Load()
    {
        SetCurrentView(_dashboardViewModel);
    }

    private void NavigateToDashboardView()
    {
        SetCurrentView(_dashboardViewModel);
    }

    private void NavigateToCpuView()
    {
        _cpuViewModel.Load();
        SetCurrentView(_cpuViewModel);
    }

    private void NavigateToLiveMonitoringView()
    {
        // _liveMonitoringViewModel.Load();
        SetCurrentView(_liveMonitoringViewModel);
    }

    private void NavigateToMemoryView()
    {
        _memoryViewModel.Load();
        SetCurrentView(_memoryViewModel);
    }

    private static void CloseApplication()
    {
        var result = System.Windows.MessageBox.Show(
            "Are you sure you want to close the application?", 
            "Close Application", 
            System.Windows.MessageBoxButton.YesNo, 
            System.Windows.MessageBoxImage.Question);
        
        if (result == System.Windows.MessageBoxResult.Yes)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
    
    private void SetCurrentView(IBaseViewModel viewModel)
    {
        CurrentView = viewModel;
    }
}