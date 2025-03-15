using System.Collections.ObjectModel;
using System.Management;
using CommunityToolkit.Mvvm.ComponentModel;
using UI.Models;

namespace UI.ViewModels;

internal sealed class CpuViewModel : ObservableObject, ICpuViewModel
{
    private ObservableCollection<CpuInformationModel> _cpuInformationModels = [];

    public ObservableCollection<CpuInformationModel> CpuInformationModels
    {
        get => _cpuInformationModels;
        set => SetProperty(ref _cpuInformationModels, value);
    }

    void ICpuViewModel.Load()
    {
        LoadCpuInformation();
    }
    
    private void LoadCpuInformation()
    {
        var list = new List<CpuInformationModel>();
        
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

            foreach (var obj in searcher.Get())
            {
                list.Add(new CpuInformationModel
                {
                    Name = obj["Name"].ToString(),
                    Manufacturer = obj["Manufacturer"].ToString(),
                    Description = obj["Description"].ToString(),
                    NumberOfCores = obj["NumberOfCores"].ToString(),
                    NumberOfLogicalProcessors = obj["NumberOfLogicalProcessors"].ToString(),
                    MaxClockSpeed = obj["MaxClockSpeed"].ToString(),
                    Architecture = obj["Architecture"].ToString(),
                    ProcessorId = obj["ProcessorId"].ToString(),
                    L2CacheSize = obj["L2CacheSize"].ToString(),
                    L3CacheSize = obj["L3CacheSize"].ToString(),
                    SocketDesignation = obj["SocketDesignation"].ToString()
                });
            }
        }
        catch
        {
        }
        
        CpuInformationModels = new ObservableCollection<CpuInformationModel>(list);
    }
}