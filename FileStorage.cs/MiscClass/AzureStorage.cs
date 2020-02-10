using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileStorage.MiscClass
{
    public class AzureStorage
    {
        public string StorageAccountName = @"dsdigsudang";
        public string StorageAccountKey = @"+sXdBMuZS3hhWGezMNzmsjq+48z5R4tIt73nquF0/QSegcPWYjHu5jqgjBnq2NkGUVw0vv/XP353lxdvhnG1oHQ==";
        public string StorageContainerName = @"stasrter";
        public bool IsHttps = true;
        public CloudStorageAccount accountInstance;
        public StorageCredentials credentialInstance;
        public CloudBlobClient blobClientInstance;
        public CloudBlobContainer blobContainerInstance { get; set; }
        public CloudBlobDirectory blobDirectoryInstance { get; set; }

        public CloudStorageAccount AzureStorageAccount
        {
            get
            {
                if (accountInstance == null)
                {
                    accountInstance = new CloudStorageAccount(this.AzureStorageCredentials, this.IsHttps);
                }
                return accountInstance;
            }
        }
        public StorageCredentials AzureStorageCredentials
        {
            get
            {
                if (credentialInstance == null)
                {
                    credentialInstance = new StorageCredentials(this.StorageAccountName, this.StorageAccountKey);
                }
                return credentialInstance;
            }
        }
        public CloudBlobClient AzureBlobClient
        {
            get
            {
                if (blobClientInstance == null)
                {
                    blobClientInstance = this.AzureStorageAccount.CreateCloudBlobClient();
                }
                return blobClientInstance;
            }
        }
        public CloudBlobContainer AzureBlobContainer
        {
            get
            {
                if (blobContainerInstance == null)
                {
                    blobContainerInstance = this.AzureBlobClient.GetContainerReference(this.StorageAccountName);
                }
                return blobContainerInstance;
            }
        }
        public CloudBlobDirectory AzureBlobDirectory(string directoryName)
        {

            if (blobDirectoryInstance == null)
            {
                blobDirectoryInstance = this.AzureBlobContainer.GetDirectoryReference(directoryName);
            }
            return blobDirectoryInstance;

        }
        public AzureStorage()
        {

        }
        public AzureStorage(string storageAccountName, string storageAccountKey, string storageContainerName, bool isHttps)
        {
            this.StorageAccountName = storageAccountName;
            this.StorageAccountKey = storageAccountKey;
            this.StorageContainerName = storageContainerName;
            this.IsHttps = isHttps;

        }
        public void SetFileAzureProperties(string storageAccountName, string storageAccountKey, string storageContainerName, bool isHttps)
        {
            this.StorageAccountName = storageAccountName;
            this.StorageAccountKey = storageAccountKey;
            this.StorageContainerName = storageContainerName;
            this.IsHttps = isHttps;
        }
    }
}
