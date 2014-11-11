using Coding4Fun.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TryRuby.Models
{
    public class ReplMessage
    {
        public ReplMessage()
        {
            Timestamp = DateTime.Now;
        }

        public string Text { get; set; }

        public DateTime Timestamp { get; private set; }

        public ReplMessageKind Kind { get; set; }
    }

    public enum ReplMessageKind
    {
        Sent,
        Received
    }
}
