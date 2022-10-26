using PropertyChanged;
using SmartDuplicateFinder.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SampleDuplicateFileFinder.ViewModel;
[AddINotifyPropertyChangedInterface]
[DebuggerDisplay("Name")]
public class DirectoryViewModel : INotifyPropertyChanged
{
    public static readonly DirectoryViewModel UnExpanded = (null!);
    public event PropertyChangedEventHandler? PropertyChanged;
    internal DirectoryViewModel(DirectoryInfo directoryInfo, DirectoryViewModel parent)
        : this()
    {
        _directoryInfo = directoryInfo!;
        _parent = parent;

        DisplayName = _directoryInfo.Name;
        Name = _directoryInfo.Name;

        if (HasSubFolders())
        {
            SubFolder.Add(UnExpanded);
        }
    }

    private DirectoryViewModel()
    {
        _directoryInfo = null!;
        DisplayName = "Loading...";
        Name = "";

        IsSelectable = true;
        IsSelected = false;
        IsExpandable = false;
        Icon = Icons.OpenFolder;

        SubFolder = new ObservableCollection<DirectoryViewModel>();
    }
    public Icons Icon { get; protected set; }
    public string DisplayName { get; protected set; }
    public string Name { get; protected set; }
    public bool? IsSelected { get; set; }
    public bool IsSelectable {get; set; }
    public bool IsExpandable { get; set; }
    public ObservableCollection<DirectoryViewModel> SubFolder { get; private set; }

    public void LoadSubFolders()
    {
        SubFolder.Clear();

        foreach (var directoryInfo in _directoryInfo.GetDirectories("*", s_options))
        {
            SubFolder.Add(new DirectoryViewModel(directoryInfo, this));
        }
    }

    private bool HasSubFolders() => _directoryInfo.EnumerateDirectories("*", s_options).Any();

    private static readonly EnumerationOptions s_options = new();

    private readonly DirectoryInfo _directoryInfo;
    private readonly DirectoryViewModel? _parent;

}
