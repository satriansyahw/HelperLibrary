using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FileFTP : IFileManagement,IFileManagementAsync
    {
        private static FileFTP instance;
        FTPClient client = new FTPClient();
        StorageReturnValue result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
        public FileFTP()
        {
        }
        public static FileFTP GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FileFTP();
                return instance;
            }
        }

        public virtual StorageReturnValue CreateFileDownload(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFileNameWithExt))
            {
                result = client.StorageDownload(pathFileNameWithExt);
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> CreateFileDownloadAsync(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            await Task.Run(() => {
                result = this.CreateFileDownload(pathFileNameWithExt);
            });
            return result;

        }

        public virtual StorageReturnValue CreateFileUpload(byte[] uploadedFile, string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFileNameWithExt) & uploadedFile != null)
            {
                pathFileNameWithExt = pathFileNameWithExt.Trim();
                if (client.FtpFileExists(pathFileNameWithExt)) client.FtpDelete(pathFileNameWithExt);
                client.StorageUpload(pathFileNameWithExt, uploadedFile);

            }
            return result;
        }

        public virtual async Task<StorageReturnValue> CreateFileUploadAsync(byte[] uploadedFile, string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            await Task.Run(() => {
                result = this.CreateFileUpload(uploadedFile, pathFileNameWithExt);
            });
            return result;

        }

        public virtual StorageReturnValue DeleteFile(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(pathFileNameWithExt))
            {
                result = client.StorageFtpDelete(pathFileNameWithExt);
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> DeleteFileAsync(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            await Task.Run(()=> {
                result = this.DeleteFile(pathFileNameWithExt);
            });
            return result;

        }
    }
}
