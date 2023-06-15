using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using static System.Net.WebRequestMethods;

namespace PrestionLayer.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string FolderName)
        {
            ///1- get located folder paht

            //string folderPath = "D:\\Dot Net\\ASP.NET CORE\\Session 02\\Demos\\PrestionLayerSoulnew\\PrestionLayer\\wwwroot\\files\\"

            //string folderPath = Directory.GetCurrentDirectory() + "wwwroot\files\\" + FolderName;

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files\\", FolderName);

            //2 - get file name and make uniqe

            string fileName = $"{Guid.NewGuid()}{file.FileName}";

            //3- get file path
            string filePath = Path.Combine(folderPath, fileName);

            //4-save file as Strime [DATA PER TIME]

            using var fs = new FileStream(filePath, FileMode.Create); 
            file.CopyTo(fs);
            return fileName;
        }
    }
}
