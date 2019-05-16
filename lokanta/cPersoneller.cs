﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms; //personelGetbyInformation bu fonksiyonda comboboxun çıkmasını sağlıyor.

namespace lokanta
{
    class cPersoneller
    {
        cGenel gnl = new cGenel();
        #region Fields
        private int _PersonelId;
        private int _PersonelGorevId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;
        #endregion

        #region Properties
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int PersonelGorevId { get => _PersonelGorevId; set => _PersonelGorevId = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; } 
        #endregion


        public bool personelEntryControl(string password,int UserId)
        {
            bool result = false; // result false cunku herhangi bir işlem yanlış giderse false donecek

            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("Select * From personeller where ID=@Id and PAROLA = @password", con); //gelen id ve password değerini kontrol ettik var mı diye
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            try
            {
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());    //eger sonuclar true donerse buraya geliyor

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }


            return result;
        }

        public void personelGetbyInformation(ComboBox cb)
        
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("Select * From personeller", con); //gelen id ve password değerini kontrol ettik var mı diye
           
         
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cPersoneller p = new cPersoneller();
                p._PersonelId = Convert.ToInt32(dr["ID"]);
                p._PersonelGorevId = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola= Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
            // p._PersonelDurum=Convert.ToBoolean(dr["durum"]);     burda hata alıyoz!!!!!!!!!!!!!!!!
                cb.Items.Add(p); 

            }
            dr.Close(); //okumayı kapattık
            con.Close(); //bağlantıyı kapattık
            

        }

        public override string ToString()
        {
            return PersonelAd + " " + PersonelSoyad;
        }

        public void personelBilgileriniGetirLV(ListView lv)
               
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("Select Personeller.* , personelGorevleri.GOREV From Personeller Inner Join PersonelGorevleri on PersonelGorevleri.ID=Personeller.GOREVID where Personeller.Durum=0", con); //gelen id ve password değerini kontrol ettik var mı diye


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;


            }
            dr.Close(); //okumayı kapattık
            con.Close(); //bağlantıyı kapattık


        }


        public void personelBilgileriniGetirfromIDLV(ListView lv,int perID)

           

        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("Select Personeller.* , personelGorevleri.GOREV From Personeller Inner Join PersonelGorevleri on PersonelGorevleri.ID=Personeller.GOREVID where Personeller.Durum=0 and Personeller.ID=@perId", con); //gelen id ve password değerini kontrol ettik var mı diye
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;


            }
            dr.Close(); //okumayı kapattık
            con.Close(); //bağlantıyı kapattık


        }

        public string personelBilgiGetirIsim(int perId)
        {

            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("Select AD From personeller where Personeller.Durum=0 and Personeller.ID=@perId", con); //gelen id ve password değerini kontrol ettik var mı diye
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;

            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                sonuc =Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
           
      
            con.Close(); //bağlantıyı kapattık
            return sonuc;

        }

        public bool personelSifreDegistir(int personelID ,string pass)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("update personeller set PAROLA=@pass where ID=@perId", con); //gelen id ve password değerini kontrol ettik var mı diye
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = personelID;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }


            con.Close(); //bağlantıyı kapattık





            return sonuc;
        }

        public bool personelEkle(cPersoneller cp)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("Insert into Personeller(AD,SOYAD,PAROLA,GOREVID) values (@AD,@SOYAD,@PAROLA,@GOREVID)", con); //gelen id ve password değerini kontrol ettik var mı diye
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
           
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
           

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }


            con.Close(); //bağlantıyı kapattık

           
            return sonuc;
        }

        public bool personelGuncelle(cPersoneller cp, int perID)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("Update personeller set AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA,GOREVID=@GOREVID where ID=@perID", con); //gelen id ve password değerini kontrol ettik var mı diye
            cmd.Parameters.Add("perID", SqlDbType.VarChar).Value = perID;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }


            con.Close(); //bağlantıyı kapattık


            return sonuc;
        }

        public bool personelSil( int perID)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString); //connection ile veri tabanına bağlandık
            SqlCommand cmd = new SqlCommand("update personeller set Durum=1 where ID=@perID", con); //gelen id ve password değerini kontrol ettik var mı diye
            cmd.Parameters.Add("perID", SqlDbType.VarChar).Value = perID;
          //  cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
          //  cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
          //  cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
         //   cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
           

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {

                throw;
            }


            con.Close(); //bağlantıyı kapattık


            return sonuc;
        }
    }
}
