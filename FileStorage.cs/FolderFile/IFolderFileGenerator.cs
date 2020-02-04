using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

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
        StorageReturnValue DeleteFile(string fileName);
        StorageReturnValue CreateFileUpload(byte[] fileByte, string pathFileName);
        StorageReturnValue CreateFileDownload(string pathFileName);
    }
}
