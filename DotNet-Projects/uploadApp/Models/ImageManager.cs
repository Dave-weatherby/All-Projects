using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace uploadApp.Models {

    public class ImageManager {

        // variables
        private List<String> _imageSources;
        private string fullPath;
        private string targetFolder;
        private string display_error;

        public ImageManager() {

            _imageSources = new List<string>();

        }

        // get/sets
        public List<string> imageSources {
            get {
                return _imageSources;
            }
        }

        public string displayError {
            get {
                return display_error;
            }
        }
        


        public void setupMe(IHostingEnvironment env, string myTargetFolder, string errorMessage) {
            targetFolder = myTargetFolder;

            display_error = errorMessage;
            // determine full path
            fullPath = env.WebRootPath + "/" + targetFolder + "/";
            // test if folder exist
            if (!Directory.Exists(fullPath)) {
                Directory.CreateDirectory(fullPath);
            }

            string[] imageArray;
            imageArray = Directory.GetFiles(fullPath,"*.*");

            for (int i=0; i<imageArray.Length; i++) {
                _imageSources.Add("/" + targetFolder + "/" + Path.GetFileName(imageArray[i]));
            }
        }
        
    }
}