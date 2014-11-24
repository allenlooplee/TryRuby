using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;

namespace TryRuby.Utils
{
    public class FileUtil
    {
        public static async Task<StorageFile> WriteAllTextAsync(string folderName, string fileName, string text)
        {
            var rootFolder = ApplicationData.Current.LocalFolder;
            var folder = await rootFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            using (var stream = await file.OpenStreamForWriteAsync())
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteAsync(text);
            }

            return file;
        }

        public static async Task<string> ReadAllTextAsync(string folderName, string fileName)
        {
            var rootFolder = ApplicationData.Current.LocalFolder;
            var folder = await rootFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            var file = await folder.GetFileAsync(fileName);

            using (var stream = await file.OpenStreamForReadAsync())
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task DeleteAsync(string folderName, string fileName)
        {
            var rootFolder = ApplicationData.Current.LocalFolder;
            var folder = await rootFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            var file = await folder.GetFileAsync(fileName);

            await file.DeleteAsync();
        }

        public static async Task<IEnumerable<StorageFile>> EnumerateFilesAsync(string folderName)
        {
            var rootFolder = ApplicationData.Current.LocalFolder;
            var folder = await rootFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            return await folder.GetFilesAsync();
        }
    }
}
