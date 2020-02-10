using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FileNetwork : IFileManagement, IFileManagementAsync
    {
        StorageReturnValue result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
        private static FileNetwork instance;
        public FileNetwork()
        {
        }
        public static FileNetwork GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new FileNetwork();
                return instance;
            }
        }
        public virtual StorageReturnValue CreateFileUpload(byte[] uploadedFile, string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFileNameWithExt) & uploadedFile != null)
            {
                pathFileNameWithExt = pathFileNameWithExt.Trim();
                if (File.Exists(pathFileNameWithExt))
                    result = this.DeleteFile(pathFileNameWithExt);
                try
                {
                    File.WriteAllBytes(pathFileNameWithExt, uploadedFile);
                    result = result.SetStorageReturnValue(true, string.Empty, null);
                }
                catch (ArgumentNullException ex) { result = result.SetStorageReturnValue(false, "ArgumentNullException :" + ex.Message, null); }
                catch (ArgumentException ex) { result = result.SetStorageReturnValue(false, "ArgumentException :" + ex.Message, null); }
                catch (DirectoryNotFoundException ex) { result = result.SetStorageReturnValue(false, "DirectoryNotFoundException :" + ex.Message, null); }
                catch (NotSupportedException ex) { result = result.SetStorageReturnValue(false, "NotSupportedException :" + ex.Message, null); }
                catch (PathTooLongException ex) { result = result.SetStorageReturnValue(false, "PathTooLongException :" + ex.Message, null); }
                catch (IOException ex) { result = result.SetStorageReturnValue(false, "IOException :" + ex.Message, null); }
                catch (UnauthorizedAccessException ex) { result = result.SetStorageReturnValue(false, "UnauthorizedAccessException :" + ex.Message, null); }
                catch (SecurityException ex) { result = result.SetStorageReturnValue(false, "SecurityException :" + ex.Message, null); }
                catch (Exception ex) { result = result.SetStorageReturnValue(false, "Exception :" + ex.Message, null); }
            }
            return result;
        }

        public virtual StorageReturnValue DeleteFile(string pathFilename)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFilename))
            {
                pathFilename = pathFilename.Trim();
                try
                {
                    result = result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongFileManagement, null);
                    if (File.Exists(pathFilename))
                    {
                        File.Delete(pathFilename);
                        result = result.SetStorageReturnValue(true, string.Empty, null);
                    }
                }
                catch (ArgumentNullException ex) { result = result.SetStorageReturnValue(false, "ArgumentNullException :" + ex.Message, null); }
                catch (ArgumentException ex) { result = result.SetStorageReturnValue(false, "ArgumentException :" + ex.Message, null); }
                catch (DirectoryNotFoundException ex) { result = result.SetStorageReturnValue(false, "DirectoryNotFoundException :" + ex.Message, null); }
                catch (NotSupportedException ex) { result = result.SetStorageReturnValue(false, "NotSupportedException :" + ex.Message, null); }
                catch (PathTooLongException ex) { result = result.SetStorageReturnValue(false, "PathTooLongException :" + ex.Message, null); }
                catch (IOException ex) { result = result.SetStorageReturnValue(false, "IOException :" + ex.Message, null); }
                catch (UnauthorizedAccessException ex) { result = result.SetStorageReturnValue(false, "UnauthorizedAccessException :" + ex.Message, null); }
                catch (Exception ex) { result = result.SetStorageReturnValue(false, "Exception :" + ex.Message, null); }
            }
            return result;

        }
        public virtual StorageReturnValue CreateFileDownload(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFileNameWithExt))
            {
                pathFileNameWithExt = pathFileNameWithExt.Trim();
                try
                {
                    result = result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongFileManagement, null);
                    if (File.Exists(pathFileNameWithExt))
                    {
                        byte[] myfile = System.IO.File.ReadAllBytes(pathFileNameWithExt);
                        string filename = Path.GetFileName(pathFileNameWithExt);
                        result = result.SetStorageReturnValue(true, string.Empty, new List<FileStorageAttachment>() { new FileStorageAttachment(filename, filename, myfile) });
                    }
                }
                catch (ArgumentNullException ex) { result = result.SetStorageReturnValue(false, "ArgumentNullException :" + ex.Message, null); }
                catch (ArgumentException ex) { result = result.SetStorageReturnValue(false, "ArgumentException :" + ex.Message, null); }
                catch (DirectoryNotFoundException ex) { result = result.SetStorageReturnValue(false, "DirectoryNotFoundException :" + ex.Message, null); }
                catch (NotSupportedException ex) { result = result.SetStorageReturnValue(false, "NotSupportedException :" + ex.Message, null); }
                catch (PathTooLongException ex) { result = result.SetStorageReturnValue(false, "PathTooLongException :" + ex.Message, null); }
                catch (IOException ex) { result = result.SetStorageReturnValue(false, "IOException :" + ex.Message, null); }
                catch (UnauthorizedAccessException ex) { result = result.SetStorageReturnValue(false, "UnauthorizedAccessException :" + ex.Message, null); }
                catch (Exception ex) { result = result.SetStorageReturnValue(false, "Exception :" + ex.Message, null); }
            }
            return result;
        }

        public virtual async Task<StorageReturnValue> DeleteFileAsync(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            await Task.Run(() => {
                result = this.CreateFileDownload(pathFileNameWithExt);
            });
            return result;
        }

        public virtual async Task<StorageReturnValue> CreateFileUploadAsync(byte[] uploadedFile, string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            await Task.Run(() => {
                result = this.CreateFileDownload(pathFileNameWithExt);
            });
            return result;
        }

        public virtual async Task<StorageReturnValue> CreateFileDownloadAsync(string pathFileNameWithExt)
        {
            result = new StorageReturnValue(false, FileStorageProperties.GetInstance.WrongInitialManagement, null);
            await Task.Run(() => {
                result = this.CreateFileDownload(pathFileNameWithExt);
            });
            return result;
        }
    }
}
