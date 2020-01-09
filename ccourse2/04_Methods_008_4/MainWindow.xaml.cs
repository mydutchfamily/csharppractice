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

namespace _04_Methods_008_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int operation = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            switch (((RadioButton)sender).Content)
            {
                case "остаток от деления":
                    {
                        operation = 0;
                        break;
                    }
                case "возведение в степень":
                    {
                        operation = 1;
                        break;
                    }
                case "конкатенация":
                    {
                        operation = 2;
                        break;
                    }
                case "деление":
                    {
                        operation = 3;
                        break;
                    }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            double y = 0;
            double result = 0;

            Boolean bolX = Double.TryParse(arg1.Text, out x);
            Boolean bolY = Double.TryParse(arg2.Text, out y);

            if (bolX && bolY)
            {
                switch (operation)
                {
                    case 0://"остаток от деления":
                        {
                            result = x % y;
                            break;
                        }
                    case 1:// "возведение в степень":
                        {
                            result = Math.Pow(x, y);
                            break;
                        }
                    case 2:// "конкатенация":
                        {
                            result = x + y;
                            break;
                        }
                    case 3:// "деление":
                        {
                            if (y == 0)
                            {
                                result = 0;
                            }
                            else
                            {
                                result = x / y;
                            }
                            break;
                        }
                }                
            }
            CalcResult.Text = result.ToString();
        }
    }
}
