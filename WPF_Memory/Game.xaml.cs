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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        Tile PreviousTile;
        public Game()
        {
            InitializeComponent();
            PreviousTile = new Tile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var CurrentTile = ((sender as Button).DataContext as Tile);
            if (CurrentTile.IsVisible == Visibility.Visible)//Prevent double clicking and turning off previously found tiles
                return;
            CurrentTile.IsVisible = Visibility.Visible;
            if (PreviousTile.Id == -1)
            {
                PreviousTile = CurrentTile;
                return;
            }
            if (CurrentTile.Id != PreviousTile.Id)
            {
                PreviousTile.IsVisible = Visibility.Hidden;
                CurrentTile.IsVisible = Visibility.Hidden;
                PreviousTile = new Tile();
            }
            else
            {
                PreviousTile = new Tile();
            }
        }
    }
}
