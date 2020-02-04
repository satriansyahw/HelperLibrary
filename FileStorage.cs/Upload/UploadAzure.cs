using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.Upload
{
    public class UploadAzure:IStorageUpload
    {
        private static UploadAzure instance;
        public static UploadAzure GetInstance
        {
            get
            {
                if (instance == null) instance = new UploadAzure();
                return instance;
            }
        }

        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            throw new NotImplementedException();
        }

        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)
        {
            throw new NotImplementedException();
        }
    }
}
