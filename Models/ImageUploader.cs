using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace QuoteGeneratorAPI.Models {

    public class ImageUploader {

        // class constants for different errors while uploading
        public const int ERROR_NO_FILE = 0;
        public const int ERROR_TYPE = 1;
        public const int ERROR_SIZE = 2;
        public const int ERROR_NAME_LENGTH = 3;
        public const int ERROR_SAVE = 4;
        public const int SUCCESS = 5;

        // this is the file size limit in bytes that IFormFile approach can handle
        // do have the option to stream larger files - but is more complicated
        private const int UPLOADLIMIT = 4194304;

        // needed for getting path to web app's location
        private string targetFolder;
        // path to the upload folder
        private string fullPath;

        public ImageUploader(IWebHostEnvironment env, string myTargetFolder) {
            // initialization
            targetFolder = myTargetFolder;         

            // check to see if web app's root folder has an "uploads" folder - if not create it
            fullPath = env.WebRootPath + "/" + targetFolder + "/";
            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }
        }

        // --------------------------------------------------- public methods

        public int uploadImage(IFormFile file, string date) {
            // error check 1 : no file is found
            if (file != null) {
                // error check 2 : check file type
                string contentType = file.ContentType;
                if ((contentType == "image/png") || (contentType == "image/jpeg") || (contentType == "image/gif")) {
                    // error check 3 : check file size is below limit
                    long size = file.Length;
                    if ((size > 0) && (size < UPLOADLIMIT)) {
                        // error check 4 : check to make sure the filename is under 100 characters
                        string filename = Path.GetFileName(file.FileName);
                        // filename = filename.Split('.')[0]+ DateTime.Now.ToString("yyyyMMddHHmmss")+"."+filename.Split('.')[1];
                        filename = "img_" + date + "." + filename.Split('.')[1];
                        Console.WriteLine("filename: " + filename);
                        // Console.WriteLine("New Filename: " + filename.Split('.')[0]+ DateTime.Now.ToString("yyyyMMddHHmm")+"."+filename.Split('.')[1]);
                        // filename = filename +selectedFile.FileName.Split('.')[0]+ DateTime.Now.ToString("yyyyMMddHHmmss")+"."+selectedFile.FileName.Split('.')[1];
                        if (filename.Length <= 100) {
                            // safe to save the file to the server!
                            FileStream stream = new FileStream((fullPath + filename), FileMode.Create);
                            try {
                                // copy the IFormFile object to the stream which writes it to the File System
                                file.CopyTo(stream);
                                stream.Close();
                                return ImageUploader.SUCCESS;
                            } catch {
                                stream.Close();
                                return ImageUploader.ERROR_SAVE;
                            }
                        } else {
                            return ImageUploader.ERROR_NAME_LENGTH;
                        }
                    } else {
                        return ImageUploader.ERROR_SIZE;
                    }
                } else {
                    return ImageUploader.ERROR_TYPE;
                }
            } else {
                return ImageUploader.ERROR_NO_FILE;
            }
        }


    }

}