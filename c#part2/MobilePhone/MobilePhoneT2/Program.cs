using MobilePhoneClT2.Interfaces;
using MobilePhoneClT2.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneClT2.Enums;

namespace MobilePhoneClT2
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhone gamePhone = new GamePhone("Bar", "BP20200321");

            IOutput output = new ConsoleOutput();

            IInterconnection headsetSony = new HeadsetSony("BP20200321", output);

            IInterconnection powerBank = new PowerBank("BP20200325", output);
            powerBank.PluginToUse = Plugins.Usb;

            Console.WriteLine("Select device to connect with the phone:");
            Console.WriteLine($"(1): {headsetSony}. Connected by bluetooth");
            Console.WriteLine($"(2): {headsetSony}. Connected by jack 3.5 mm");
            Console.WriteLine($"(3): {powerBank}");
            Console.WriteLine("Enter choice number");

            int choice;
            Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice) {
                case 1:
                    headsetSony.PluginToUse = Plugins.Bluetooth;
                    gamePhone.PluginDevice(headsetSony).ExecuteDevice(typeof(HeadsetSony).Name);
                    break;
                case 2:
                    headsetSony.PluginToUse = Plugins.HeadSetJack35;
                    gamePhone.PluginDevice(headsetSony).ExecuteDevice(typeof(HeadsetSony).Name);
                    break;
                case 3:
                    gamePhone.PluginDevice(powerBank).ExecuteDevice(typeof(PowerBank).Name);
                    break;
                default:
                    Console.WriteLine("Unknown device selected");
                    break;
            }

        }
    }
}
