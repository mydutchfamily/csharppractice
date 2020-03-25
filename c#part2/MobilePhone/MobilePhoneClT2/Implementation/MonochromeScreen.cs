using MobilePhoneClT2.Enums;

namespace MobilePhoneClT2.Implementation
{
    public class MonochromeScreen : IScreen
    {
        private string type;
        private Resolution resolution;

        public ComponentTypes ComponentType { get; } = ComponentTypes.Screen;
        public string SerialNumber { get; }

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
        public MonochromeScreen(string type, int x, int y, string serialNumber) {
            this.type = type;
            resolution = new Resolution
            {
                x = x,
                y = y
            };

            this.SerialNumber = serialNumber;

        }

        public override string ToString()
        {
            return $"screen type: {type}, resolution: {resolution.x}:{resolution.y}";
        }
    }
}
