using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileStorage.FolderFile
{
    public class FolderNetwork : IFolderManagement
    {
        StorageReturnValue result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);

        private static FolderNetwork instance;
        public FolderNetwork()
        {
        }
        public static FolderNetwork GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FolderNetwork();
                return instance;
            }
        }

        private string localNetwork = FileNetworkProperties.GetInstance.NetworkSharing;

        public StorageReturnValue CheckFolderAndCreate(string pathFolderName)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                result = this.CheckFolderExist(pathFolderName);
                if (result.IsSuccess) return result;
                else
                    result = this.CreateFolder(pathFolderName);
            }
            return result;
        }

        public StorageReturnValue CheckFolderExist(string pathFolderName)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                if (FileStorageProperties.GetInstance.FileStorageType == StorageType.LocalNetwork)
                {
                    if (!string.IsNullOrEmpty(localNetwork))
                    {
                        string checkFolderAddress = Path.Combine(localNetwork, pathFolderName);
                        if (Directory.Exists(checkFolderAddress))
                            result = result.SetStorageReturnValue(true, string.Empty, null);
                        else
                            result = result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongFolderManagement, null);
                    }
                }
            }
            return result;
        }

        public StorageReturnValue CreateFolder(string pathFolderName)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                try
                {
                    if (FileStorageProperties.GetInstance.FileStorageType == StorageType.LocalNetwork)
                    {
                        string checkFolderAddress = Path.Combine(localNetwork, pathFolderName);
                        Directory.CreateDirectory(checkFolderAddress);
                        result = result.SetStorageReturnValue(true, string.Empty, null);
                    }
                }
                catch (Exception ex) { result = result.SetStorageReturnValue(false, ex.Message.ToString(), null); }
            }
            return result;
        }

        public StorageReturnValue DeleteFolder(string pathFolderName)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFolderName))
            {
                try
                {
                    if (FileStorageProperties.GetInstance.FileStorageType == StorageType.LocalNetwork)
                    {
                        string checkFolderAddress = Path.Combine(localNetwork, pathFolderName);
                        if (Directory.Exists(checkFolderAddress))
                            Directory.Delete(checkFolderAddress);
                        result = result.SetStorageReturnValue(true, string.Empty, null);
                    }
                }
                catch (Exception ex) { result = result.SetStorageReturnValue(false, ex.Message.ToString(), null); }
            }
            return result;
        }
    }
}
