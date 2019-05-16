using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    public partial class frmMasalar : Form
    {
        public frmMasalar()
        {
            InitializeComponent();
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { Application.Exit(); }
        }

        private void btngeridon_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            this.Close();
            frm.Show();
        }

        private void btnmasa1_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa1.Text.Length;
            cGenel._ButtonValue = btnMasa1.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa1.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnmasa2_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa2.Text.Length;
            cGenel._ButtonValue = btnMasa2.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa2.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa3_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa3.Text.Length;
            cGenel._ButtonValue = btnMasa3.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa4_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa4.Text.Length;
            cGenel._ButtonValue = btnMasa4.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa5_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa5.Text.Length;
            cGenel._ButtonValue = btnMasa5.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa6_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa6.Text.Length;
            cGenel._ButtonValue = btnMasa6.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa7_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa7.Text.Length;
            cGenel._ButtonValue = btnMasa7.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa8_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa8.Text.Length;
            cGenel._ButtonValue = btnMasa8.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa8.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa9_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa9.Text.Length;
            cGenel._ButtonValue = btnMasa9.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa9.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnmasa10_Click(object sender, EventArgs e)
        {
            frmSiparis frm = new frmSiparis();
            int uzunluk = btnMasa10.Text.Length;
            cGenel._ButtonValue = btnMasa10.Text.Substring(uzunluk - 6, 6);
            cGenel._ButtonName = btnMasa10.Name;
            this.Close();
            frm.ShowDialog();
        }
        cGenel gnl = new cGenel();
        private void frmmasalar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,ID from masalar",con);
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if(item is Button)
                    {
                        if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")  //gelen masa1 ve durumu 1 ise işlemidir
                            // durum 1 boş demek
                             // durum 2 dolu demek
                        {
                          // bos masa resmi kısım
                  item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.bosmasa);  //burda hata alıyoz video 12
                        }
                        else if(item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                        {
                            cMasalar ms = new cMasalar();
                          //  DateTime dt1 = Convert.ToDateTime(ms.SessionSum(2,dr["ID"].ToString()));
                        //    DateTime dt2 = DateTime.Now;
                       //     string st1 = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();
                       //     string st2 = DateTime.Now.ToShortDateString();
                       //     DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                       //     DateTime t2= dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);
                       //     var fark = t2 - t1;

                      //       item.Text = string.Format("{0}{1}{2}",
                       //        fark.Days > 0 ? string.Format("{0} gün", fark.Days) : "",
                       //       fark.Hours > 0 ? string.Format("{0} Saat", fark.Hours) : "",
                       //          fark.Minutes > 0 ? string.Format("{0} Dakika", fark.Minutes) : "").Trim() + "\n\n\nMasa" + dr["ID"].ToString();
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolumasa);
                        //    item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolumasa);   // dolu resmi
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["durum"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.background);  //rezervasyon ama müşteri gelmiş anlamında
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["durum"].ToString() == "4")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.bankakasadurumu);  //rezervasyon 
                        }
                    }
                }
            }

        }
    }
}

