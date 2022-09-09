using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SampleDuplicateFileFinder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            Current = null!;
        }
        public App()
        {
            Current = this;
        }

        public new static App Current { get; private set; }
        public static string Name => Constant.AppName;
    }
}
