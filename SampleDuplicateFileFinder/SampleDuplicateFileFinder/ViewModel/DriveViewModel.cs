using System.IO;

namespace SampleDuplicateFileFinder.ViewModel;

public class DriveViewModel
 {

    public DriveViewModel(DriveInfo driveInfo)
    {
        DriveInfo = driveInfo;
        Name = driveInfo.Name[..^1];
    }

    public string Name { get; protected set; }
    public DriveInfo DriveInfo { get; private set; }
 }

