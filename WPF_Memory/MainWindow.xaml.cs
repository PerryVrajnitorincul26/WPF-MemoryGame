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

namespace WPF_Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Statistics
    {
        int PlayedGames;
        int WonGames;
        float WinRate; 
        public Statistics()
        {
            PlayedGames = 0;WonGames = 0;WinRate = 0.0f;
        }
    }
    public class User
    {
        public String Username { get; set; }
        public ImageSource ProfilePicture { get; set; }
        public Statistics UserStats;
        public User()
        {
            Username = "default";
            UserStats = new Statistics();
            ProfilePicture = new BitmapImage(new Uri("C:\\Users\\mato274179\\source\\repos\\WPF_Memory\\WPF_Memory\\Resources\\DefaultUserProfilePicture.png"));
        }
        public User(String ChosenName, ImageSource ChosenImage)
        {
            Username = ChosenName;
            UserStats = new Statistics();
            ProfilePicture = ChosenImage;
        }
    }
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void RemoveUserClicked(object sender, RoutedEventArgs e)
        {

        }

        private void SignupUserClicked(object sender, RoutedEventArgs e)
        {

        }

        private void StartGameClicked(object sender, RoutedEventArgs e)
        {
            GameConfig w = new GameConfig();
            w.Show();
        }

        private void QuitAppClicked(object sender, RoutedEventArgs e)
        {

        }

        private void UserSelectLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void UserSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
