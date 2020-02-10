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
            this.LoadInitialAsync();
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
        public Dictionary<StorageType, IStorageDownload> DictDownload = new Dictionary<StorageType, IStorageDownload>();
        private void LoadInitial()
        {
            DictDownload.Add(StorageType.LocalNetwork, DownloadNetwork.GetInstance);
            DictDownload.Add(StorageType.FTP, DownloadFTP.GetInstance);
            DictDownload.Add(StorageType.Azure, DownloadAzure.GetInstance);
          
        }
        public Dictionary<StorageType, IStorageDownloadAsync> DictDownloadAsync = new Dictionary<StorageType, IStorageDownloadAsync>();
        private void LoadInitialAsync()
        {
            DictDownloadAsync.Add(StorageType.LocalNetwork, DownloadNetwork.GetInstance);
            DictDownloadAsync.Add(StorageType.FTP, DownloadFTP.GetInstance);
            DictDownloadAsync.Add(StorageType.Azure, DownloadAzure.GetInstance);

        }
    }
}
