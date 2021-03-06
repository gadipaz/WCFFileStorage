﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFFileStorage
{
    public class FileService : IFileService
    {
        /// <summary>
        /// Push File to the client
        /// </summary>
        /// <param name="fileToPush">file you want to Push</param>
        /// <returns>a file transfer Response</returns>
        public FileTransferResponse Put(FileTransferRequest fileToPush)
        {
            FileTransferResponse fileTransferResponse = CheckFileTransferRequest(fileToPush);
            if (fileTransferResponse.ResponseStatus == "FileIsValed")
            {
                try
                {
                    SaveFileStream(System.Configuration.ConfigurationManager.AppSettings["SavedLocation"] + "\\" + fileToPush.FileName, new MemoryStream(fileToPush.Content));
                    return new FileTransferResponse
                    {
                        CreateAt = DateTime.Now,
                        FileName = fileToPush.FileName,
                        Message = "File was transfered",
                        ResponseStatus = "Successful"
                    };
                }
                catch (Exception ex)
                {
                    return new FileTransferResponse
                    {
                        CreateAt = DateTime.Now,
                        FileName = fileToPush.FileName,
                        Message = ex.Message,
                        ResponseStatus = "Error"
                    };
                }
            }

            return fileTransferResponse;
        }

        /// <summary>
        /// Check From file Transfer Object is not null 
        /// and all properties is set
        /// </summary>
        /// <param name="fileToPush">file to check</param>
        /// <returns>File Transfer Response</returns>
        private FileTransferResponse CheckFileTransferRequest(FileTransferRequest fileToPush)
        {
            if (fileToPush != null)
            {
                if (!string.IsNullOrEmpty(fileToPush.FileName))
                {
                    if (fileToPush.Content != null)
                    {
                        return new FileTransferResponse
                        {
                            CreateAt = DateTime.Now,
                            FileName = fileToPush.FileName,
                            Message = string.Empty,
                            ResponseStatus = "FileIsValed"
                        };
                    }

                    return new FileTransferResponse
                    {
                        CreateAt = DateTime.Now,
                        FileName = "No Name",
                        Message = " File Content is null",
                        ResponseStatus = "Error"
                    };
                }

                return new FileTransferResponse
                {
                    CreateAt = DateTime.Now,
                    FileName = "No Name",
                    Message = " File Name Can't be Null",
                    ResponseStatus = "Error"
                };
            }

            return new FileTransferResponse
            {
                CreateAt = DateTime.Now,
                FileName = "No Name",
                Message = " File Can't be Null",
                ResponseStatus = "Error"
            };
        }

        /// <summary>
        /// Write the Stream in the hard drive
        /// </summary>
        /// <param name="filePath">path to write the file in</param>
        /// <param name="stream">stream to write</param>
        private void SaveFileStream(string filePath, Stream stream)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                stream.CopyTo(fileStream);
                fileStream.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
