using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Xml.Linq;

namespace WeatherCity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient Client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        //private async void FetchWeatherButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //string city = (CityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
        //    //if (string.IsNullOrEmpty(city))
        //    //{
        //    //    MessageBox.Show("Please select a city.");
        //    //    return;
        //    //}

        //    //string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric";

        //    //try
        //    //{
        //    //    string response = await Client.GetStringAsync(apiUrl);
        //    //    dynamic weatherData = JObject.Parse(response);

        //    //    WeatherConditionTextBlock.Text = $"Condition: {weatherData.weather[0].main}";
        //    //    TemperatureTextBlock.Text = $"Temperature: {weatherData.main.temp} °C";
        //    //    HumidityTextBlock.Text = $"Humidity: {weatherData.main.humidity} %";
        //    //    WindSpeedTextBlock.Text = $"Wind Speed: {weatherData.wind.speed} m/s";
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show($"Error fetching weather data: {ex.Message}");
        //    //}
        //    WeatherConditionTextBlock.Text = $"Condition: Winter";
        //    TemperatureTextBlock.Text = $"Temperature: 7°C";
        //    HumidityTextBlock.Text = $"Humidity: 60%";
        //    WindSpeedTextBlock.Text = $"Wind Speed: 70 m/s";
        //}
    }
}
