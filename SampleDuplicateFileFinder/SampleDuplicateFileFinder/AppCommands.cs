using System;
using System.Windows.Input;

namespace SampleDuplicateFileFinder;

public static  class AppCommands
{
    private static readonly Type OwnerType = typeof(AppCommands);
    public static readonly RoutedUICommand Exit = new("Exit", "Exit", OwnerType);
    public static readonly RoutedUICommand Ok = new("Ok", "Ok", OwnerType);
    public static readonly RoutedUICommand Cancel = new("Cancel", "Cancel", OwnerType);
    public static readonly RoutedUICommand Close = new("Close", "Close", OwnerType);
    public static readonly RoutedUICommand About = new("About", "About", OwnerType);
    public static readonly RoutedUICommand Refresh = new("Refresh", "Refresh", OwnerType);
}
