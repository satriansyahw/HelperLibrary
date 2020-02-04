using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Download
{
    public class DownloadBantuan
    {
        private static DownloadBantuan instance;
        public DownloadBantuan()
        {
            this.LoadInitial();
        }
        public static DownloadBantuan GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new DownloadBantuan();
                return instance;
            }
        }
        public Dictionary<StorageType, IStorageDownload> DictUploadMan = new Dictionary<StorageType, IStorageDownload>();
        private void LoadInitial()
        {
            DictUploadMan.Add(StorageType.LocalNetwork, DownloadNetwork.GetInstance);
            DictUploadMan.Add(StorageType.FTP, DownloadFTP.GetInstance);
            DictUploadMan.Add(StorageType.Azure, DownloadAzure.GetInstance);
          
        }
    }
}
