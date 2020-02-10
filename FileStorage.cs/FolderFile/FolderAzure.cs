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

        public virtual StorageReturnValue CheckFolderAndCreate(string pathFolderName)
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
                    var myblob = azure.AzureBlobContainer.GetBlockBlobReference(PathFileName);
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

        public virtual StorageReturnValue CheckFolderExist(string pathFolderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                result = CheckFolderAndCreate(pathFolderName);
            }
            return result;
        }

        public virtual StorageReturnValue CreateFolder(string pathFolderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                result = CheckFolderAndCreate(pathFolderName);
            }
            return result;
        }

        public virtual StorageReturnValue DeleteFolder(string pathFolderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                //BlobContinuationToken blobContinuationToken = null;
                //do
                //{
                //    var azureDirBlob = azure.AzureBlobDirectory(pathFolderName);
                //    var listblob = azureDirBlob.ListBlobsSegmentedAsync(blobContinuationToken).GetAwaiter().GetResult();
                //    blobContinuationToken = listblob.ContinuationToken;
                //    foreach (var item in listblob.Results)
                //    {
                //        if (item is CloudBlobDirectory directory)
                //        {
                //            //DeleteBlobsInDirectoryAsync(azure.StorageContainerName, directory.Prefix);
                //        }
                //        else if (item is CloudPageBlob pageBlob)
                //        {
                //            //CloudPageBlob cloudPageBlob = container.GetPageBlobReference(pageBlob.Name);
                //            //success = await cloudPageBlob.DeleteIfExistsAsync();
                //        }
                //        else if (item is CloudBlockBlob blockBlob)
                //        {
                //            //CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(blockBlob.Name);
                //            //success = await cloudBlockBlob.DeleteIfExistsAsync();
                //        }
                //    }
                //} while (blobContinuationToken != null);
                result = new StorageReturnValue(true, "Temp true, still under construction", null);
            }
            return result;

           
        }
    }
}
