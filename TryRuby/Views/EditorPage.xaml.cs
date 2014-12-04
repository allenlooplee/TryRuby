using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TryRuby.ViewModels;

namespace TryRuby.Views
{
    public partial class EditorPage : PhoneApplicationPage
    {
        public EditorPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (DataContext == null)
            {
                DataContext = new EditorViewModel(NavigationContext.QueryString["filename"]);
            }
        }
    }
}