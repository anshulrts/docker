// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;

Console.WriteLine("Hello, World");

var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
Console.WriteLine("OS : " + osNameAndVersion);

GetPlatform();

var version = Environment.GetEnvironmentVariable("web_version");
Console.WriteLine("Web Version is : " + version);

WriteToFile();

static void GetPlatform()
{
    string msg1 = "This is a Windows operating system.";
    string msg2 = "This is a Unix operating system.";
    string msg3 = "ERROR: This platform identifier is invalid.";

    switch (Environment.OSVersion.Platform)
    {
        case PlatformID.Win32NT:
        case PlatformID.Win32S:
        case PlatformID.Win32Windows:
        case PlatformID.WinCE:
            Console.WriteLine(msg1);
            break;
        case PlatformID.Unix:
            Console.WriteLine(msg2);
            break;
        default:
            Console.WriteLine(msg3);
            break;
    }
}

static void WriteToFile()
{
    string currfolder = System.IO.Directory.GetCurrentDirectory(); // @"c:\test\Test_C.txt";
    string fullPath = currfolder + "\\aaalog.txt";
    using (StreamWriter writer = new StreamWriter(fullPath, true))
    {
        writer.WriteLine("Test value");
    }
}