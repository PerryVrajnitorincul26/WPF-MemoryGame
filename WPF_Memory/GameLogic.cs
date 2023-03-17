﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Windows;
namespace WPF_Memory
{
    public static class EnumerableExtensions
    {
        //HOW ON EARTH IS C# MISSING A SHUFFLE FEATURE C++ HAS HAD IT SINCE 2014!
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }
    
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (rng == null) throw new ArgumentNullException(nameof(rng));
    
            return source.ShuffleIterator(rng);
        }
    
        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];
    
                buffer[j] = buffer[i];
            }
        }
    }

    [Serializable]
    class Tile : INotifyPropertyChanged
    {

        [XmlAttribute]
        public int Id { get; set; }

        [XmlIgnore]
        private Visibility _isVisible;
        public Visibility IsVisible { get => _isVisible; set { if (_isVisible != value) _isVisible = value; NotifyPropertyChanged("IsVisible"); } }
        [XmlAttribute]
        public Uri _imagePath;
        public Uri ImagePath { get => _imagePath; set { if (_imagePath != value) _imagePath = value; NotifyPropertyChanged("ImagePath"); } }
        /// <summary>
        /// Note that (while unlikely) this could break on random number collisions.Hopefully it won't
        /// </summary>
        public Tile()
        {
            Id = -1;
            this.ImagePath = new Uri("C:/");
            IsVisible = Visibility.Hidden;
        }
        public Tile(Uri ImagePath)
        {
            this.Id = 0;
            this.ImagePath = ImagePath;
            IsVisible = Visibility.Hidden;
        }
        public Tile(int Id, Uri ImagePath)
        {
            this.Id = Id;
            _imagePath = ImagePath;
            IsVisible = Visibility.Hidden;
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
    class GameLogic
    {
        [XmlElement]
        public int Length { get; }
        [XmlElement]
        public int Width { get; }
        [XmlArray]
        public ObservableCollection<Tile> Tiles { get; set; }
        public GameLogic()
        {
            Length = 6;
            Width = 6;
            Tiles = new ObservableCollection<Tile>();
            var preShuffle = new ObservableCollection<Tile>();
            for (int i = 0; i < (Length*Width)/2; i++)
            {
                var imgPath = new Uri("C:\\Users\\mato274179\\source\\repos\\WPF_Memory\\WPF_Memory\\bin\\Debug\\Resources\\CarTileSet\\" + i.ToString() + ".jpg", UriKind.Absolute);
                preShuffle.Add(new Tile(i,imgPath));
                preShuffle.Add(new Tile(i,imgPath));
            }
            foreach(var i in preShuffle)
            {
                Tiles.Add(i);
            }

        }
        public GameLogic(int l,int w,string pathBase)
        {
            Length = l;
            Width = w;
            var preShuffle = new ObservableCollection<Tile>();
            for (int i = 0; i < Length*Width; i++)
            {
                string imgPath = pathBase + i.ToString() + ".jpg";
                preShuffle.Add(new Tile());
                preShuffle.Add(new Tile());
            }
            Tiles = (ObservableCollection<Tile>)preShuffle.Shuffle();
        }
    }
}
