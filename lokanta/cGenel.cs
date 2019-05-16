using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lokanta
{
    class cGenel
    {
        public string conString = ("Data Source=MMG\\MMG;Initial Catalog=lokantadb;Integrated Security=True"); 

        public static int _personelId;  //static olma sebebi her yerden ulaşmak istememiz
        public static int _gorevId;

        public static string _ButtonValue;
        public static string _ButtonName;

        public static int _ServisTurNo;
        public static string _AdisyonId;
    }
}
