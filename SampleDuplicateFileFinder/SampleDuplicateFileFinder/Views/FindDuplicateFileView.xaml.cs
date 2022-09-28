using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            Drives = new ObservableCollection<DriveViewModel>();
            var driveList = DriveInfo.GetDrives().Where(x => x.IsReady).Select(x => new DriveViewModel(x));
            foreach(DriveViewModel drive in driveList)
            {
                Drives.Add(drive);
            }
            DataContext = this;
        }

        public ObservableCollection<DriveViewModel> Drives { get; set; }

        private void CheckBoxDrive_Click(object sender, RoutedEventArgs e)
        {
            CheckBox chkDrive = (CheckBox)sender;
            var note = $"Drive Name is";
            textBlock.Text = (bool)chkDrive.IsChecked ? $"{note}  selected" : $"{note}  unselected";
        }
    }
}
