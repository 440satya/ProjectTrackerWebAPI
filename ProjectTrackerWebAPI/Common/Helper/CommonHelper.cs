using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Common
{
    public static class CommonHelper
    {
        public static string GetTempFilePath(string fileName)
        {
            return Path.Combine(
                   Directory.GetCurrentDirectory(), "wwwroot", Constants.TempFilesPath,
                   fileName);
        }

        public static string GetPostImagePath(string newFileName, bool withRoot = false)
        {
            if (withRoot)
            {
                return Path.Combine(
                       Constants.ImageFolderWithRoot, "post",
                       newFileName);
            }
            else
            {
                return Constants.ImageFolder + "/post/" + newFileName;
            }
        }

        public static async Task WriteToFile(string logPath, string content)
        {
            //var logPath = @"SOME_PATH\log.txt";
            using var writer = File.CreateText(logPath);

            await writer.WriteLineAsync(content);
        }

        public static bool IsValidFile(string fileName)
        {
            var fileExt = Path.GetExtension(fileName)?.Trim('.');

            if (Constants.supportedImageTypes.Contains(fileExt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ExportExcel(DataTable dataTable, string excelName)
        {
            string Venu = excelName + "_" + DateTime.Now.ToString("d");
           
            try
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dataTable);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        wb.SaveAs(stream);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }




        //private static string GetContentType(string path)
        //{
        //    var types = GetMimeTypes();
        //    var ext = Path.GetExtension(path).ToLowerInvariant();
        //    return types[ext];
        //}

        //private static Dictionary<string, string> GetMimeTypes()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        {".png", "image/png"},
        //        {".jpg", "image/jpeg"},
        //        {".jpeg", "image/jpeg"},
        //        {".gif", "image/gif"}
        //    };
        //}
    }
}
