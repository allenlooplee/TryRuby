using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryRuby.Utils;
using Windows.Storage;

namespace TryRuby.Models
{
    public class CodeFileManager
    {
        private CodeFileManager()
        {
            CodeFiles = new ObservableCollection<CodeFile>();
        }

        private static CodeFileManager _instance = new CodeFileManager();
        public static CodeFileManager Instance
        {
            get { return _instance; }
        }

        public ObservableCollection<CodeFile> CodeFiles { get; private set; }

        public async Task InitializeAsync()
        {
            if (!_hasInitialized)
            {
                foreach (var file in await FileUtil.EnumerateFilesAsync(FolderName))
                {
                    CodeFiles.Add(await file.ToCodeFile());
                }

                _hasInitialized = true;
            }
        }

        public async Task SaveCodeFileAsync(string fileName, string code)
        {
            var file = await FileUtil.WriteAllTextAsync(FolderName, fileName, code);

            if (_hasInitialized)
            {
                CodeFiles.Add(await file.ToCodeFile());
            }
        }

        public async Task EvaluateCodeFileAsync(string fileName)
        {
            var code = await FileUtil.ReadAllTextAsync(FolderName, fileName);

            if (!String.IsNullOrWhiteSpace(code))
            {
                await Repl.Instance.Send(code);
            }
        }

        public async Task DeleteCodeFileAsync(string fileName)
        {
            var codeFile = CodeFiles.First(cf => cf.FileName == fileName);
            CodeFiles.Remove(codeFile);

            await FileUtil.DeleteAsync(FolderName, fileName);
        }

        private const string FolderName = "Code";

        private bool _hasInitialized = false;
    }
}
