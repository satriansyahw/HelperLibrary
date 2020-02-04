using System;
using System.Collections.Generic;
using System.Text;
using FileStorage.MiscClass;
using System.Linq;
using System.IO;
using FileStorage.FolderFile;

namespace FileStorage.Validation
{
    public class FileValidation:IFileValidation
    {
        StorageReturnValue result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
        private static FileValidation instance;
        public static FileValidation GetInstance
        {
            get
            {
                if (instance == null) instance = new FileValidation();
                return instance;
            }
        }

        public StorageReturnValue IsFileExtAllowed(List<FileStorageAttachment> fileAttachments)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (fileAttachments != null)
            {
                string[] fileExtAllowed = FileStorageProperties.GetInstance.FileExtAllowed;
                if (fileExtAllowed.Contains("*")) // if found * , all files ok
                    result.SetStorageReturnValue(true, string.Empty, null);
                else
                {
                    if (fileAttachments.Where(a => a.FileNameWithExt.Contains(".") == false).Count() > 0) // filename must have dot (.)
                        result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongFileExt, null);
                    else
                    {
                        foreach (var item in fileAttachments)
                        {
                            string[] fileNameArray = item.FileNameWithExt.Split(".");
                            if (fileNameArray.Length > 0)
                            {
                                string fileExt = fileNameArray[(fileNameArray.Length) - 1].Trim().Replace(".", "");
                                if (fileExtAllowed.Contains(fileExt))
                                    result.SetStorageReturnValue(true, string.Empty, null);
                                else
                                    result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongFileExt, null);
                            }
                        }

                    }

                }

            }          
            return result;
        }

        public StorageReturnValue IsFileSizeLimitationOK(List<FileStorageAttachment> fileAttachments)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (fileAttachments != null)
            {
                int fileLimit = FileStorageProperties.GetInstance.FileUploadMaxSize;
                int totLimit = 0;
                foreach (var item in fileAttachments)
                {
                    totLimit += item.FileAttachment.Length;
                }
                if (totLimit < fileLimit)
                {
                    result = result.SetStorageReturnValue(true, string.Empty, null);
                }
                else
                {
                    result = result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongAttachment + " Max Size : "
                        + FileStorageProperties.GetInstance.FileUploadMaxSize.ToString(), null);
                }
            }
            return result;
        }

        public StorageReturnValue IsFileSizeLimitationOK(List<FileStorageAttachment> fileAttachments, int sizeLimit)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (fileAttachments != null)
            {
                int fileLimit = sizeLimit;
                int totLimit = 0;
                foreach (var item in fileAttachments)
                {
                    totLimit += item.FileAttachment.Length;
                }
                if (totLimit < fileLimit)
                {
                    result = result.SetStorageReturnValue(true, string.Empty, null);
                }
                else
                {
                    result = result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongAttachment + " Max Size : "
                        + FileStorageProperties.GetInstance.FileUploadMaxSize.ToString(), null);
                }
            }
            return result;
        }    

        public StorageReturnValue CheckFolderStorageExistAndCreate(string folderName)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(folderName))
            {
                IFolderManagement folderManagement = FolderFileBantuan.GetInstance.DictFolderMan[FileStorageProperties.GetInstance.FileStorageType];
                result = folderManagement.CheckFolderAndCreate(folderName);
            }
            return result;
        }

       }
}
