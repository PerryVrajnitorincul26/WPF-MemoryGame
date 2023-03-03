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
        
    }
    public class User
    {
        String user_name;
        String user_profile;
        Statistics user_stats;
        
        
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
