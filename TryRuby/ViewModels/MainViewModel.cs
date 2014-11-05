using Coding4Fun.Toolkit.Controls;
using IronRuby;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
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
            _engine = Ruby.CreateEngine();
            _scope = _engine.CreateScope();

            OutputPanel = new ObservableCollection<ChatBubbleViewModel>();

            EnterCommand = new ActionCommand(
                () => 
                {
                    if (!String.IsNullOrWhiteSpace(InputBox))
                    {
                        WriteOutgo(InputBox);

                        try
                        {
                            var source = _engine.CreateScriptSourceFromString(InputBox, SourceCodeKind.Expression);
                            var props = source.GetCodeProperties();

                            if (props == ScriptCodeParseResult.Complete)
                            {
                                var result = source.Execute(_scope);

                                if (result != null)
                                {
                                    WriteIncome(_engine.Operations.Format(result));
                                }
                            }
                            else
                            {
                                WriteIncome("invalid expression");
                            }
                        }
                        catch (Exception ex)
                        {
                            WriteIncome(ex.Message);
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

        private ScriptEngine _engine;
        private ScriptScope _scope;

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
