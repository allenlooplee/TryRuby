using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TryRuby.Models;

namespace TryRuby.ViewModels
{
    public class EditorViewModel : AsyncViewModelBase
    {
        public EditorViewModel(string fileName)
        {
            FileName = fileName;

            InitializeCommand = CreateAsyncCommand(
                async () =>
                {
                    SourceCode = await CodeFileManager.Instance.LoadCodeFileAsync(FileName);
                });

            OkCommand = CreateAsyncCommand(
                async () =>
                {
                    await CodeFileManager.Instance.SaveCodeFileAsync(
                        FileName,
                        // The edited source code contains a mix of "\r\n" and "\r".
                        // Normalize them to be "\r\n".
                        // Any better solution?
                        SourceCode.Replace("\r\n", "\r").Replace("\r", "\r\n"),
                        false);

                    App.RootFrame.GoBack();
                });

            CancelCommand = CreateCommand(App.RootFrame.GoBack);
        }

        public string FileName { get; set; }

        private string _sourceCode;
        public string SourceCode
        {
            get { return _sourceCode; }
            set
            {
                if (_sourceCode != value)
                {
                    _sourceCode = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand InitializeCommand { get; private set; }

        public ICommand OkCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }
    }
}
