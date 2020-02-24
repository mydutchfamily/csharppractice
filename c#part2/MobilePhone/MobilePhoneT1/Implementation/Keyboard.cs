using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1.Implementation
{
    class Keyboard : IKeyboard
    {

        public Keyboard(List<string> languages) {
            this.languages = languages;
        }
        private Keyboard(){
        }

        private List<string> languages = new List<string>();
        public List<string> Languages
        {
            get
            {
                return languages;
            }
        }

        public string GetDescription()
        {
            return $"keyboard support {languages.Count} languages: {String.Join(",", languages)}";
        }
    }
}
