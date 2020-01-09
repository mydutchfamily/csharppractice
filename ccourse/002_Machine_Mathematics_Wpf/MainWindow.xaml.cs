using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _002_Machine_Mathematics_Wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string type = ((Button)sender).Content.ToString();
            MessageBox.Show(string.Format("Type {0} has range: {1}", type, RangeByType(type)));
        }

        private string RangeByType(string type)
        {

            switch (type)
            {
                case "Byte":
                    {
                        return "from 1 to 2";
                    }
                case "Sbyte":
                    {
                        return "from 1 to 2";
                    }
                case "Short":
                    {
                        return "from 1 to 2";
                    }
                case "Ushort":
                    {
                        return "from 1 to 2";
                    }
                case "Int":
                    {
                        return "from 1 to 2";
                    }
                case "Uint":
                    {
                        return "from 1 to 2";
                    }
                case "Long":
                    {
                        return "from 1 to 2";
                    }
                case "Ulong":
                    {
                        return "from 1 to 2";
                    }
                default:
                    {
                        return "from X to Y";
                    }
            }
        }

    }
}
