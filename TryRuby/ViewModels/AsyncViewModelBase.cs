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

        protected ICommand CreateAsyncCommand(Func<Task> asyncAction)
        {
            return CreateCommand(
                async () =>
                {
                    IsEvaluating = true;

                    await asyncAction();

                    IsEvaluating = false;
                });
        }

        protected ICommand CreateCommand(Action action)
        {
            return new ActionCommand(action);
        }
    }
}
