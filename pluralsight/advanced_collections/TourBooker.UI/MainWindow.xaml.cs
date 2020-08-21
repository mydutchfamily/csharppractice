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
using TourBooker.Logic;

namespace TourBooker.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppData AllData { get; } = new AppData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AllData.Initialize(
                @"C:\csharp\code\pluralsight\advanced_collections\TourBooker\PopbyLargestFinal.csv");
            this.DataContext = AllData;
        }

        private void tbxCountryCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string code = tbxCountryCode.Text;
            this.grdSelectCountry.DataContext = GetCountryWithCode(code);
        }

        private Country GetCountryWithCode(string code)
        {
            if (code.Length != 3) return null;

            //return AllData.AllCountries.Find(x => x.Code == code);

            Country result;
            //AllData.AllCountriesByKey.TryGetValue(code, out result);

            AllData.AllCountriesCCByKey.TryGetValue(new CountryCode(code), out result); 

            return result;
        }
    }
}
