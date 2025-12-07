using DemoSession3.BuisnessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession3.BuisnessLogic.Services.Classes
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = new List<string>() { ".png", ".Jpg", ".Jpeg" };
        const int maxSize = 2 * 1024 * 1024;
        public string? Upload(IFormFile file, string folderName)
        {
            //1.Check Extensions
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension))
            {
                return null;
            }
            //2. Check Size
            if (file.Length > maxSize || file.Length == 0)
            {
                return null;
            }
            //3. Get located folder path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", folderName);
            //4.Get File name(make file name unique)
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            //5. Get File Path
            var filePath = Path.Combine(folderPath, fileName);
            //6. Create file stream
            using FileStream fs = new FileStream(filePath, FileMode.Create);
            //7. Copy file 
            file.CopyTo(fs);
            //8. Return File Name
            return fileName;

        }
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;

        }


    }
}