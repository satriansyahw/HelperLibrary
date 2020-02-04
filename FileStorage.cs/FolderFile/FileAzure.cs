using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FileAzure : IFileManagement
    {
        private static FileAzure instance;
        public FileAzure()
        {
        }
        public static FileAzure GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FileAzure();
                return instance;
            }
        }

        public StorageReturnValue CreateFileDownload(string filename)
        {
            throw new NotImplementedException();
        }

        public StorageReturnValue CreateFileUpload(byte[] fileByte, string filename)
        {
            throw new NotImplementedException();
        }

        public StorageReturnValue DeleteFile(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
