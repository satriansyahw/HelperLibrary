using FileStorage.MiscClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.Download
{
    public interface IStorageDownload
    {
        StorageReturnValue DownloadFile(string pathFileName);
        StorageReturnValue DownloadFile(List<string> pathFileNameList);
    }
}
