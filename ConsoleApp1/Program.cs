using System;
using ConsoleApp1.APIs;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string AwsAccessKeyId = "AKI..............."; // <--Your acces key id here 
            string AwsSecretAccessKey = "UEL....................................";   // <--Your Acces key here
            string AwsZone = "ap-southeast-1"; // <--Your region

            var service = new MyS3Service(AwsAccessKeyId, AwsSecretAccessKey, AwsZone);

            service.CreateNewBucketAsync("tushigbucket1129", AwsZone);

            service.UploadObjectAsync("tushigbucket1129", DateTime.Now.Ticks.ToString());

            var uploadFileKey = DateTime.Now.Ticks.ToString(); // save the key created
            service.UploadFileAsync("tushigbucket1129", uploadFileKey);

            service.ReadObjectDataAsync("tushigbucket1129", uploadFileKey + "--1"); // Read the last uploaded image

            service.DeleteObject("tushigbucket1129", uploadFileKey + "--1"); // Delete the last uploaded image

            service.GetObjectsList("tushigbucket1129");
        }
    }
}
