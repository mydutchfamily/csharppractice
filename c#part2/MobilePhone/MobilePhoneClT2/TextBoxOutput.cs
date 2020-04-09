using MobilePhoneClT2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilePhoneClT2
{
    public class TextBoxOutput : IOutput
    {
        public enum FormatingStyle { None, WithTime, WithDate, WithStars, WithQuotes };
        private RichTextBox richTextBox;
        public TextBoxOutput(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
        }
        public virtual void Write(string text)
        {
            richTextBox.AppendText(FormatText(text));
        }

        public virtual void WriteLine(string text)
        {
            richTextBox.AppendText("\n");
            Write(text);
        }

        public FormatingStyle Formating { get; set; } = FormatingStyle.None;

        private string FormatText(string textToFormat)
        {
            switch (Formating)
            {
                case FormatingStyle.None:
                    {
                        return textToFormat;
                    }
                case FormatingStyle.WithDate:
                    {

                        return $"{DateTime.Now.ToString("dd/MM/yyyy")}: {textToFormat}";
                    }
                case FormatingStyle.WithQuotes:
                    {

                        return $"\"{textToFormat}\"";
                    }
                case FormatingStyle.WithStars:
                    {

                        return $"******* {textToFormat} *******";
                    }
                case FormatingStyle.WithTime:
                    {

                        return $"{DateTime.Now.ToString("HH:mm:ss")}: { textToFormat}";
                    }
                default:
                    {
                        throw new FormatException($"Such formating {Formating} do not supported");
                    }
            }
        }
    }
}
