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
public class DirectoryViewModel : INotifyPropertyChanged
{
    public static readonly DirectoryViewModel UnExpanded = (null!);
    public event PropertyChangedEventHandler? PropertyChanged;
    internal DirectoryViewModel(DirectoryInfo directoryInfo)
    {
        DirectoryInfo = directoryInfo;
        Icon = Icons.OpenFolder;
        SubFolder = new ObservableCollection<DirectoryViewModel> { UnExpanded };
        DisplayName = DirectoryInfo.Name ?? "Loading...";
        Name = DirectoryInfo.Name ?? "";
        IsExpandable = false;
        IsSelectable = false;
    }
    public Icons Icon { get; private set; }
    public string DisplayName { get; protected set; }
    public string Name { get; protected set; }
    public bool IsSelectable {get; set; }
    public bool IsExpandable { get; set; }
    public DirectoryInfo DirectoryInfo { get; protected set; }
    public ObservableCollection<DirectoryViewModel> SubFolder { get; private set; }

}
