using Newtonsoft.Json;
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

namespace WeatherCity2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            BtnRestoreDown.Style = (Style)FindResource("bt_RestoreDownWindow");
            LoadCities();
        }
        private async void LoadCities()
        {
            try
            {
                var cities = await GetCitiesAsync();
                CityComboBox.ItemsSource = cities;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cities: " + ex.Message);
            }
        }
        private async Task<List<City>> GetCitiesAsync()
        {
            var response = await client.GetStringAsync("https://squareapi.numpang.my.id/api/City");
            var cityList = JsonConvert.DeserializeObject<List<City>>(response);
            return cityList;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnRestoreDown_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState=WindowState.Maximized;
                BtnRestoreDown.Style = (Style)FindResource("bt_RestoreDownWindow");
            }
            else
            {
                this.WindowState = WindowState.Normal;
                BtnRestoreDown.Style = (Style)FindResource("bt_MaximizeWindow");


            }
        }

        private void BtnClos_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CityComboBox.SelectedItem is City selectedCity)
            {
                var weatherDetails = selectedCity.WeatherDetails[0];
                var weather = weatherDetails.Weather;

                WeatherTimeLabel.Content = weather.Time.ToString("HH:mm");
                WeatherDetailLabel.Content = $"Temperature: {weather.Temperature}°C\n" +
                                             $"Humidity: {weather.Humidity}%\n" +
                                             $"Wind Speed: {weather.WindSpeed} km/h\n" +
                                             $"Weather Conditions: {GetWeatherConditions(weather)}";

                // Update image source based on weather condition
                WeatherImage.Source = new BitmapImage(new Uri($"Assets/{GetWeatherImage(weather)}.png", UriKind.Relative));
            }
        }
        private string GetWeatherImage(Weather weather)
        {
            // Determine the appropriate weather image based on the weather condition
            // This is a placeholder logic, you should implement it based on your specific requirements
            if (weather.Temperature > 30)
            {
                return "typcn_weather-sunny";
            }
            else if (weather.Temperature > 20)
            {
                return "typcn_weather-partly-sunny";
            }
            else
            {
                return "typcn_weather-cloudy";
            }
        }

        private string GetWeatherConditions(Weather weather)
        {
            // Determine the weather conditions info
            // This is a placeholder logic, you should implement it based on your specific requirements
            if (weather.Temperature > 30)
            {
                return "Hot and Sunny";
            }
            else if (weather.Temperature > 20)
            {
                return "Warm and Partly Sunny";
            }
            else
            {
                return "Cool and Cloudy";
            }
        }
    }

    public class CityResponse
    {
        [JsonProperty("$values")]
        public List<City> Values { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("weatherDetails")]
        public List<WeatherDetail> WeatherDetails { get; set; }
    }

    public class WeatherDetailsResponse
    {
        [JsonProperty("$values")]
        public List<WeatherDetail> Values { get; set; }
    }

    public class WeatherDetail
    {
        public int Id { get; set; }
        public int WeatherId { get; set; }
        public int CityId { get; set; }
        public Weather Weather { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int WindSpeed { get; set; }
        public DateTime Time { get; set; }
        public List<WeatherDetail> WeatherDetails { get; set; }
    }

}
