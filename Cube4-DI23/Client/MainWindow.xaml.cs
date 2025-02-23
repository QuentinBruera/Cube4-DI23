using Client.Services;
using Client.ViewModels;
using Model.InitDatas;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private LoginApiService _loginApiService;
        public MainWindow()
        {
            InitializeComponent();

            InitSeed.Seed();

            DataContext = new MainWindowViewModel();
        }
    }
}