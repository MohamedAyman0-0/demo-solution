using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession3.BuisnessLogic.Services.Interfaces
{
    public interface IAttachmentService
    {
        //Upload
        public string? Upload(IFormFile file, string folderName);
        //Delete
        public bool Delete(string filePath);
    }
}