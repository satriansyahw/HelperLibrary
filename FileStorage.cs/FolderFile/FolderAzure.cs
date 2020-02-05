using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileStorage.MiscClass;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FileStorage.FolderFile
{
    public class FolderAzure:IFolderManagement
    {
        StorageReturnValue result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
        AzureStorage azure = new AzureStorage();
        private static FolderAzure instance;
        public FolderAzure()
        {
        }
        public static FolderAzure GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FolderAzure();
                return instance;
            }
        }

        public StorageReturnValue CheckFolderAndCreate(string pathFolderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                try
                {
                    string localPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string localFileName = "DefaultSystemGenerated_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                    string PathFileName = Path.Combine(pathFolderName, localFileName);
                    var sourceFile = Path.Combine(localPath, localFileName);
                    File.WriteAllText(sourceFile, FileStorageProperties.GetInstance.AzureGeneratedFile);
                    var myblob = azure.AzureBlobontainer.GetBlockBlobReference(PathFileName);
                    myblob.DeleteAsync().Wait();
                    myblob.UploadFromFileAsync(sourceFile).Wait();
                    FileNetwork.GetInstance.DeleteFile(sourceFile);
                    result = result.SetStorageReturnValue(true, string.Empty, null);
                }
                catch (Exception ex) {
                    result = result.SetStorageReturnValue(false, ex.Message, null);
                };
            }
            return result;
        }

        public StorageReturnValue CheckFolderExist(string pathFolderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                result = CheckFolderAndCreate(pathFolderName);
            }
            return result;
        }

        public StorageReturnValue CreateFolder(string pathFolderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                result = CheckFolderAndCreate(pathFolderName);
            }
            return result;
        }

        public StorageReturnValue DeleteFolder(string pathFolderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("your storage account");
                //CloudBlobContainer container = storageAccount.CreateCloudBlobClient().GetContainerReference("pictures");
                foreach (IListBlobItem blob in azure.AzureBlobContainer.GetDirectoryReference(pathFolderName).ListBlobsSegmentedAsync()
                {
                    if (blob.GetType() == typeof(CloudBlob) || blob.GetType().BaseType == typeof(CloudBlob))
                    {
                        ((CloudBlob)blob).DeleteIfExists();
                    }
                }

            }
            return result;

           
        }
    }
}
//https://www.reddit.com/r/csharp/comments/bzj7bf/delete_a_directory_in_azure_storage/
public async Task<bool> DeleteBlobsInDirectoryAsync(string containerName, string blobName)
{
    CloudBlobContainer container = _blobClient.GetContainerReference(containerName);
    CloudBlobDirectory blobDirectory = container.GetDirectoryReference(blobName);
    bool success;

    foreach (IListBlobItem item in blobDirectory.ListBlobs())
    {
        if (item is CloudBlobDirectory directory)
        {
            success = await DeleteBlobsInDirectoryAsync(containerName, directory.Prefix);
        }
        else if (item is CloudPageBlob pageBlob)
        {
            CloudPageBlob cloudPageBlob = container.GetPageBlobReference(pageBlob.Name);
            success = await cloudPageBlob.DeleteIfExistsAsync();
        }
        else if (item is CloudBlockBlob blockBlob)
        {
            CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(blockBlob.Name);
            success = await cloudBlockBlob.DeleteIfExistsAsync();
        }
    }
    return true;
}