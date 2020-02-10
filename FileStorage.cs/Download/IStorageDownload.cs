using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileStorage.Download
{
    public interface IStorageDownload
    {
       StorageReturnValue  DownloadFile(string downloadToLocation,string fileNameWithExt);
       StorageReturnValue  DownloadFile(string downloadToLocation, List<string> fileNameWithExtList);
    }
    public interface IStorageDownloadAsync
    {
        Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, string fileNameWithExt);
        Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, List<string> fileNameWithExtList);
    }
}
