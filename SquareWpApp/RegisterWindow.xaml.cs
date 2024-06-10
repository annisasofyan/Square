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
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows;
namespace SquareWpApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            try
            {
                var registerResult = await RegisterAsync(name, username, email, password);

                if (registerResult != null && registerResult.Status == 201)
                {
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    string errorMessage = "Registration failed: " + registerResult?.Title + "\n";

                    if (registerResult.Errors != null)
                    {
                        object errrorResult = registerResult.Errors;

                        foreach (var error in registerResult.Errors)
                        {
                            errorMessage += $"{error.Key}: {string.Join(", ", error.Value)}\n";
                        }
                    }

                    MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private async Task<RegisterResponse> RegisterAsync(string name, string username, string email, string password)
        {
            var registerRequest = new RegisterRequest
            {
                Name = name,
                UserName = username,
                Email = email,
                Password = password
            };

            HttpResponseMessage response;
            try
            {
                response = await client.PostAsJsonAsync("https://squareapi.numpang.my.id/api/User/Register", registerRequest);
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await response.Content.ReadFromJsonAsync<RegisterResponse>();
                    return errorResponse;
                }
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error contacting the API: " + ex.Message);
            }

            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }
    }
}
