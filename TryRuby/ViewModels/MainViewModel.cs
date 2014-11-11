using Coding4Fun.Toolkit.Controls;
using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TryRuby.Models;
using TryRuby.Utils;

namespace TryRuby.ViewModels
{
    public class MainViewModel : AsyncViewModelBase
    {
        public MainViewModel()
        {
            SendCommand = CreateAsyncCommand(
                async () => 
                {
                    if (!String.IsNullOrWhiteSpace(SourceCode))
                    {
                        await Repl.Instance.Send(SourceCode.Replace("\r", Environment.NewLine));

                        SourceCode = null;
                    }
                });
        }

        public ObservableCollection<ReplMessage> ReplMessages
        {
            get { return Repl.Instance.Messages; }
        }

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

        public ICommand SendCommand { get; private set; }
    }
}
