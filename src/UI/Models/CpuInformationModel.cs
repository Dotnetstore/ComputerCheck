namespace UI.Models;

internal sealed class CpuInformationModel
{
    public string? Name { get; set; }
    public string? Manufacturer { get; set; }
    public string? Description { get; set; }
    public string? NumberOfCores { get; set; }
    public string? NumberOfLogicalProcessors { get; set; }
    public string? MaxClockSpeed { get; set; }
    public string? Architecture { get; set; }
    public string? ProcessorId { get; set; }
    public string? L2CacheSize { get; set; }
    public string? L3CacheSize { get; set; }
    public string? SocketDesignation { get; set; }
}