using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.Download
{
    public class DownloadFTP : IStorageDownload
    {
        public DownloadFTP()
        {

        }
        private static DownloadFTP instance;
        public static DownloadFTP GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new DownloadFTP();
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
