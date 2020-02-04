using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileStorage.FolderFile;
using FileStorage.MiscClass;
using FileStorage.Validation;

namespace FileStorage.Upload
{
    public class UploadNetwork:IStorageUpload
    {
        StorageReturnValue result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
        private static UploadNetwork instance;
        public UploadNetwork()
        {
        }
        public static UploadNetwork GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new UploadNetwork();
                return instance;
            }
        }
        private string localNetwork = FileNetworkProperties.GetInstance.NetworkSharing;

        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();
                IFileManagement fileManagement = FolderFileBantuan.GetInstance.DictFileMan[StorageType.LocalNetwork];
                if (FileStorageProperties.GetInstance.FileStorageType == StorageType.LocalNetwork)
                {
                    result = FileValidation.GetInstance.CheckFolderStorageExistAndCreate(uploadToLocation);
                    if (!result.IsSuccess)
                        return result;
                    result = FileValidation.GetInstance.IsFileExtAllowed(uploadedFile);
                    if (!result.IsSuccess)
                        return result;

                    string folderUploadToLocation = Path.Combine(localNetwork, uploadToLocation);
                    List<FileStorageAttachment> uploadedFileSuccess = new List<FileStorageAttachment>();
                    foreach (FileStorageAttachment item in uploadedFile)
                    {
                        string fileName = !string.IsNullOrEmpty(item.FileNameWithExtRenamed) ? item.FileNameWithExtRenamed : item.FileNameWithExt;
                        string fileToUpload = Path.Combine(folderUploadToLocation, fileName);
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
                            string fileName = !string.IsNullOrEmpty(item.FileNameWithExtRenamed) ? item.FileNameWithExtRenamed : item.FileNameWithExt;
                            string fileToUpload = Path.Combine(folderUploadToLocation, fileName);
                            result = fileManagement.DeleteFile(fileToUpload);
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
                result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
                result = FileValidation.GetInstance.IsFileSizeLimitationOK(uploadedFile);
                if (result.IsSuccess)
                    result = this.UploadFileProcess(uploadToLocation, uploadedFile);
            }
            return result;

        }

        public StorageReturnValue UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(uploadToLocation) & uploadedFile != null)
            {
                uploadToLocation = uploadToLocation.Trim();
                result = FileValidation.GetInstance.IsFileSizeLimitationOK(uploadedFile, sizeLimit);
                if (result.IsSuccess)
                    result = this.UploadFileProcess(uploadToLocation, uploadedFile);
            }
            return result;
        }


    }
}
