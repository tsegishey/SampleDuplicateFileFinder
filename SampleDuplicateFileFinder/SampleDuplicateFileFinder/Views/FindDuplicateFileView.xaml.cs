using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
            var note = $"Drive Name {chkDrive.Content} ";
            textBlock.Text = (bool)chkDrive.IsChecked ? $"{note} is selected" : $"{note} is unselected";
        }
    }
}
