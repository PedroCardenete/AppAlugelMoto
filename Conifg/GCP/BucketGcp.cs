using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace TestApplication.Conifg.GCP;

public class BucketGcp
{
    public void UploadFile(
        string bucketName = "your-unique-bucket-name",
        string localPath = "my-local-path/my-file-name",
        string objectName = "my-file-name")
    {
        var storage = StorageClient.Create();
        using var fileStream = File.OpenRead(localPath);
        storage.UploadObject(bucketName, objectName, null, fileStream);
        Console.WriteLine($"Uploaded {objectName}.");
    }
}