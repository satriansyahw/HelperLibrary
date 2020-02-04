using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FolderFTP:IFolderManagement
    {
        private static FolderFTP instance;
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

        public StorageReturnValue CheckFolderAndCreate(string folderName)
        {
            throw new NotImplementedException();
        }

        public StorageReturnValue CheckFolderExist(string folderName)
        {
            throw new NotImplementedException();
        }

        public StorageReturnValue CreateFolder(string folderName)
        {
            throw new NotImplementedException();
        }

        public StorageReturnValue DeleteFolder(string folderName)
        {
            throw new NotImplementedException();
        }
    }
}
