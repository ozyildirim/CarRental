using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileSystems
{
    public class FileManagerOnDisk : IFileSystem
    {
        public string Add(IFormFile file, string path)
        {
            var sourcePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Move(sourcePath, path);
            return path;
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string Update(string pathToUpdate, IFormFile file, string path)
        {
            if (path.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(pathToUpdate);
            return path;
        }
    }
}
