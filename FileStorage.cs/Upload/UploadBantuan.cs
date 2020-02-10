using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Upload
{
    public class UploadBantuan
    {
        private static UploadBantuan instance;
        public UploadBantuan()
        {
            this.LoadInitial();
        }
        public static UploadBantuan GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new UploadBantuan();
                return instance;
            }
        }
        public Dictionary<StorageType, IStorageUpload> DictUpload = new Dictionary<StorageType, IStorageUpload>();
        private void LoadInitial()
        {
            DictUpload.Add(StorageType.LocalNetwork, UploadNetwork.GetInstance);
            DictUpload.Add(StorageType.FTP, UploadFTP.GetInstance);
            DictUpload.Add(StorageType.Azure, UploadAzure.GetInstance);
          
        }
        public Dictionary<StorageType, IStorageUploadAsync> DictUploadAsync= new Dictionary<StorageType, IStorageUploadAsync>();
        private void LoadInitialAsync()
        {
            DictUploadAsync.Add(StorageType.LocalNetwork, UploadNetwork.GetInstance);
            DictUploadAsync.Add(StorageType.FTP, UploadFTP.GetInstance);
            DictUploadAsync.Add(StorageType.Azure, UploadAzure.GetInstance);

        }

    }
}
