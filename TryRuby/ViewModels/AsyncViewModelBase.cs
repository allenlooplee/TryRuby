using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TryRuby.Utils;

namespace TryRuby.ViewModels
{
    public class AsyncViewModelBase : ObservableObject
    {
        private bool _isExecutingCommand;
        public bool IsExecutingCommand
        {
            get { return _isExecutingCommand; }
            set
            {
                if (_isExecutingCommand != value)
                {
                    _isExecutingCommand = value;
                    RaisePropertyChanged();
                }
            }
        }

        protected ICommand CreateAsyncCommand(Func<Task> asyncAction)
        {
            return CreateCommand(
                async () =>
                {
                    IsExecutingCommand = true;

                    await asyncAction();

                    IsExecutingCommand = false;
                });
        }

        protected ICommand CreateCommand(Action action)
        {
            return new ActionCommand(action);
        }
    }
}
