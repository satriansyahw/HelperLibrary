using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Upload
{
    public interface IStorageUpload
    {
        StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile);
        StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile,int sizeLimit);
    }
}
