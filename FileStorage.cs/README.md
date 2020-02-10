# FileStorageelper version 1.0.0

## Minimum Requirement For Installation  
   1.TargetFramework netcoreapp 2.1 </br>
   2.Microsoft.CodeAnalysis 3.4.0 </br>
   3.Microsoft.Exchange.WebServce 2.2.0 </br>

## How To Use
	1. Instance your desired UpdownWrapper ,ex: var UpdownWrapper = new UpdownWrapper(). </br>
	var hasil = UpdownWrapper.Upload('','',...)

## Return Value (StorageReturnValue)
	1.IsSuccessMail ,true if success
    2.ErrorMessage ,will empty if success and throw message when false

## Functions
	1. For upload,download and delete file
	2. Available for sharing network,ftp,and azure clouds 

## Available Functions 
	1.CheckFolderAndCreate(string pathFolderName)       
	2.CheckFolderExist(string pathFolderName)    
	3.CreateFolder(string pathFolderName) 
	4.DeleteFile(string pathFileNameWithExt)
	5.async Task<StorageReturnValue> DeleteFileAsync(string pathFileNameWithExt)
	6.DeleteFolder(string pathFolderName)
	7.DownloadFile(string downloadToLocation, string fileNameWithExt)
	8.DownloadFile(string downloadToLocation, List<string> fileNameWithExtList)
	9.async Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, string fileNameWithExt)
	10.async Task<StorageReturnValue> DownloadFileAsynch(string downloadToLocation, List<string> fileNameWithExtList)
	11.UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
	12.UploadFile(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)
	13.async Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile)
	12.async Task<StorageReturnValue> UploadFileAsync(string uploadToLocation, List<FileStorageAttachment> uploadedFile, int sizeLimit)


##
# HAPPYCoding
contact me at satriansyahw@gmail.com




	   
