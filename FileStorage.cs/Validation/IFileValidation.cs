using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Validation
{
    public interface IFileValidation
    {
        StorageReturnValue CheckFolderStorageExistAndCreate(string folderName);
        StorageReturnValue IsFileSizeLimitationOK(List<FileStorageAttachment> fileAttachments);
        StorageReturnValue IsFileSizeLimitationOK(List<FileStorageAttachment> fileAttachments,int sizeLimit);
        StorageReturnValue IsFileExtAllowed(List<FileStorageAttachment> fileAttachments);// tambhakan yang lain ya
    }
}
