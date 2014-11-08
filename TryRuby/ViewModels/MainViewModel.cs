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
            Messages = new ObservableCollection<MessageViewModel>();

            PostMessage("Hi, I'm Ruby. What expressions do you want me to evaluate?", MessageKind.Received);

            EnterCommand = new ActionCommand(
                () => 
                {
                    if (!String.IsNullOrWhiteSpace(Code))
                    {
                        PostMessage(Code, MessageKind.Sent);

                        var result = Repl.Instance.Evaluate(Code);
                        if (!String.IsNullOrEmpty(result))
                        {
                            PostMessage(result, MessageKind.Received);
                        }

                        Code = null;
                    }
                });
        }

        public ObservableCollection<MessageViewModel> Messages { get; private set; }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand EnterCommand { get; private set; }

        private void PostMessage(string text, MessageKind kind)
        {
            Messages.Add(
                new MessageViewModel
                {
                    Text = text,
                    Kind = kind
                });
        }
    }
}
