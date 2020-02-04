using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FolderAzure:IFolderManagement
    {
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
