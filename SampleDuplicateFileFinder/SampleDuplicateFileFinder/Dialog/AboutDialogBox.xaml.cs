using SampleDuplicateFileFinder.Utils;
using System.Windows;
using System.Windows.Input;

namespace SampleDuplicateFileFinder.Dialog
{
    /// <summary>
    /// Interaction logic for AboutDialogBox.xaml
    /// </summary>
    public partial class AboutDialogBox : Window
    {
     public AboutDialogBox()
        {
            InitializeComponent();
            BindingCommands();
            GetVersionInfo();
            DataContext = this;
    }
    public string Version { get; set; }
    private void GetVersionInfo()
    {
        Version = CoreAssembly.Version.ToString(2);
    }

    private void BindingCommands()
    {
        CommandBindings.Add(new CommandBinding(AppCommands.Ok, (s, a) => Close()));
    }
}
}



