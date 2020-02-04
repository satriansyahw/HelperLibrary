using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.Upload
{
    public class UploadFTP:IStorageUpload
    {
        private static UploadFTP instance;
        public static UploadFTP GetInstance
        {
            get
            {
                if (instance == null) instance = new UploadFTP();
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
