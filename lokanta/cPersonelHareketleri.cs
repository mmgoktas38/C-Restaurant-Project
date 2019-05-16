﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; //

namespace lokanta
{
    class cPersonelHareketleri
    {
        cGenel gnl = new cGenel();
        #region Field
        private int _ID;
        private int _PersonelId;
        private string _Islem;
        private DateTime _Tarih;   // dışardan veriler gönderilecek veriler buraladaki değişkenlere gelecek
        private bool _Durum;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public string Islem { get => _Islem; set => _Islem = value; }
        public DateTime Tarih { get => _Tarih; set => _Tarih = value; }
        public bool Durum { get => _Durum; set => _Durum = value; }
        #endregion


        public bool PersonelActionSave(cPersonelHareketleri ph)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into personelhareketleri(PERSONELID,ISLEM,TARIH)Values(@personelId,@islem,@tarih)", con);
            try
            {
                if (con.State==ConnectionState.Closed) //eğer bağlantımız sql ile kapalı ise 
                {
                    con.Open();                     // bağlantıyı aç diyoruz.
                }
                cmd.Parameters.Add("@personelId", SqlDbType.Int).Value = ph._PersonelId;
                cmd.Parameters.Add("@islem", SqlDbType.VarChar).Value = ph._Islem;    //yukardai veriler buralara gelecek bunlarda sql verilerine gidecek
                cmd.Parameters.Add("@tarih", SqlDbType.DateTime).Value = ph._Tarih;
                result =Convert.ToBoolean(cmd.ExecuteNonQuery());  //yani bu bilgileri işleyebilirsin.


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;

        }

    }
}
