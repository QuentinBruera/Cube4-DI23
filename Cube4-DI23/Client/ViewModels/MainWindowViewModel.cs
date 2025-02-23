using Client.Services;
using Client.Utils;
using Model.Request;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly LoginApiService _loginApiService;
        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ButtonGetSitesCommand { get; }

        public MainWindowViewModel()
        {
            _loginApiService = new LoginApiService();
            _ = InitializeAsync();

            ButtonGetSitesCommand = new RelayCommand(OnButtonClicked);
        }

        private async Task InitializeAsync()
        {
            try
            {
                IsLoading = true;
                bool isAuthenticated = await _loginApiService.LoginAsync(
                    new LoginRequest
                    {
                        Email = "admin@gmail.com",
                        Password = "Admin1!"
                    },
                    useCookies: true,
                    useSessionCookies: true
                );

                if (!isAuthenticated)
                {
                    MessageBox.Show("Échec de l'authentification.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    Application.Current.Shutdown();
                }

                // Autres initialisations (si nécessaire)
            }
            finally
            {
                IsLoading = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnButtonClicked(object? parameter)
        {
            SiteService siteService = new(_loginApiService.ApiService.HttpClient);
            var sites = await siteService.GetSites();

            Console.WriteLine("Bouton cliqué !");
        }
    }
}
