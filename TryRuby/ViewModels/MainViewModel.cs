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
            OutputPanel = new ObservableCollection<ChatBubbleViewModel>();

            WriteIncome("Hi, I'm Ruby. What expressions do you want me to evaluate?");

            EnterCommand = new ActionCommand(
                () => 
                {
                    if (!String.IsNullOrWhiteSpace(InputBox))
                    {
                        WriteOutgo(InputBox);

                        var result = Repl.Instance.Evaluate(InputBox);
                        if (!String.IsNullOrEmpty(result))
                        {
                            WriteIncome(result);
                        }

                        InputBox = null;
                    }
                });
        }

        public ObservableCollection<ChatBubbleViewModel> OutputPanel { get; private set; }

        private string _inputBox;
        public string InputBox
        {
            get { return _inputBox; }
            set
            {
                if (_inputBox != value)
                {
                    _inputBox = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand EnterCommand { get; private set; }

        private void WriteIncome(string text)
        {
            OutputPanel.Add(
                new ChatBubbleViewModel
                {
                    Text = text,
                    Direction = ChatBubbleDirection.UpperLeft,
                    Opacity = 1,
                    HorizontalAlignment = HorizontalAlignment.Left
                });
        }

        private void WriteOutgo(string text)
        {
            OutputPanel.Add(
                new ChatBubbleViewModel
                {
                    Text = text,
                    Direction = ChatBubbleDirection.LowerRight,
                    Opacity = .6,
                    HorizontalAlignment = HorizontalAlignment.Right
                });
        }
    }
}
