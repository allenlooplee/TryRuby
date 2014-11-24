using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TryRuby.Models;
using TryRuby.Utils;

namespace TryRuby.ViewModels
{
    public class ManageCodeFilesViewModel : AsyncViewModelBase
    {
        public ManageCodeFilesViewModel()
        {
            InitializeCommand = CreateAsyncCommand(CodeFileManager.Instance.InitializeAsync);
        }

        public ObservableCollection<CodeFile> CodeFiles
        {
            get { return CodeFileManager.Instance.CodeFiles; }
        }

        public ICommand InitializeCommand { get; private set; }
    }
}
