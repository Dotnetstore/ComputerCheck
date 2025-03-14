using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace UI.ViewModels;

internal sealed class MainViewModel : ObservableObject, IMainViewModel
{
    private readonly IDashboardViewModel _dashboardViewModel;
    private readonly IMemoryViewModel _memoryViewModel;
    private IBaseViewModel _currentView = null!;

    public IBaseViewModel CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    public IRelayCommand NavigateToDashboardViewCommand { get; set; }
    public IRelayCommand NavigateToMemoryViewCommand { get; set; }
    public IRelayCommand CloseApplicationCommand { get; set; }
    
    public MainViewModel(
        IDashboardViewModel dashboardViewModel,
        IMemoryViewModel memoryViewModel)
    {
        _dashboardViewModel = dashboardViewModel;
        _memoryViewModel = memoryViewModel;
        
        NavigateToDashboardViewCommand = new RelayCommand(NavigateToDashboardView);
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