using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FileStorage.FolderFile;
using FileStorage.MiscClass;
using FileStorage.Validation;

namespace FileStorage.Upload
{
    public class UploadAzure:IStorageUpload,IStorageUploadAsync
    {
        private static UploadAzure instance;
        StorageReturnValue result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
        IFileManagement fileManagement = FolderFileBantuan.GetInstance.DictFile[StorageType.Azure];
        IFileManagementAsync fileManagementAsync = FolderFileBantuan.GetInstance.DictFileAsync[StorageType.Azure];

        public static UploadAzure GetInstance
        {
            get
            {
                if (instance == null) instance = new UploadAzure();
                return instance;
            }
        }

        private async Task<StorageReturnValue> UploadFileProcessAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();

                if (FileStorageProperties.GetInstance.FileStorageType == StorageType.Azure)
                {
                    result = FileValidation.GetInstance.CheckFolderStorageExistAndCreate(uploadToLocation);
                    if (!result.IsSuccess)
                        return result;
                    result = FileValidation.GetInstance.IsFileExtAllowed(uploadedFile);
                    if (!result.IsSuccess)
                        return result;

                    List<FileStorageAttachment> uploadedFileSuccess = new List<FileStorageAttachment>();
                    foreach (FileStorageAttachment item in uploadedFile)
                    {
                        string fileName = item.GetFileName;
                        string fileToUpload = Path.Combine(uploadToLocation, fileName);
                        result = await fileManagementAsync.CreateFileUploadAsync(item.FileAttachment, fileToUpload);
                        if (result.IsSuccess)
                            uploadedFileSuccess.Add(item);
                        else
                            break;
                    }
                    if (!result.IsSuccess)
                    {
                        /*if any error when uploaded,all data will be deleted also*/
                        foreach (FileStorageAttachment item in uploadedFile)
                        {

                            string fileName = item.GetFileName;
                            string fileToUpload = Path.Combine(uploadToLocation, fileName);
                            result = await fileManagementAsync.DeleteFileAsync(fileToUpload);
                        }
                    }
                }
            }
            return result;
        }
        private StorageReturnValue UploadFileProcess(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();
               
                if (FileStorageProperties.GetInstance.FileStorageType == StorageType.Azure)
                {
                    result = FileValidation.GetInstance.CheckFolderStorageExistAndCreate(uploadToLocation);
                    if (!result.IsSuccess)
                        return result;
                    result = FileValidation.GetInstance.IsFileExtAllowed(uploadedFile);
                    if (!result.IsSuccess)
                        return result;

                    List<FileStorageAttachment> uploadedFileSuccess = new List<FileStorageAttachment>();
                    foreach (FileStorageAttachment item in uploadedFile)
                    {
                        string fileName = item.GetFileName;
                        string fileToUpload = Path.Combine(uploadToLocation, fileName);
                        result = fileManagement.CreateFileUpload(item.FileAttachment, fileToUpload);
                        if (result.IsSuccess)
                            uploadedFileSuccess.Add(item);
                        else
                            break;
                    }
                    if (!result.IsSuccess)
                    {
                        /*if any error when uploaded,all data will be deleted also*/
                        foreach (FileStorageAttachment item in uploadedFile)
                        {

                            string fileName = item.GetFileName;
                            string fileToUpload = Path.Combine(uploadToLocation, fileName);
                            result = fileManagement.DeleteFile(fileToUpload);
                        }
                    }
                }
            }
            return result;
        }
        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();
                result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
                result = FileValidation.GetInstance.IsFileSizeLimitationOK(uploadedFile);
                if (result.IsSuccess)
                    result = this.UploadFileProcess(uploadToLocation, uploadedFile);
            }
            return result;
        }

        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();
                result = FileValidation.GetInstance.IsFileSizeLimitationOK(uploadedFile, sizeLimit);
                if (result.IsSuccess)
                    result = this.UploadFileProcess(uploadToLocation, uploadedFile);
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();
                result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
                result = FileValidation.GetInstance.IsFileSizeLimitationOK(uploadedFile);
                if (result.IsSuccess)
                    result = await this.UploadFileProcessAsync(uploadToLocation, uploadedFile);
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();
                result = FileValidation.GetInstance.IsFileSizeLimitationOK(uploadedFile, sizeLimit);
                if (result.IsSuccess)
                    result = await this.UploadFileProcessAsync(uploadToLocation, uploadedFile);
            }
            return result;
        }
    }
}
