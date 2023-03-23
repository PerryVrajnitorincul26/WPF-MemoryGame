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
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Memory
{
    /// <summary>
    /// Interaction logic for GameConfig.xaml
    /// </summary>
    public partial class GameConfig : Window
    {
        SerializationHelperGame SrlXml;
        GameLogic CurrentGame = null;
        public GameConfig(UserSelect usr)
        {
            InitializeComponent();
            UserField.DataContext = usr;
        }

        private void GameConfig_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Width_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Savegame_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void FilePicker_Click(object sender, RoutedEventArgs e)
        {
            var FileDiag = new OpenFileDialog();
            if (FileDiag.ShowDialog() == true)
                (this.DataContext as GameConfigContext).SaveLocation = new Uri(FileDiag.FileName);
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SrlXml = new SerializationHelperGame(this.DataContext as GameConfigContext);
            SrlXml.SerializeObject(this.DataContext as GameConfigContext);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var temp = this.DataContext as GameConfigContext;
            var stats = (UserField.DataContext as UserSelect);
            Game gwindow;
            if (CurrentGame == null)
            {
                gwindow = new Game(temp.Width,temp.Length);
                CurrentGame = gwindow.GameGridControl.DataContext as GameLogic;
            }
            else
            {
                gwindow = new Game();
                gwindow.GameGridControl.DataContext = CurrentGame;
            }
            gwindow.ShowDialog();
            stats.CurrentUser.UserStats.PlayedGames++;
            if((gwindow.GameGridControl.DataContext as GameLogic).Won)
            {
                gwindow = new Game(temp.Width,temp.Length);
                CurrentGame = gwindow.GameGridControl.DataContext as GameLogic;
                temp.Won++;
                if(temp.Won == 3)
                {
                    MessageBox.Show("You've won 3 consecutive games");
                    temp.Won = 0;
                    stats.CurrentUser.UserStats.WonGames++;
                }
            }
        }
    }
}
