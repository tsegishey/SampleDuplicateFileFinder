using SampleDuplicateFileFinder.Dialog;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;


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
            Title = App.Name;
            DataContext = this;
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
    }
}



