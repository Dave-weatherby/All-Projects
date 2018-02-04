using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace uploadApp.Models {

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
        private string result;

        public ImageUploader() {
        }

        // --------------------------------------------------- public methods
        public void setupMe(IHostingEnvironment env, string myTargetFolder) {
            // initialization
            targetFolder = myTargetFolder;         

            // check to see if web app's root folder has an "uploads" folder - if not create it
            fullPath = env.WebRootPath + "/" + targetFolder + "/";
            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }
        }

        public string errorMessage() {
            return result;
        }

        public int uploadImage(IFormFile file) {
            // error checks
            if(file != null) {
                string contentType = file.ContentType;
                if((contentType == "image/png") || (contentType == "image/jpeg")|| (contentType == "image/gif")) {
                    long size = file.Length;
                    if((size > 0) && (size < UPLOADLIMIT)) {
                        string filename = Path.GetFileName(file.FileName);
                        if(filename.Length <= 100) {
                            using(FileStream stream = new FileStream(fullPath + filename, FileMode.Create)) {
                                try {
                                    file.CopyTo(stream);
                                } catch {
                                    result = "ERROR File fail to save";
                                    return ImageUploader.ERROR_SAVE;
                                }
                                result = "File Saved successfully";
                                return ImageUploader.SUCCESS;
                            }
                        } else {
                            result = "ERROR File name is to long";
                            return ImageUploader.ERROR_NAME_LENGTH;
                        }
                    } else {
                        result = "ERROR File is to large";
                        return ImageUploader.ERROR_SIZE;
                    }
                } else {
                    result = "ERROR File is not a png, jpeg, and gif";
                    return ImageUploader.ERROR_TYPE;
                }
            } else {
                result = "ERROR No file selected";
                return ImageUploader.ERROR_NO_FILE;
            }
        }

    }

}