using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SampleDuplicateFileFinder.ViewModel;

namespace SampleDuplicateFileFinder.Views
{
    /// <summary>
    /// Interaction logic for FindDuplicateFileView.xaml
    /// </summary>
    public partial class FindDuplicateFileView : UserControl
    {
        public FindDuplicateFileView()
        {
            InitializeComponent();
            BindingCommands();
            Drives = new ObservableCollection<DriveViewModel>();
            OnRefresh();
            DataContext = this;
        }

        private void OnRefresh()
        {
            Drives.Clear();
            var driveList = DriveInfo.GetDrives().Where(x => x.IsReady).Select(x => new DriveViewModel(x));
            foreach (DriveViewModel drive in driveList)
            {
                Drives.Add(drive);
            }
        }

        public ObservableCollection<DriveViewModel> Drives { get; set; }

        private void CheckBoxDrive_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chkDrive = (CheckBox)sender;
            var note = $"Drive Name is";
            textBlock.Text = (bool)chkDrive.IsChecked ? $"{note}  selected" : $"{note}  unselected";
        }

        private void TreeView_Expanded(object sender, RoutedEventArgs e)
        {
            var treeViewItem = (TreeViewItem)e.OriginalSource;
            if (treeViewItem.DataContext is DirectoryViewModel parent)
            {
                if(!(parent.SubFolder.Count == 1 && parent.SubFolder[0] == DirectoryViewModel.UnExpanded))
                    return;
                parent.SubFolder.Clear();
                var option = new EnumerationOptions();
                foreach (var directoryInfo in parent.DirectoryInfo.GetDirectories("*", option))
                {
                    parent.SubFolder.Add(new DirectoryViewModel(directoryInfo));
                }
            } 
            else if (treeViewItem.DataContext is DriveViewModel drive)
            {
                if (!(drive.SubFolder.Count == 1 && drive.SubFolder[0] == DirectoryViewModel.UnExpanded))
                    return;
                drive.SubFolder.Clear();
                var option = new EnumerationOptions();
                foreach (var directoryInfo in drive.DriveInfo.RootDirectory.GetDirectories("*", option))
                {
                    drive.SubFolder.Add(new DirectoryViewModel(directoryInfo));
                }
            }
        }

        private void BindingCommands()
        {
            // File Refersh 
            //CommandBindings.Add(new CommandBinding(AppCommands.Refresh, (s, a) => ()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnRefresh();
        }
    }
}
