using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Memory
{
    [Serializable]
    public class GameConfigContext:INotifyPropertyChanged
    {
        [XmlAttribute]
        public int Length{get;set;}
        [XmlAttribute]
        public int Width{get;set;}
        [XmlAttribute]
        public int Won{get;set;}
        [XmlIgnore]
        private Uri _saveLocation;
        [XmlIgnore]
        public Uri SaveLocation { get=>_saveLocation; set{ if (value != _saveLocation) _saveLocation = value; NotifyPropertyChanged("SaveLocation"); } }
        public GameConfigContext()
        {
            Length = 5;
            Width = 5;
            Won = 0;
            SaveLocation = new Uri("c:\\");
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
