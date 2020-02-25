﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1.Implementation
{
    class Keyboard : IKeyboard
    {
        public string ComponentType { get; } = "Button keypad";
        public string SerialNumber { get; }

        public List<string> Languages { get; } = new List<string>();
        public Keyboard(List<string> languages, string serialNumber)
        {
            this.SerialNumber = serialNumber;
            this.Languages = languages;
        }
        private Keyboard(){
        }
        public string GetDescription()
        {
            return $"keyboard support {Languages.Count} languages: {String.Join(",", Languages)}";
        }

    }
}
