using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FileFTP : IFileManagement
    {
        private static FileFTP instance;
        public FileFTP()
        {
        }
        public static FileFTP GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FileFTP();
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
