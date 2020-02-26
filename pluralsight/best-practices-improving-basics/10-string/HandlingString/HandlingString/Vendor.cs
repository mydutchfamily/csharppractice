using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingString
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor
    {
        public enum IncludeAddress { Yes, No };
        public enum SendCopy { Yes, No };

        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        public string ProductCode => String.Format("{0}-{1:000}", this.CompanyName, this.VendorId);
        public string VendorCode => $"{this.CompanyName}-{this.VendorId:000}";

        public override string ToString()
        {
            string vendorInfo = "Vendor: " + this.CompanyName;
            string result;
            result = vendorInfo?.ToLower();
            result = vendorInfo?.ToUpper();
            result = vendorInfo?.Replace("Vendor", "Supplier");

            var length = vendorInfo?.Length;
            var index = vendorInfo?.IndexOf(":");
            var begins = vendorInfo?.StartsWith("Vendor");

            return vendorInfo;
        }

        public string PrepareDirections()
        {
            var directions = @"Insert \r\n to define a new line";
            return directions;
        }

        public string PrepareDirectionsOnTwoLines()
        {
            var directions = "First do this" + Environment.NewLine +
                            "Then do that";
            var directions2 = "First do this\r\nThen do that";

            var directions3 = @"First do this
Then do that";// new line entered in editor as is, all drx are equals

            return directions;
        }

        public string PlaceOrder(int quantity, DateTimeOffset? deliveryBy = null,
            string instructions = "standard delivery")
        {
            var txtBuilder = new StringBuilder("Order from Acme" + System.Environment.NewLine );
            txtBuilder.Append("Product: rtgfh" + System.Environment.NewLine);
            txtBuilder.Append($"Quantity: {quantity}");

            if (deliveryBy.HasValue)
            {
                txtBuilder.Append(System.Environment.NewLine + "Delivery by: " + deliveryBy.Value.ToString("d"));
            }

            if (!String.IsNullOrWhiteSpace(instructions))
            {
                txtBuilder.Append(System.Environment.NewLine + "Instructions: " + instructions);
            }
            return txtBuilder.ToString();
        }
    }
}
