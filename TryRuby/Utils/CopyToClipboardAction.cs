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

namespace TryRuby
{
	//
	// If you want your Action to target elements other than its parent, extend your class
	// from TargetedTriggerAction instead of from TriggerAction
	//
	public class CopyToClipboardAction : TriggerAction<DependencyObject>
	{
		public CopyToClipboardAction()
		{
			// Insert code required on object creation below this point.
		}

		protected override void Invoke(object o)
		{
			// Insert code that defines what the Action will do when triggered/invoked.
            if (!String.IsNullOrWhiteSpace(Text))
            {
                Clipboard.SetText(Text);
            }
		}

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CopyToClipboardAction), new PropertyMetadata(null));
	}
}