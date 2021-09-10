using System;
using System.Collections.Generic;
using Custom.AspNet.Filesystem.Files;
using Microsoft.AspNetCore.Http;

namespace Custom.AspNet.Filesystem.FileCollections
{
    public class PublicFiles : IAspFiles
    {
        private readonly IEnumerable<IFormFile> _files;
        
        private readonly Func<IFormFile, string> _fileCreation;

        public PublicFiles(IEnumerable<IFormFile> files)
            : this(files, file => new PublicFile(file).Save())
        {

        }

        public PublicFiles(IEnumerable<IFormFile> files, string folder)
            : this(files, file => new PublicFile(file, folder).Save())
        {

        }

        public PublicFiles(IEnumerable<IFormFile> files, Func<IFormFile, string> fileCreation)
        {
            _files = files;
            _fileCreation = fileCreation;
        }
        
        public IEnumerable<string> Save()
        {
            var paths = new List<string>();
            foreach (var file in _files)
            {
                paths.Add(_fileCreation.Invoke(file));
            }

            return paths;
        }
    }
}