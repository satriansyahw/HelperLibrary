using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;
using System.Linq;
namespace FileStorage.FolderFile
{
    public class FolderFTP:IFolderManagement
    {
        private static FolderFTP instance;
        StorageReturnValue result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
        FTPClient client = new FTPClient();
        public FolderFTP()
        {
        }
        public static FolderFTP GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FolderFTP();
                return instance;
            }
        }

        public virtual StorageReturnValue CheckFolderAndCreate(string folderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (client.FtpCreateDirectory(folderName))
                result = result.SetStorageReturnValue(true, string.Empty, null);
            else
                result = result.SetStorageReturnValue(false, string.Empty, null);
            return result;
        }

        public virtual StorageReturnValue CheckFolderExist(string folderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            var checkDir  = client.ListDirectory(folderName).Where(a => (string)a == folderName).ToList();
            if (checkDir.Count > 0)
                result = result.SetStorageReturnValue(true, string.Empty, null);
            else
                result = result.SetStorageReturnValue(false, string.Empty, null);
            return result;
        }

        public virtual StorageReturnValue CreateFolder(string folderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (client.FtpCreateDirectory(folderName))
                result = result.SetStorageReturnValue(true, string.Empty, null);
            else
                result = result.SetStorageReturnValue(false, string.Empty, null);
            return result;
        }

        public virtual StorageReturnValue DeleteFolder(string folderName)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (client.FtpDeleteDirectory(folderName))
                result = result.SetStorageReturnValue(true, string.Empty, null);
            else
                result = result.SetStorageReturnValue(false, string.Empty, null);
            return result;
        }
    }
}
