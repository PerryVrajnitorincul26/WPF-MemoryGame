using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;

namespace WPF_Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        SerializationHelper SrlXml;

        public MainWindow()
        {
            InitializeComponent();
            var myContext = this.DataContext as UserSelect;
            SrlXml = new SerializationHelper(myContext);
        }

        private void RemoveUserClicked(object sender, RoutedEventArgs e)
        {
            var ctx = (this.DataContext as UserSelect);
            var tmp = UserDropDown.SelectedIndex;
            ctx.KnownUsers.RemoveAt(tmp);
            //ctx.CurrentUser = ctx.KnownUsers[0];
        }

        private void SignupUserClicked(object sender, RoutedEventArgs e)
        {
            var Swindow = new SignUp();
            Swindow.ShowDialog();
            var newUser = (Swindow.DataContext as User);
            (this.DataContext as UserSelect).KnownUsers.Add(newUser);
            (this.DataContext as UserSelect).CurrentUser = newUser;
        }

        private void StartGameClicked(object sender, RoutedEventArgs e)
        {
            var w = new GameConfig(this.DataContext as UserSelect);
            w.ShowDialog();
        }

        private void QuitAppClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserSelectLoaded(object sender, RoutedEventArgs e)
        {
            SrlXml.DeserializeObject();
            Console.Write("debugStatement");
        }

        private void UserSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sIndex = (sender as ComboBox).SelectedIndex;
            var Cont = (this.DataContext as UserSelect);
            if(sIndex != -1)
                Cont.CurrentUser = Cont.KnownUsers[sIndex];
            Console.WriteLine("yeah");
            Console.Out.Flush();
        }

        private void MWindow_Closing(object sender, CancelEventArgs e)
        {
            SrlXml.SerializeObject(this.DataContext as UserSelect);
        }
    }
}
