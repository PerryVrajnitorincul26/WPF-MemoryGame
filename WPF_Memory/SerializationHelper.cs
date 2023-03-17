using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WPF_Memory
{
    //[Serializable]
    //class ObjectToSerialize
    //{
    //    [XmlArray]
    //    public ObservableCollection<User> Users { get; set; }
    //    public ObjectToSerialize()
    //    {
    //        Users = new ObservableCollection<User>();
    //    }
    //}
    class SerializationHelper
    {
        UserSelect myUsers;
        public SerializationHelper(UserSelect myUsers)
        {
            this.myUsers = myUsers; 
        }
        public void SerializeObject(UserSelect entity)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(UserSelect));
            FileStream fileStr = new FileStream("output.xml", FileMode.Create);
            xmlser.Serialize(fileStr, entity);
            fileStr.Dispose();
        }
        public void DeserializeObject()
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(UserSelect));
            FileStream file = new FileStream("output.xml", FileMode.Open);
            //se pierde referinta la colectie prin reinitializarea ei cu un alt obiect
            //this.users = (xmlser.Deserialize(file) as UserSelect).Cars;
            //din acest motiv repopulez colectia this.users cu elementele colectiei obtinute prin deserializare
            var temp = xmlser.Deserialize(file) as UserSelect;
            myUsers.KnownUsers.Clear();
            foreach(var i in temp.KnownUsers)
            {
                myUsers.KnownUsers.Add(i);
            }
            myUsers.CurrentUser = temp.CurrentUser;
            file.Dispose();
        }
    }
}
