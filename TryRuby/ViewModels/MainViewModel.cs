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
using TryRuby.Utils;

namespace TryRuby.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            ChatMessages = new ObservableCollection<ChatMessageViewModel>();

            PostMessage("Hi, I'm Ruby. What expressions do you want me to evaluate?", ChatMessageKind.Received);

            EnterCommand = new ActionCommand(
                async () => 
                {
                    if (!String.IsNullOrWhiteSpace(SourceCode))
                    {
                        PostMessage(SourceCode, ChatMessageKind.Sent);

                        IsEvaluating = true;

                        Repl.Instance.SourceCode = SourceCode;
                        var result = await Repl.Instance.EvaluateAsync();

                        IsEvaluating = false;

                        if (!String.IsNullOrEmpty(result))
                        {
                            PostMessage(result, ChatMessageKind.Received);
                        }

                        SourceCode = null;
                    }
                });
        }

        public ObservableCollection<ChatMessageViewModel> ChatMessages { get; private set; }

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

        private bool _isEvaluating;

        public bool IsEvaluating
        {
            get { return _isEvaluating; }
            set
            {
                if (_isEvaluating != value)
                {
                    _isEvaluating = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand EnterCommand { get; private set; }

        private void PostMessage(string text, ChatMessageKind kind)
        {
            ChatMessages.Add(
                new ChatMessageViewModel
                {
                    Text = text,
                    Kind = kind
                });
        }
    }
}
