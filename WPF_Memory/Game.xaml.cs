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
    public partial class Game : Window
    {
        Tile PreviousTile;
        private bool lck = false;
        public Game()
        {
            InitializeComponent();
            PreviousTile = new Tile();
        }
        public Game(int width, int length)
        {
            InitializeComponent();
            PreviousTile = new Tile();
            var temp = (GameGridControl.DataContext as GameLogic);
            temp.Width = width;
            temp.Length = length;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!lck)
            {
                lck = true;
                var CurrentTile = ((sender as Button).DataContext as Tile);
                if (CurrentTile.IsVisible == Visibility.Visible)//Prevent double clicking and turning off previously found tiles
                { lck = false; return;}
                CurrentTile.IsVisible = Visibility.Visible;
                if (PreviousTile.Id == -1)
                {
                    PreviousTile = CurrentTile;
                    lck = false;
                    return;
                }
                if (CurrentTile.Id != PreviousTile.Id)
                {
                    Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t =>
                    {
                        PreviousTile.IsVisible = Visibility.Hidden;
                        CurrentTile.IsVisible = Visibility.Hidden;
                        PreviousTile = new Tile();
                        lck = false;
                    });
                }
                else
                {
                    PreviousTile = new Tile();
                    (GameGridControl.DataContext as GameLogic).Score += 2;
                    lck = false;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
