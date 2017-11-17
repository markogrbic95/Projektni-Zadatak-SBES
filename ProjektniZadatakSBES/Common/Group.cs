using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Group
    {
        private string groupName;
        private string owner;
        private List<string> listaKorisnika= new List<string>();

        public Group()
        {
            listaKorisnika = new List<string>();
        }

        [DataMember]
        public string GroupName
        {
            get
            {
                return groupName;
            }

            set
            {
                groupName = value;
            }
        }
        [DataMember]
        public string Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        }
        [DataMember]
        public List<string> ListaKorisnika
        {
            get
            {
                return listaKorisnika;
            }

            set
            {
                listaKorisnika = value;
            }
        }
    }
}
