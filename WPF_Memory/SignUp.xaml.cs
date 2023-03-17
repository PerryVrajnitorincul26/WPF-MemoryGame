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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WPF_Memory
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {   
        public SignUp()
        {
            InitializeComponent();
        }

        private void FileSelect_Clicked(object sender, RoutedEventArgs e)
        {
            var FileDiag = new OpenFileDialog();
            if(FileDiag.ShowDialog()== true)
                (this.DataContext as User).ProfilePicPath = FileDiag.FileName;
        }

        private void UsernameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            (this.DataContext as User).Username = UsernameBox.Text;
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
