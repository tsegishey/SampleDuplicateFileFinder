using PropertyChanged;
using SmartDuplicateFinder.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace SampleDuplicateFileFinder.ViewModel;

[AddINotifyPropertyChangedInterface]
[DebuggerDisplay("Name")]
public class DriveViewModel: DirectoryViewModel
{
    static DriveViewModel()
    {
        s_systemDrive = Path.GetPathRoot(Environment.SystemDirectory)!;
    }
    public DriveViewModel(DriveInfo driveInfo)
        : base(driveInfo.RootDirectory, null!)
    {
        Icon = driveInfo.DriveType switch
        {
            DriveType.Fixed => driveInfo.Name.Equals(s_systemDrive, StringComparison.InvariantCultureIgnoreCase) ? Icons.WindowsDrive : Icons.HardDrive,
            DriveType.Network => driveInfo.IsReady ? Icons.NetworkConnectedDrive : Icons.NetworkDisconnectedDrive,
            DriveType.CDRom => Icons.CDRomDrive,
            DriveType.Removable => Icons.RemovableDrive,
            _ => Icons.UnknownDrive
        };

        IsSelectable = (driveInfo.IsReady);
        DisplayName = (driveInfo.IsReady)? $"{driveInfo.VolumeLabel} ({driveInfo.Name[..^1]})": $"({driveInfo.Name[..^1]})";
        Name = (driveInfo.IsReady) ? driveInfo.Name[..^1]: DisplayName;
    }

    private static readonly string s_systemDrive;
}

