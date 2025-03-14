namespace UI.Models;

internal sealed class MemoryInformationModel
{
    public long Capacity { get; set; }
    public int Speed { get; set; }
    public string? Manufacturer { get; set; }
    public string? PartNumber { get; set; }
    public string? SerialNumber { get; set; }
    public string? FormFactor { get; set; }
    public string? MemoryType { get; set; }
    public int TotalWidth { get; set; }
    public int DataWidth { get; set; }
    public string? DeviceLocator { get; set; }
    public string? BankLabel { get; set; }
}