using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;

namespace TryRuby.Utils
{
    public class StorageManager
    {
        private static StorageManager _instance = new StorageManager();
        public static StorageManager Instance
        {
            get { return _instance; }
        }

        public async Task SaveFileAsync(string folderName, string fileName, string content)
        {
            var rootFolder = ApplicationData.Current.LocalFolder;
            var folder = await rootFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            var file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

            using (var stream = await file.OpenStreamForWriteAsync())
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteAsync(content);
            }
        }

        public async Task<IEnumerable<string>> EnumerateFilesAsync(string folderName)
        {
            var rootFolder = ApplicationData.Current.LocalFolder;
            var folder = await rootFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
            var files = await folder.GetFilesAsync();

            return files.Select(f => f.Name);
        }

        public async Task<string> LoadFileAsync(string folderName, string fileName)
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
    }
}
