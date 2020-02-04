using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileStorage.FolderFile;
using FileStorage.MiscClass;

namespace FileStorage.Download
{
    public class DownloadNetwork:IStorageDownload
    {
        public DownloadNetwork()
        {

        }
        StorageReturnValue result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
        private static DownloadNetwork instance;
        public static DownloadNetwork GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new DownloadNetwork();
                return instance;
            }
        }

        public StorageReturnValue DownloadFile(string pathFileName)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFileName))
            {
                pathFileName = pathFileName.Trim();
                IFileManagement fileManagement = FolderFileBantuan.GetInstance.DictFileMan[StorageType.LocalNetwork];
                result = fileManagement.CreateFileDownload(pathFileName);
            }
            return result;
        }

        public StorageReturnValue DownloadFile(List<string> pathFileNameList)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            IFileManagement fileManagement = FolderFileBantuan.GetInstance.DictFileMan[StorageType.LocalNetwork];
            List<FileStorageAttachment> listFileDownload = new List<FileStorageAttachment>();
            foreach (var item in pathFileNameList)
            {
                string pathFileName = item.Trim();
                string filename = Path.GetFileName(pathFileName);
                FileStorageAttachment downloaded =null;
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
    }
}
