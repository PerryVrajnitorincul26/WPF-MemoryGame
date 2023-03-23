using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
namespace WPF_Memory
{
    [Serializable]
    public class Statistics :INotifyPropertyChanged
    {
        [XmlIgnore]
        private int _playedGames;
        [XmlElement]
        public int PlayedGames { get => _playedGames; set { if (value != _playedGames) _playedGames = value; NotifyPropertyChanged("PlayedGames"); } }
        [XmlIgnore]
        private int _wonGames;
        [XmlElement]
        public int WonGames { get => _wonGames; set { if (value != _wonGames) _wonGames = value; NotifyPropertyChanged("WonGames"); } }
        [XmlIgnore]
        public float WinRate { get { if (PlayedGames != 0) return WonGames / PlayedGames; else return 0; } }
        public Statistics()
        {
            PlayedGames = 0; WonGames = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
    [Serializable]
    public class User : INotifyPropertyChanged
    {
        [XmlAttribute]
        public String Username { get; set; }
        [XmlAttribute]
        private String _profilePicPath;
        public String ProfilePicPath { get => _profilePicPath; set { if (_profilePicPath != value) _profilePicPath = value;NotifyPropertyChanged("ProfilePicPath");} }
        [XmlIgnore]
        public ImageSource ProfilePicture { get; set; }
        [XmlElement]
        public Statistics UserStats { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public User()
        {
            Username = "Placeholder";
            UserStats = new Statistics();
            ProfilePicPath = "C:\\Users\\mato274179\\source\\repos\\WPF_Memory\\WPF_Memory\\Resources\\DefaultUserProfilePicture.png";
        }
        public User(bool GenerateDefaultUser)
        {
            Username = "default";
            UserStats = new Statistics();
            ProfilePicPath = "C:\\Users\\mato274179\\source\\repos\\WPF_Memory\\WPF_Memory\\Resources\\DefaultUserProfilePicture.png";

            //TODO: This will on invalid URLs may wanna place it in a try catch
            ProfilePicture = new BitmapImage(new Uri(ProfilePicPath));
        }
        public User(String ChosenName,string ChosenImage)
        {
            Username = ChosenName;
            UserStats = new Statistics();
            ProfilePicPath = ChosenImage;
            ProfilePicture = new BitmapImage(new Uri(ChosenImage));
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [Serializable]
    public class UserSelect  :INotifyPropertyChanged
    {
        [XmlElement]
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (value == _currentUser) return;
                _currentUser = value;
                NotifyPropertyChanged("CurrentUser");
            }
        }
        [XmlArray]
        public ObservableCollection<User> KnownUsers { get; set; }

        public UserSelect()
        {
            CurrentUser = new User();
            KnownUsers = new ObservableCollection<User>();
        }
        public UserSelect(User currentUser,ObservableCollection<User> knownUsers)
        {
            this.CurrentUser = currentUser;
            this.KnownUsers = knownUsers;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
