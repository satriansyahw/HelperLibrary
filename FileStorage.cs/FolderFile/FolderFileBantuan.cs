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
            this.LoadInitiaFolder();
            this.LoadInitialFile();
            this.LoadInitialFileAsync();
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
        public Dictionary<StorageType, IFolderManagement> DictFolder = new Dictionary<StorageType, IFolderManagement>();
        private void LoadInitiaFolder()
        {
            DictFolder.Add(StorageType.LocalNetwork, FolderNetwork.GetInstance);
            DictFolder.Add(StorageType.FTP, FolderFTP.GetInstance);
            DictFolder.Add(StorageType.Azure,FolderAzure.GetInstance);
          
        }
        public Dictionary<StorageType, IFileManagement> DictFile= new Dictionary<StorageType, IFileManagement>();
        private void LoadInitialFile()
        {
            DictFile.Add(StorageType.LocalNetwork, FileNetwork.GetInstance);
            DictFile.Add(StorageType.FTP, FileFTP.GetInstance);
            DictFile.Add(StorageType.Azure, FileAzure.GetInstance);

        }
        public Dictionary<StorageType, IFileManagementAsync> DictFileAsync = new Dictionary<StorageType, IFileManagementAsync>();
        private void LoadInitialFileAsync()
        {
            DictFileAsync.Add(StorageType.LocalNetwork, FileNetwork.GetInstance);
            DictFileAsync.Add(StorageType.FTP, FileFTP.GetInstance);
            DictFileAsync.Add(StorageType.Azure, FileAzure.GetInstance);

        }
    }
}
