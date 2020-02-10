using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.MiscClass
{    
    public enum StorageType
    {
        LocalNetwork=0,
        FTP=1,
        Azure=2
    }
    public class FileNetworkProperties
    {
        public FileNetworkProperties()
        {

        }
        public FileNetworkProperties(string networkSharing)
        {
            this.NetworkSharing = networkSharing;
        }
        private static FileNetworkProperties instance;
        public static FileNetworkProperties GetInstance
        {
            get
            {
                if (instance == null) instance = new FileNetworkProperties();
                return instance;
            }
        }
        public string NetworkSharing = @"\\PEB-PC09RRX7\TestaSharing";
    }
    public class FileFTPProperties
    {
        public string FTPUserName = "zcxcaas";
        public string FTPPassword = "sdfsfdsf";
        public string FTPAddress = "ftp://172.16.134.3/";
        private static FileFTPProperties instance;
        public static FileFTPProperties GetInstance
        {
            get
            {
                if (instance == null) instance = new FileFTPProperties();
                return instance;
            }
        }
        public FileFTPProperties()
        {

        }
        public FileFTPProperties(string ftpusername, string ftppassword, string ftpaddress)
        {
            this.FTPUserName = ftpusername;
            this.FTPPassword = ftppassword;
            this.FTPAddress = ftpaddress;
        }

        public void SetFileLocalProperties(string ftpusername,string ftppassword,string ftpaddress)
        {
            this.FTPUserName = ftpusername;
            this.FTPPassword = ftppassword;
            this.FTPAddress = ftpaddress;


        }
    }
   
   
   

    public class FileStorageAttachment
    {
        public string FileNameWithExtRenamed { get; set; }
        public string FileNameWithExt { get; set; }
        public byte[] FileAttachment { get; set; }

        public FileStorageAttachment()
        {
                
        }
        public FileStorageAttachment(string fileNameWithExtRenamed, string fileNameWithExt, byte[] fileAttachment)
        {
            this.FileNameWithExtRenamed = fileNameWithExtRenamed;
            this.FileNameWithExt = fileNameWithExtRenamed;
            this.FileAttachment = fileAttachment;
        }
        public void SetFileStorageAttachment(string fileNameWithExtRenamed,string fileNameWithExt,byte[] fileAttachment)
        {
            this.FileNameWithExtRenamed = fileNameWithExtRenamed;
            this.FileNameWithExt = fileNameWithExtRenamed;
            this.FileAttachment = fileAttachment;
       }
        public string GetFileName
        {
            get
            {
                string fileName = !string.IsNullOrEmpty(this.FileNameWithExtRenamed) ? this.FileNameWithExtRenamed : this.FileNameWithExt;
                return fileName;
            }
        }
        
    }
    public class StorageReturnValue {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public List<FileStorageAttachment> ListFile { get; set; }
        public StorageReturnValue()
        {

        }
        public StorageReturnValue(bool isSuccess,string errorMessage, List<FileStorageAttachment> listFiles)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage;
            this.ListFile = listFiles;
        }
        public StorageReturnValue SetStorageReturnValue(bool isSuccess, string errorMessage, List<FileStorageAttachment> listFiles)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage;
            this.ListFile = listFiles;
            return this;
        }
    }
}
