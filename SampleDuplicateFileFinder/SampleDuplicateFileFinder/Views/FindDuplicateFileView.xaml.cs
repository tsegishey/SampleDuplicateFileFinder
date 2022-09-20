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
    public partial class FindDuplicateFileView : Window
    {
        public FindDuplicateFileView()
        {
            InitializeComponent();
            Drives = new ObservableCollection<DriveViewModel>();
            var diskDrives = DriveInfo.GetDrives().Where(x => x.IsReady).Select(x => new DriveViewModel(x));
            foreach(DriveViewModel drive in diskDrives)
            {
                Drives.Add(drive);
            }
            DataContext = this;
        }

        public ObservableCollection<DriveViewModel> Drives { get; set; }
    }
}
