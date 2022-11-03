using Amirez.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Amirez.AmiPlanner.Utils.Extensions
{
    public static class FormFileExtensions
    {
        public static string Save(this IFormFile file)
        {
            try
            {
                var fileextension = Path.GetExtension(file.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                using (FileStream fs = File.Create(filename))
                {
                    file.CopyTo(fs);
                }
                return filename;
            }
            catch (Exception e)
            {
                throw new ResponseException(e.Message);
            }
        }
    }
}
