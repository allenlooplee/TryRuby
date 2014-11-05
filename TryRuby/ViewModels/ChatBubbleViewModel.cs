﻿using Coding4Fun.Toolkit.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TryRuby.ViewModels
{
    public class ChatBubbleViewModel
    {
        public ChatBubbleViewModel()
        {
            Timestamp = DateTime.Now;
        }

        public string Text { get; set; }

        public DateTime Timestamp { get; private set; }

        public ChatBubbleDirection Direction { get; set; }

        public double Opacity { get; set; }

        public HorizontalAlignment HorizontalAlignment { get; set; }
    }
}
