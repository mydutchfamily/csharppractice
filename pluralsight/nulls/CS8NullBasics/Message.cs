using System;
using System.Collections.Generic;
using System.Text;

namespace CS8NullBasics
{
    class Message
    {
        public string From1 { get; set; } = "";
        public string? From2 { get; set; } = "";
        public string? From3 { get; set; } = "";

        public string Text { get; set; } = "";

        public string ToUpperFrom1() => From1.ToUpperInvariant();

        public string ToUpperFrom2() {
            if (From2 is null) {
                return "";
            }

            return From2.ToUpperInvariant();
        }

        public string? ToUpperFrom3() => From3?.ToUpperInvariant();
    }
}
