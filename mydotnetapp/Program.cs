// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string currfolder = System.IO.Directory.GetCurrentDirectory(); // @"c:\test\Test_C.txt";
string fullPath = currfolder + "\\aaalog.txt";
using (StreamWriter writer = new StreamWriter(fullPath, true))
{
    writer.WriteLine("Test value");
}
