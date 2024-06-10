using Newtonsoft.Json;
using SquareWpApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

namespace SquareWpApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        private string idToken;
        public MainWindow()
        {
            InitializeComponent();
            UpdateUIForLoggedOutState();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            try
            {
                var loginResult = await LoginAsync(username, password);

                if (loginResult != null && loginResult.Status == 200)
                {
                    idToken = loginResult.IdToken;
                    MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    UpdateUIForLoggedInState();
                }
                else
                {
                    MessageBox.Show("Login gagal: " + loginResult?.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    UpdateUIForLoggedOutState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                UpdateUIForLoggedOutState();
            }

        }
        private async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var loginRequest = new LoginRequest
            {
                UserName = username,
                Password = password
            };

            HttpResponseMessage response;
            try
            {
                response = await client.PostAsJsonAsync("https://squareapi.numpang.my.id/api/User/Login", loginRequest);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error saat menghubungi API: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }

        private  async void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(idToken))
            {
                MessageBox.Show("Silakan login terlebih dahulu.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var colorResult = await GetRandomSquareColorAsync(idToken);

                if (colorResult != null && colorResult.Status == 200)
                {
                    ColorSquare.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorResult.Result.Color));
                }
                else
                {
                    MessageBox.Show("Gagal mendapatkan warna: " + colorResult?.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async Task<SquareColorResponse> GetRandomSquareColorAsync(string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response;
            try
            {
                response = await client.GetAsync("https://squareapi.numpang.my.id/api/Square/Random");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error contacting the API: " + ex.Message);
            }

            return await response.Content.ReadFromJsonAsync<SquareColorResponse>();
        }


        private void UpdateUIForLoggedInState()
        {
            ChangeColorButton.IsEnabled = true;
            ColorSquare.Fill = new SolidColorBrush(Colors.Gray);
            StatusTextBlock.Text = "You can now change the square's colour.";
            StatusTextBlock.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void UpdateUIForLoggedOutState()
        {
            ChangeColorButton.IsEnabled = false;
            ColorSquare.Fill = new SolidColorBrush(Colors.Gray);
            StatusTextBlock.Text = "Please log in first to change the square's colour.";
            StatusTextBlock.Foreground = new SolidColorBrush(Colors.Gray);
            idToken = null;
        }
    }
}
