namespace MobilePhoneT1.Implementation
{
    class MonochromeScreen : IScreen
    {
        private string type;
        private Resolution resolution;

        public string ComponentType { get; } = "2 lines text monochrome display";
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

        private MonochromeScreen() {
        }
        public string GetDescription()
        {
            return $"screen type: {type}, resolution: {resolution.x}:{resolution.y}";
        }
    }
}
