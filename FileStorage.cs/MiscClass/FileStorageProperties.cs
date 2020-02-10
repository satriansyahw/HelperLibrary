using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.MiscClass
{
    public class FileStorageProperties
    {
        private static FileStorageProperties instance;
        public static FileStorageProperties GetInstance
        {
            get
            {
                if (instance == null) instance = new FileStorageProperties();
                return instance;
            }
        }
        public string[] FileExtAllowed = new string[] { "*" };
        public int FileUploadMaxSize = 10 * 1024 * 1000;//in MB 
        public string WrongAttachment = "Wrong mail attachment, please check attachment file and it's size ";//
        public string WrongFileExt = "Wrong Ext file attachment, please check attachment file ext , and it's must exist ";//
        public string WrongFolderManagement = "Wrong folder management,please check related folder's structure ";//
        public string WrongFileManagement = "Wrong file management,please check the file, maybe not exists  ";//
        public string WrongFileUpload = "Wrong file upload,please check the file failed uploaded  ";//
        public string WrongFileDelete = "Wrong file delete,please check the file failed deleted  ";//
        public string WrongFileDownload = "Wrong file download,file(s) error  ";//
        public string WrongInitialManagement = "Wrong initial executions  ";//
        public string AzureGeneratedFile = "This is generated file by system";
        public StorageType FileStorageType = StorageType.LocalNetwork;
    }
}
