using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelime_Ezber_Sistemi
{
    public partial class Form_SorunBildir : DevExpress.XtraEditors.XtraForm
    {
        public Form_SorunBildir()
        {
            InitializeComponent();
        }

        public string bağlantıadresi = "server=loyaz.net;user id=u477970783_kelimeezber; database=u477970783_kelimeezber; Pwd=aykuT18092007; Charset = utf8";
        public string kullanıcı;
        public string kullanıcıİd;
        public string kelimeİd;
        public string kelime;
        public string cevap;

        private void Form_SorunBildir_Load(object sender, EventArgs e)
        {
            lbl_cevap.Text = cevap;
            lbl_kelime.Text = kelime;
            btn_gönder.Enabled = false;
        }

        private void rtb_sorun_TextChanged(object sender, EventArgs e)
        {
            if (rtb_sorun.Text.Length>5)
            {
                btn_gönder.Enabled = true;
            }
            else
            {
                btn_gönder.Enabled = false;
            }
        }

        private void btn_gönder_Click(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            //string tarih_format = "dd-MM-yyyy";
            string tarih_format = "DD.MM.YYYY";
            bugun.ToString(tarih_format);

            try
            {
                MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                MySqlCommand komut2 = new MySqlCommand("insert into sorun(sorunyazı,kelime,kelimeid,cevap,kullanıcı,kullanıcıid,tarih)" +
                    " values(@sorunyazı,@kelime,@kelimeid,@cevap,@kullanıcı,@kullanıcıid,@tarih)", bağlantı);
                komut2.Parameters.AddWithValue("@sorunyazı", rtb_sorun.Text);
                komut2.Parameters.AddWithValue("@kelime", kelime);
                komut2.Parameters.AddWithValue("@kelimeİd", kelimeİd);
                komut2.Parameters.AddWithValue("@cevap", cevap);
                komut2.Parameters.AddWithValue("@kullanıcı", kullanıcı);
                komut2.Parameters.AddWithValue("@kullanıcıid", kullanıcıİd);
                komut2.Parameters.AddWithValue("@tarih", bugun);
                bağlantı.Open();
                komut2.ExecuteNonQuery();
                bağlantı.Close();
                MessageBox.Show("Kelimenin sorunu iletildi. Teşekkürler!");
            }
            catch (Exception)
            {
                MessageBox.Show("Kelimenin sorunu hata nedeni ile ne yazık ki iletilemedi.\nLütfen tekrar deneyin.");
            }

            this.Close();

            var frm = (Form_AnaSayfa)Application.OpenForms["Form_AnaSayfa"];
            if (frm != null)
                frm.sorunBildirSonrası();
        }

        private void btn_vazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = (Form_AnaSayfa)Application.OpenForms["Form_AnaSayfa"];
            if (frm != null)
                frm.sorunBildirSonrası();
        }
    }
}