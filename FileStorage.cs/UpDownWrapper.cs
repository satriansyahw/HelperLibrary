using FileStorage.Download;
using FileStorage.FolderFile;
using FileStorage.MiscClass;
using FileStorage.Upload;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileStorage
{
    public class UpDownWrapper : IStorageDownload, IStorageUpload, IFileDelete,IFolderManagement, IStorageDownloadAsync, IStorageUploadAsync, IFileDeleteAsync
    {
        StorageType StorageType = StorageType.LocalNetwork;
        IFileManagement fileManagement = FolderFileBantuan.GetInstance.DictFile[StorageType.LocalNetwork];
        IFileManagementAsync fileManagementAsync = FolderFileBantuan.GetInstance.DictFileAsync[StorageType.LocalNetwork];
        IFolderManagement folderManagement = FolderFileBantuan.GetInstance.DictFolder[StorageType.LocalNetwork];
        public UpDownWrapper(StorageType storageType)
        {
            this.StorageType = storageType;
            fileManagement = FolderFileBantuan.GetInstance.DictFile[this.StorageType];
            fileManagementAsync = FolderFileBantuan.GetInstance.DictFileAsync[this.StorageType];
            folderManagement = FolderFileBantuan.GetInstance.DictFolder[this.StorageType];
        }

        public StorageReturnValue CheckFolderAndCreate(string pathFolderName)
        {
            return folderManagement.CheckFolderAndCreate(pathFolderName);
        }

        public StorageReturnValue CheckFolderExist(string pathFolderName)
        {
            return folderManagement.CheckFolderExist(pathFolderName);
        }

        public StorageReturnValue CreateFolder(string pathFolderName)
        {
            return folderManagement.CreateFolder(pathFolderName);
        }

        public StorageReturnValue DeleteFile(string pathFileNameWithExt)
        {
           
            return fileManagement.DeleteFile(pathFileNameWithExt);
        }

        public async Task<StorageReturnValue> DeleteFileAsync(string pathFileNameWithExt)
        {
            return await fileManagementAsync.DeleteFileAsync(pathFileNameWithExt);
        }

        public StorageReturnValue DeleteFolder(string pathFolderName)
        {
            return folderManagement.DeleteFolder(pathFolderName);
        }

       public StorageReturnValue  DownloadFile(string downloadToLocation, string fileNameWithExt)
        {
            return DownloadBantuan.GetInstance.DictDownload[this.StorageType].DownloadFile(downloadToLocation, fileNameWithExt);
        }

       public StorageReturnValue  DownloadFile(string downloadToLocation, List<string> fileNameWithExtList)
        {
            return DownloadBantuan.GetInstance.DictDownload[this.StorageType].DownloadFile(downloadToLocation, fileNameWithExtList);
        }

        public async Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, string fileNameWithExt)
        {
            return await DownloadBantuan.GetInstance.DictDownloadAsync[this.StorageType].DownloadFileAsynch(downloadToLocation, fileNameWithExt);
        }

        public async Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, List<string> fileNameWithExtList)
        {
            return await DownloadBantuan.GetInstance.DictDownloadAsync[this.StorageType].DownloadFileAsynch(downloadToLocation, fileNameWithExtList);
        }

        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            return UploadBantuan.GetInstance.DictUpload[this.StorageType].UploadFile(uploadToLocation, uploadedFile);
        }

        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)
        {
            return UploadBantuan.GetInstance.DictUpload[this.StorageType].UploadFile(uploadToLocation, uploadedFile, sizeLimit);
        }

        public async Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            return await UploadBantuan.GetInstance.DictUploadAsync[this.StorageType].UploadFileAsync(uploadToLocation, uploadedFile);
        }

        public async Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)
        {
            return await UploadBantuan.GetInstance.DictUploadAsync[this.StorageType].UploadFileAsync(uploadToLocation, uploadedFile,sizeLimit);
        }

      
    }
}
