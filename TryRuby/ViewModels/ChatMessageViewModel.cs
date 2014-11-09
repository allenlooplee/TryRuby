using Coding4Fun.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TryRuby.ViewModels
{
    public class ChatMessageViewModel
    {
        public ChatMessageViewModel()
        {
            Timestamp = DateTime.Now;
        }

        public string Text { get; set; }

        public DateTime Timestamp { get; private set; }

        public ChatMessageKind Kind { get; set; }
    }

    public enum ChatMessageKind
    {
        Sent,
        Received
    }
}
