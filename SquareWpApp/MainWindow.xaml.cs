using Newtonsoft.Json;
using SquareWpApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;


            var loginResult = await LoginAsync(username, password);

            if (loginResult != null && loginResult.Status == 200)
            {
                MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                // Anda bisa menambahkan logika untuk membuka jendela lain atau melakukan aksi lainnya
            }
            else
            {
                MessageBox.Show("Login gagal: " + loginResult?.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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


    }
}
