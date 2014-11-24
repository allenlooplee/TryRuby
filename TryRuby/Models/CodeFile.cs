using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TryRuby.Models
{
    public class CodeFile
    {
        public string FileName { get; set; }

        public DateTime DateModified { get; set; }

        public ulong Size { get; set; }
    }

    internal static class ExtensionMethods
    {
        public static async Task<CodeFile> ToCodeFile(this StorageFile file)
        {
            var properties = await file.GetBasicPropertiesAsync();

            return new CodeFile
            {
                FileName = file.Name,
                DateModified = properties.DateModified.DateTime,
                Size = properties.Size
            };
        }
    }
}
