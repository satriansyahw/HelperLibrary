using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.FolderFile
{
    public interface IFolderManagement
    {
        StorageReturnValue CheckFolderExist(string pathFolderName);
        StorageReturnValue CheckFolderAndCreate(string pathFolderName);
        StorageReturnValue CreateFolder(string pathFolderName);
        StorageReturnValue DeleteFolder(string pathFolderName);

    }
    public interface IFileManagement
    {
        StorageReturnValue DeleteFile(string pathFileNameWithExt);
        StorageReturnValue CreateFileUpload(byte[] uploadedFile, string pathFileNameWithExt);
        StorageReturnValue CreateFileDownload(string pathFileNameWithExt);
    }
    public interface IFileManagementAsync
    {
        Task<StorageReturnValue> DeleteFileAsync(string pathFileNameWithExt);
        Task<StorageReturnValue> CreateFileUploadAsync(byte[] uploadedFile, string pathFileNameWithExt);
        Task<StorageReturnValue> CreateFileDownloadAsync(string pathFileNameWithExt);
    }
    public interface IFileDelete
    {
        StorageReturnValue DeleteFile(string pathFileNameWithExt);
    }
    public interface IFileDeleteAsync
    {
        Task<StorageReturnValue> DeleteFileAsync(string pathFileNameWithExt);
    }
}
