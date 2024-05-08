// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

Console.WriteLine("Hello, World");

var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
Console.WriteLine("OS : " + osNameAndVersion);

GetPlatform();

var version = Environment.GetEnvironmentVariable("web_version");
Console.WriteLine("Web Version is : " + version);

WriteToFile();

AWSConfigs.AWSRegion = "us-east-1";

var bucketName = "servicesconfigdev";
IAmazonS3 client = new AmazonS3Client();
var request = new GetObjectRequest
{
    BucketName = bucketName,
    Key = "abc.txt",
};

Console.WriteLine($"Get file from s3");
using GetObjectResponse response = await client.GetObjectAsync(request);
Console.WriteLine($"File received");


try
{
    await response.WriteResponseStreamToFileAsync("abc.txt", true, CancellationToken.None);
    Console.WriteLine($"File saved to docker successfully");
}
catch (AmazonS3Exception ex)
{
    Console.WriteLine($"S3 Error while downloading ");
}
catch (Exception ex)
{
    Console.WriteLine($"General error while downloading from s3 path ");
}

string filePath = Path.Combine("abc.txt");

string fileContent;
using (StreamReader reader = new StreamReader(filePath))
{
    fileContent = reader.ReadToEnd();
}

Console.WriteLine($"After downloading the file from s3, the content is {fileContent}");

Console.WriteLine("Placeholders replaced successfully.");

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