using System;
using System.IO;
using System.Reflection;

namespace SampleDuplicateFileFinder.Utils;

public class CoreAssembly
{
    public static readonly Assembly Assembly = typeof(CoreAssembly).Assembly;
    public static readonly string Folder = Path.GetDirectoryName(Assembly.Location) ?? "";
    public static readonly Version Version = Assembly.GetName().Version?? new Version(0, 0, 0);
}
