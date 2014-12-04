using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace TryRuby.Behaviors
{
    public class EditCodeAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            if (!String.IsNullOrWhiteSpace(FileName))
            {
                App.RootFrame.Navigate(new Uri("/Views/EditorPage.xaml?filename=" + FileName, UriKind.Relative));
            }
        }

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(EditCodeAction), new PropertyMetadata(null));
    }
}
