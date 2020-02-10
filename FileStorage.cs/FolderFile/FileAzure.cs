using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FileAzure : IFileManagement,IFileManagementAsync
    {
        private static FileAzure instance;
        AzureStorage azure = new AzureStorage();
        StorageReturnValue result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
        public FileAzure()
        {
        }
        public static FileAzure GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FileAzure();
                return instance;
            }
        }

        public virtual StorageReturnValue CreateFileDownload(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            try
            {
                Byte[] mybyte = null;
                var myblob = azure.blobContainerInstance.GetBlockBlobReference(pathFileNameWithExt);
                myblob.DownloadToByteArrayAsync(mybyte, 0).GetAwaiter().GetResult();
                FileStorageAttachment fileStorage = new FileStorageAttachment();
                fileStorage.FileAttachment = mybyte;
                fileStorage.FileNameWithExt = pathFileNameWithExt;
                fileStorage.FileNameWithExtRenamed = pathFileNameWithExt;
                var file = new List<FileStorageAttachment>();
                file.Add(fileStorage);
                result = new StorageReturnValue(true, string.Empty, file);
            }
            catch (Exception ex)
            {
                result = new StorageReturnValue(false, ex.Message + " :" + FileStorageProperties.GetInstance.WrongFileUpload, null);
            }
            return result;


        }

        public virtual async Task<StorageReturnValue> CreateFileDownloadAsync(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            try
            {
                Byte[] mybyte = null;
                var myblob = azure.blobContainerInstance.GetBlockBlobReference(pathFileNameWithExt);
                await myblob.DownloadToByteArrayAsync(mybyte, 0);
                FileStorageAttachment fileStorage = new FileStorageAttachment();
                fileStorage.FileAttachment = mybyte;
                fileStorage.FileNameWithExt = pathFileNameWithExt;
                fileStorage.FileNameWithExtRenamed = pathFileNameWithExt;
                var file = new List<FileStorageAttachment>();
                file.Add(fileStorage);
                result = new StorageReturnValue(true, string.Empty, file);
            }
            catch (Exception ex)
            {
                result = new StorageReturnValue(false, ex.Message + " :" + FileStorageProperties.GetInstance.WrongFileUpload, null);
            }
            return result;
        }

        public virtual StorageReturnValue CreateFileUpload(byte[] uploadedFile, string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            try
            {
                var myblob = azure.blobContainerInstance.GetBlockBlobReference(pathFileNameWithExt);
                myblob.UploadFromByteArrayAsync(uploadedFile, 0, uploadedFile.Length).GetAwaiter().GetResult();
                result = new StorageReturnValue(true, string.Empty, null);
            }
            catch(Exception ex)
            {
                result = new StorageReturnValue(false, ex.Message+" :"+FileStorageProperties.GetInstance.WrongFileUpload, null);
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> CreateFileUploadAsync(byte[] uploadedFile, string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            try
            {
                var myblob = azure.blobContainerInstance.GetBlockBlobReference(pathFileNameWithExt);
                await myblob.UploadFromByteArrayAsync(uploadedFile, 0, uploadedFile.Length);
                result = new StorageReturnValue(true, string.Empty, null);
            }
            catch (Exception ex)
            {
                result = new StorageReturnValue(false, ex.Message + " :" + FileStorageProperties.GetInstance.WrongFileUpload, null);
            }
            return result;
        }

        public virtual StorageReturnValue DeleteFile(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            try
            {
                var myblob = azure.blobContainerInstance.GetBlockBlobReference(pathFileNameWithExt);
                myblob.DeleteIfExistsAsync().GetAwaiter().GetResult();
                result = new StorageReturnValue(true, string.Empty, null);
            }
            catch (Exception ex)
            {
                result = new StorageReturnValue(false, ex.Message + " :" + FileStorageProperties.GetInstance.WrongFileDelete, null);
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> DeleteFileAsync(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            try
            {
                var myblob = azure.blobContainerInstance.GetBlockBlobReference(pathFileNameWithExt);
                await myblob.DeleteIfExistsAsync();
                result = new StorageReturnValue(true, string.Empty, null);
            }
            catch (Exception ex)
            {
                result = new StorageReturnValue(false, ex.Message + " :" + FileStorageProperties.GetInstance.WrongFileDelete, null);
            }
            return result;
        }
    }
}
