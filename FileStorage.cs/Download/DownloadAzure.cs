using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.Download
{
    public class DownloadAzure : IStorageDownload
    {
        public DownloadAzure()
        {

        }
        private static DownloadAzure instance;
        public static DownloadAzure GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new DownloadAzure();
                return instance;
            }
        }

        public StorageReturnValue DownloadFile(string pathFileName)
        {
            throw new NotImplementedException();
        }

        public StorageReturnValue DownloadFile(List<string> pathFileNameList)
        {
            throw new NotImplementedException();
        }
    }
}
