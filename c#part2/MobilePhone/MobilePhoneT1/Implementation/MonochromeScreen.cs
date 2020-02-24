using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneT1
{
    class MonochromeScreen : IScreen
    {
        private string type;
        private Resolution resolution;

        public MonochromeScreen(string type, int x, int y) {
            this.type = type;
            resolution = new Resolution();
            resolution.x = x;
            resolution.y = y;

        }

        private MonochromeScreen() {
        }

        public Resolution Resolution
        {
            get
            {
                return resolution;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
        }

        public string GetDescription()
        {
            return $"screen type: {type}, x:y resolution: {resolution.x}:{resolution.y}";
        }
    }
}
