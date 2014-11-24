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
using TryRuby.Models;

namespace TryRuby.Behaviors
{
	//
	// If you want your Action to target elements other than its parent, extend your class
	// from TargetedTriggerAction instead of from TriggerAction
	//
	public class DeleteCodeAction : TriggerAction<DependencyObject>
	{
		public DeleteCodeAction()
		{
			// Insert code required on object creation below this point.
		}

		protected override async void Invoke(object o)
		{
			// Insert code that defines what the Action will do when triggered/invoked.

            if (!String.IsNullOrWhiteSpace(FileName))
            {
                await CodeFileManager.Instance.DeleteCodeFileAsync(FileName);
            }
		}

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(DeleteCodeAction), new PropertyMetadata(null));
	}
}