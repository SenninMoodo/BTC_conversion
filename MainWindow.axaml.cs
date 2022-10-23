using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            ApiCall();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient httpClient = new HttpClient()) //nach Verlassen von using wird die Session von httpClient geschlossen. Alternativ httpClient.Dispose() am Ende
            {
                string url = "https://api.coingecko.com/api/v3/coins/bitcoin?market_data=true";
                string response = await httpClient.GetStringAsync(url);
                var actualValue = JsonConvert.DeserializeObject<Root>(response);

                ConversionLabel.Content = Math.Round(actualValue.market_data.current_price.eur, 2);
                UpdateLabel.Content = DateTime.Now.ToString("HH:mm:ss");
            }
        }
        private async void ApiCall()
        {
            int time = 300000; //5min
            while (Active.loopIsActive) {
                
                using (HttpClient httpClient = new HttpClient()) //nach Verlassen von using wird die Session von httpClient geschlossen. Alternativ httpClient.Dispose() am Ende
                {   string url = "https://api.coingecko.com/api/v3/coins/bitcoin?market_data=true";
                    string response = await httpClient.GetStringAsync(url);
                    var actualValue = JsonConvert.DeserializeObject<Root>(response);
                
                    ConversionLabel.Content = Math.Round(actualValue.market_data.current_price.eur, 2) ;
                    UpdateLabel.Content = DateTime.Now.ToString("HH:mm:ss");
                    if (RadioButton1min.IsChecked == true)
                    {
                        RadioLabel.Content = "1 min checked";
                        time = 60000; //1min
                        //TextBlock.Text += $"Entered at {DateTime.Now.ToString("HH:mm:ss")} \r\n";
                    }
                    else if(RadioButton2min.IsChecked == true)
                    {
                        RadioLabel.Content = "2 min checked";
                        time = 120000; //2min
                       //TextBlock.Text += $"Entered at {DateTime.Now.ToString("HH:mm:ss")} \r\n";
                    }
                    else if (RadioButton10min.IsChecked == true)
                    {
                        RadioLabel.Content = "10 min checked";
                        time = 600000; //10min
                        //TextBlock.Text += $"Entered at {DateTime.Now.ToString("HH:mm:ss")} \r\n";
                    }
                    await Task.Delay(time); 
                }
                
            }
            
        }
        static class Active
        {
            public static bool loopIsActive = true;
        }
    }
    
}

