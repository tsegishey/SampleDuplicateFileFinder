using Ninject;
using SampleDuplicateFileFinder.Dialog;
using System.Windows;
using System.Windows.Input;
using SampleDuplicateFileFinder.Views;
using System.Windows.Controls;

namespace SampleDuplicateFileFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindingCommands();
            var view = App.Current.Kernel.Get<FindDuplicateFileView>();
            setView(view);
            Title = App.Name;
            DataContext = this;
        }
        public bool IsBusy { get; set; }
        public Control CurrentView { get; set; }
        private void setView(Control view)
        {
            CurrentView = view;
        }

        private void ShowAboutDialogBox()
        {
            var dialogBox = new AboutDialogBox
            {
                Owner = this
            };

            dialogBox.ShowDialog();
        }

        private void BindingCommands()
        {
            // File Exit 
            CommandBindings.Add(new CommandBinding(AppCommands.Exit, (s, a) => Close()));
            // Help About
            CommandBindings.Add(new CommandBinding(AppCommands.About, (s, a) => ShowAboutDialogBox()));
        }

        private void CheckBoxDrive_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}



