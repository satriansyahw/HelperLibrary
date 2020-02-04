using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.FolderFile
{
    public class FolderFileBantuan
    {
        private static FolderFileBantuan instance;
        public FolderFileBantuan()
        {
            this.LoadInitiaFolderMan();
            this.LoadInitialFileMan();
        }
        public static FolderFileBantuan GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FolderFileBantuan();
                return instance;
            }
        }
        public Dictionary<StorageType, IFolderManagement> DictFolderMan = new Dictionary<StorageType, IFolderManagement>();
        private void LoadInitiaFolderMan()
        {
            DictFolderMan.Add(StorageType.LocalNetwork, FolderNetwork.GetInstance);
            DictFolderMan.Add(StorageType.FTP, FolderFTP.GetInstance);
            DictFolderMan.Add(StorageType.Azure,FolderAzure.GetInstance);
          
        }
        public Dictionary<StorageType, IFileManagement> DictFileMan = new Dictionary<StorageType, IFileManagement>();
        private void LoadInitialFileMan()
        {
            DictFileMan.Add(StorageType.LocalNetwork, FileNetwork.GetInstance);
            DictFileMan.Add(StorageType.FTP, FileFTP.GetInstance);
            DictFileMan.Add(StorageType.Azure, FileAzure.GetInstance);

        }
    }
}
