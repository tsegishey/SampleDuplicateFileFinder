using System;
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
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppEventHandler);

            // testing UnhandledException
            //try
            //{
            //    throw new Exception("Error For testing");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Catch clause caught : {0} \n", e.Message);
            //    MessageBox.Show(e.Message, Name, MessageBoxButton.OK, MessageBoxImage.Error);
            //}
            //throw new Exception("Big Error");
        }

        public new static App Current { get; private set; }
        public static string Name => Constant.AppName;
        public static string ErrorMessage => Constant.AppErrorTerminate;
        static void AppEventHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            string message = $"Unhandled Exception {(args.IsTerminating ? ErrorMessage : "")}";
            if (e is Exception exception)
            {
                message += Environment.NewLine + "Error: ";
                while (true)
                {
                    message += exception.Message;
                    if (exception.InnerException == null)
                        break;

                    message += Environment.NewLine + "Inner: ";
                    exception = exception.InnerException;
                }
                MessageBox.Show(message, Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string msg = $"{message}.\nError Object Type:{(object?)args.ExceptionObject.GetType().FullName}\nError Object:{args.ExceptionObject}";
                MessageBox.Show(msg, Name, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
