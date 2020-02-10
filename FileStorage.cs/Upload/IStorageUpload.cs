using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.Upload
{
    public interface IStorageUpload
    {
        StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile);
        StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile,int sizeLimit);
    }
    public interface IStorageUploadAsync
    {
        Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile);
        Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit);
    }
}
