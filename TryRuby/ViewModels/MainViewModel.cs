using Coding4Fun.Toolkit.Controls;
using IronRuby;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
                    // Road map:
                    // 1. Execute basic code with context
                    // 2. Style it as message conversation
                    // 3. Inspect complex object like native ruby
                    // 4. Deal with exception

                    if (!String.IsNullOrWhiteSpace(InputBox))
                    {
                        OutputPanel.Add(
                            new ChatBubbleViewModel
                            {
                                Text = InputBox,
                                Direction = ChatBubbleDirection.LowerRight,
                                Opacity = .6,
                                HorizontalAlignment = HorizontalAlignment.Right
                            });
                        
                        var result = _engine.Execute(InputBox, _scope);
                        if (result != null)
                        {
                            OutputPanel.Add(
                                new ChatBubbleViewModel
                                {
                                    Text = result.ToString(),
                                    Direction = ChatBubbleDirection.UpperLeft,
                                    Opacity = 1,
                                    HorizontalAlignment = HorizontalAlignment.Left
                                });
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
    }
}
