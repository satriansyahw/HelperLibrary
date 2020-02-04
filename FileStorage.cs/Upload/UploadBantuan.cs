﻿using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Upload
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
        public Dictionary<StorageType, IStorageUpload> DictUploadMan = new Dictionary<StorageType, IStorageUpload>();
        private void LoadInitial()
        {
            DictUploadMan.Add(StorageType.LocalNetwork, UploadNetwork.GetInstance);
            DictUploadMan.Add(StorageType.FTP, UploadFTP.GetInstance);
            DictUploadMan.Add(StorageType.Azure, UploadAzure.GetInstance);
          
        }
    }
}
