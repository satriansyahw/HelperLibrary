using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using FileStorage.MiscClass;

namespace FileStorage.FolderFile
{
    public class FileNetwork : IFileManagement
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
        public StorageReturnValue CreateFileUpload(byte[] fileByte,string pathFilename)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFilename) & fileByte != null)
            {
                pathFilename = pathFilename.Trim();
                if (File.Exists(pathFilename))
                    result = this.DeleteFile(pathFilename);
                try
                {
                    File.WriteAllBytes(pathFilename, fileByte);
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

        public StorageReturnValue DeleteFile(string pathFilename)
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
        public StorageReturnValue CreateFileDownload(string pathFileName)
        {
            result = new StorageReturnValue(false,FileStorageProperties.GetInstance.WrongInitialManagement,null);
            if (!string.IsNullOrEmpty(pathFileName))
            {
                pathFileName = pathFileName.Trim();
                try
                {
                    result = result.SetStorageReturnValue(false, FileStorageProperties.GetInstance.WrongFileManagement, null);
                    if (File.Exists(pathFileName))
                    {
                        byte[] myfile = System.IO.File.ReadAllBytes(pathFileName);
                        string filename = Path.GetFileName(pathFileName);
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
    }
}
