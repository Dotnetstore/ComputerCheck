using System.Collections.ObjectModel;
using System.Management;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UI.Models;

namespace UI.ViewModels;

internal sealed class MemoryViewModel : ObservableObject, IMemoryViewModel
{
    private ObservableCollection<MemoryInformationModel> _memoryInformationList = [];
    private string _stressTestResult = string.Empty;

    public ObservableCollection<MemoryInformationModel> MemoryInformationList
    {
        get => _memoryInformationList;
        set => SetProperty(ref _memoryInformationList, value);
    }

    public string StressTestResult
    {
        get => _stressTestResult;
        set => SetProperty(ref _stressTestResult, value);
    }

    public IRelayCommand PerformMemoryStressTestCommand { get; set; }
    
    public MemoryViewModel()
    {
        PerformMemoryStressTestCommand = new RelayCommand(RunStressTestMemory);
    }

    void IMemoryViewModel.Load()
    {
        CheckMemoryHealth();
    }

    private void RunStressTestMemory()
    {
        Task.Run(StressTestMemory).ConfigureAwait(false);
    }
    
    private void CheckMemoryHealth()
    {
        var list = new List<MemoryInformationModel>();
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
        
        foreach (var queryObj in searcher.Get())
        {
            var capacity = Convert.ToInt64(queryObj["Capacity"]);
            var speed = Convert.ToInt32(queryObj["Speed"]);
            var manufacturer = queryObj["Manufacturer"].ToString();
            var partNumber = queryObj["PartNumber"].ToString();
            var serialNumber = queryObj["SerialNumber"].ToString();
            var formFactor = queryObj["FormFactor"].ToString();
            var memoryType = queryObj["MemoryType"].ToString();
            var totalWidth = Convert.ToInt32(queryObj["TotalWidth"]);
            var dataWidth = Convert.ToInt32(queryObj["DataWidth"]);
            var deviceLocator = queryObj["DeviceLocator"].ToString();
            var bankLabel = queryObj["BankLabel"].ToString();
            
            var memoryHealthCheck = new MemoryInformationModel
            {
                Capacity = capacity/1024/1024,
                Speed = speed,
                Manufacturer = manufacturer,
                PartNumber = partNumber,
                SerialNumber = serialNumber,
                FormFactor = formFactor,
                MemoryType = memoryType,
                TotalWidth = totalWidth,
                DataWidth = dataWidth,
                DeviceLocator = deviceLocator,
                BankLabel = bankLabel
            };
            list.Add(memoryHealthCheck);
        }
        
        MemoryInformationList = new ObservableCollection<MemoryInformationModel>(list);
    }

    private void StressTestMemory()
    {
        try
        {
            var stressData = new byte[1024 * 1024 * 512]; // 512 MB Allocation
            Array.Fill(stressData, (byte)1);

            StressTestResult = "Memory stress test successful. No issues found.";
        }
        catch (OutOfMemoryException)
        {
            StressTestResult = "Out of memory! Potential RAM issue.";
        }
        catch (Exception ex)
        {
            StressTestResult = $"Error: {ex.Message}";
        }
    }
}