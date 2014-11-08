using Coding4Fun.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TryRuby.ViewModels
{
    public class MessageViewModel
    {
        public MessageViewModel()
        {
            Timestamp = DateTime.Now;
        }

        public string Text { get; set; }

        public DateTime Timestamp { get; private set; }

        public MessageKind Kind { get; set; }
    }

    public enum MessageKind
    {
        Sent,
        Received
    }
}
