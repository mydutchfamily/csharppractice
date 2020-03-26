using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilePhoneWfT2
{
    class TextBoxOutput : IOutput
    {
        private RichTextBox richTextBox;
        public TextBoxOutput(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
        }
        public void Write(string text)
        {
            richTextBox.AppendText(text);
        }

        public void WriteLine(string text)
        {
            richTextBox.AppendText("\n");
            richTextBox.AppendText(text);
        }
    }
}
