using System.Collections.Generic;
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

            IEnumerable<DriveViewModel> drives = DriveInfo.GetDrives().Where(d => d.IsReady).Select(d => new DriveViewModel(d));
            foreach (DriveViewModel driver in drives)
            {
                Drives.Add(driver);
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
            var parent = (DirectoryViewModel)treeViewItem.DataContext;

            parent.LoadSubFolders();
        }


        private void BindingCommands()
        {
            // File Refersh 
            CommandBindings.Add(new CommandBinding(AppCommands.Refresh, (s, a) => OnRefresh()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnRefresh();
        }
    }
}
