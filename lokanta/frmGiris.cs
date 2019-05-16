using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lokanta
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        } 

       
        private void frmgiris_Load(object sender, EventArgs e)
        {
            cPersoneller p = new cPersoneller();
            p.personelGetbyInformation(comboboxkullanici);
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            cGenel gnl = new cGenel();
            cPersoneller p = new cPersoneller();
            bool result = p.personelEntryControl(txtsifre.Text,cGenel._personelId);  //personelid ye bu şekilde ulaşabiliyoruz.

            if (result)
            {
                cPersonelHareketleri ch = new cPersonelHareketleri();
                ch.PersonelId = cGenel._personelId;
                ch.Islem = "Giriş Yaptı";
                ch.Tarih = DateTime.Now; // yani şimdinin zamanı ne zaman giriş yaparsa
                ch.PersonelActionSave(ch);

                this.Hide();
                frmMenu menu = new frmMenu();
                menu.Show();
            }

            else
            {
                MessageBox.Show("Şifreniz yanlış.","UYARI !!!",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

        }

        private void comboboxkullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            cPersoneller p = (cPersoneller)comboboxkullanici.SelectedItem;
            cGenel._personelId = p.PersonelId;
            cGenel._gorevId = p.PersonelGorevId;
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Uyarı!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { Application.Exit(); }
        }

        private void txtsifre_TextChanged(object sender, EventArgs e)
        {
            txtsifre.UseSystemPasswordChar = true;
        }
    }
}
