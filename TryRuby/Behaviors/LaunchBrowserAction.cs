using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Interactivity;
using Microsoft.Phone.Tasks;

namespace TryRuby.Behaviors
{
	//
	// If you want your Action to target elements other than its parent, extend your class
	// from TargetedTriggerAction instead of from TriggerAction
	//
	public class LaunchBrowserAction : TriggerAction<DependencyObject>
	{
		public LaunchBrowserAction()
		{
			// Insert code required on object creation below this point.
		}

		protected override void Invoke(object o)
		{
			// Insert code that defines what the Action will do when triggered/invoked.
            if (!String.IsNullOrWhiteSpace(Uri))
            {
                var task = new WebBrowserTask();
                task.Uri = new Uri(Uri, UriKind.Absolute);
                task.Show();
            }
		}

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Uri.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UriProperty =
            DependencyProperty.Register("Uri", typeof(string), typeof(LaunchBrowserAction), new PropertyMetadata(null));
	}
}