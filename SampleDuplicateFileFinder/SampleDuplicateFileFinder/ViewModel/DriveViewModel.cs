using System.IO;

namespace SampleDuplicateFileFinder.ViewModel;

public class DriveViewModel
 {

    public DriveViewModel(DriveInfo driveInfo)
    {
        DriveInfo = driveInfo;
        Name = driveInfo.Name[..^1];
        TotalSize = driveInfo.TotalSize;
        TotalFreeSpace = driveInfo.TotalFreeSpace;
    }
    public double TotalFreeSpace { get; set; }
    public double TotalSize { get; set; }
    public string Name { get; protected set; }
    public DriveInfo DriveInfo { get; private set; }
 }

