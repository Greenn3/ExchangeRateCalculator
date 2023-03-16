using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace KalkulatorWalut2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Rate> ratesList;
        public MainPage()
        {
            this.InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void mainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ratesList = await ExchangeRateProcessor.LoadData();
            // listBox.ItemsSource = await ExchangeRateProcessor.LoadData();
            // listBox2.ItemsSource = await ExchangeRateProcessor.LoadData();
            ratesList.Insert(0, new Rate() { currency = "polski złoty", code = "PLN", mid = 1.000});
            listBox.ItemsSource = ratesList;
            listBox2.ItemsSource = ratesList;

              listBox.SelectedIndex = 0;
            listBox2.SelectedIndex = 1;
            // Rat rate = await ExchangeRateProcessor.LoadData();
            //textBlock.Text = await ExchangeRateProcessor.LoadData();

        }

        private void listBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {

           
            //listBox.SelectedItem.
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlockCurr1.Text = ratesList[listBox.SelectedIndex].code;
         
        }

        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBlockCurr2.Text = ratesList[listBox2.SelectedIndex].code;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            double input; 
                Double.TryParse(textBoxCurr1.Text, out input);
            double num1 = ratesList[listBox.SelectedIndex].mid;
            double num2 = ratesList[listBox2.SelectedIndex].mid;
            double result = input * (num1/num2);

            textBoxCurr2.Text = result.ToString();


        }
    }

  //  List<Rate> currentRates = new List<Rate>();
}
