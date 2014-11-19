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
using Microsoft.Phone.Controls;
using TryRuby.Utils;
using Coding4Fun.Toolkit.Controls;

namespace TryRuby.Behaviors
{
	//
	// If you want your Action to target elements other than its parent, extend your class
	// from TargetedTriggerAction instead of from TriggerAction
	//
	public class SaveCodeAction : TriggerAction<DependencyObject>
	{
		public SaveCodeAction()
		{
			// Insert code required on object creation below this point.
		}

		protected override void Invoke(object o)
		{
			// Insert code that defines what the Action will do when triggered/invoked.

            // Steps:
            // 1. Ask for file name via CustomMessageBox with a TextBox.
            // 2. Save code in the Code folder via StorageManager.
            // 3. Prompt user when done via ToastPrompt.

            var textBox = new PhoneTextBox
            {
                Hint = "file name",
                FontSize = (double)App.Current.Resources["PhoneFontSizeNormal"],
                Padding = new Thickness(6),
            };

            var messageBox = new CustomMessageBox
            {
                Caption = "Save Code",
                Message = "Please type the file name without extension for the code to be saved in the below text box.",
                Content = textBox,
                LeftButtonContent = "ok",
                RightButtonContent = "cancel",
            };

            messageBox.Dismissed +=
                async (s, e) =>
                {
                    switch (e.Result)
                    {
                        case CustomMessageBoxResult.LeftButton:

                            if (!String.IsNullOrWhiteSpace(textBox.Text))
                            {
                                var fileName = textBox.Text + ".rb";

                                // NOTE:
                                // The current strategy for handling file name collision is that
                                // the content of the existing file will be overwritten SILENTLY.
                                // We might need a graceful way to inform the users of this fact
                                // or to give them opportunity to make a decision.
                                await StorageManager.Instance.SaveFileAsync("Code", fileName, Content);

                                var toast = new ToastPrompt();
                                toast.Message = "Code saved successfully.";
                                toast.Show();
                            }

                            break;
                        default:
                            // Do nothing when a user clicks cancel button or press back key.
                            break;
                    }
                };

            messageBox.Show();
		}

        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(SaveCodeAction), new PropertyMetadata(null));
	}
}