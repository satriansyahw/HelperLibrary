using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FileStorage.FolderFile;
using FileStorage.MiscClass;

namespace FileStorage.Download
{
    public class DownloadAzure : IStorageDownload,IStorageDownloadAsync
    {
        public DownloadAzure()
        {

        }
        StorageReturnValue result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
        IFileManagement fileManagement = FolderFileBantuan.GetInstance.DictFile[StorageType.Azure];
        IFileManagementAsync fileManagementAsync = FolderFileBantuan.GetInstance.DictFileAsync[StorageType.Azure];
        private static DownloadAzure instance;
        public static DownloadAzure GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new DownloadAzure();
                return instance;
            }
        }

       public StorageReturnValue  DownloadFile(string downloadToLocation, string fileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            string pathFileName = Path.Combine(downloadToLocation, fileNameWithExt);
            if (!string.IsNullOrEmpty(pathFileName))
            {
                pathFileName = pathFileName.Trim();
                result = fileManagement.CreateFileDownload(pathFileName);
            }
            return result;
        }

       public StorageReturnValue  DownloadFile(string downloadToLocation, List<string> fileNameWithExtList)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            
            List<FileStorageAttachment> listFileDownload = new List<FileStorageAttachment>();
            foreach (var item in fileNameWithExtList)
            {
                string pathFileName = Path.Combine(downloadToLocation, item.Trim());
                FileStorageAttachment downloaded = null;
                result = fileManagement.CreateFileDownload(pathFileName);
                if (result.IsSuccess)
                {
                    downloaded = (FileStorageAttachment)result.ListFile[0];
                    result.IsSuccess = true;
                    result.ListFile.Add(downloaded);
                }
                else
                {
                    result.ErrorMessage = FileStorageProperties.GetInstance.WrongFileDownload;
                }

            }
            return result;
        }

        public virtual async Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, string fileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            string pathFileName = Path.Combine(downloadToLocation, fileNameWithExt);
            if (!string.IsNullOrEmpty(pathFileName))
            {
                pathFileName = pathFileName.Trim();
                result = await fileManagementAsync.CreateFileDownloadAsync(pathFileName);
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, List<string> fileNameWithExtList)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);

            List<FileStorageAttachment> listFileDownload = new List<FileStorageAttachment>();
            foreach (var item in fileNameWithExtList)
            {
                string pathFileName = Path.Combine(downloadToLocation, item.Trim());
                FileStorageAttachment downloaded = null;
                result = await fileManagementAsync.CreateFileDownloadAsync(pathFileName);
                if (result.IsSuccess)
                {
                    downloaded = (FileStorageAttachment)result.ListFile[0];
                    result.IsSuccess = true;
                    result.ListFile.Add(downloaded);
                }
                else
                {
                    result.ErrorMessage = FileStorageProperties.GetInstance.WrongFileDownload;
                }

            }
            return result;
        }
    }
}
