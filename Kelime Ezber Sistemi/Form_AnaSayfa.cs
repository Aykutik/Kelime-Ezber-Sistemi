using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kelime_Ezber_Sistemi
{
    public partial class Form_AnaSayfa : DevExpress.XtraEditors.XtraForm
    {
        public Form_AnaSayfa()
        {
            InitializeComponent();
        }

        Sqlbaglantisi blg = new Sqlbaglantisi();

        string sayıKontrolleri(int seviye)
        {
            string yazı = "";
            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", blg.bağlantı());
            komut_dk1.Parameters.Clear();
            komut_dk1.Parameters.AddWithValue("@seviye", seviye);
            komut_dk1.ExecuteNonQuery();
            MySqlDataReader oku_dk1 = komut_dk1.ExecuteReader();
            while (oku_dk1.Read())
            {
                yazı = "" + oku_dk1[0].ToString() + " kelime";
            }
            oku_dk1.Close();

            return yazı;
        }

        private void Form_AnaSayfa_Load(object sender, EventArgs e)
        {
            #region Seviye Kontrolleri

            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", blg.bağlantı());
            komut_dk1.Parameters.Clear();
            komut_dk1.Parameters.AddWithValue("@seviye", 1);
            komut_dk1.ExecuteNonQuery();
            MySqlDataReader oku_dk1 = komut_dk1.ExecuteReader();
            while (oku_dk1.Read())
            {
                lbl_sayı_S1.Text = "" + oku_dk1[0].ToString() + " kelime";
                lbl_toplamSayı_s1.Text = oku_dk1[0].ToString();
            }
            oku_dk1.Close();

            MySqlCommand komut_dk2 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", blg.bağlantı());
            komut_dk2.Parameters.Clear();
            komut_dk2.Parameters.AddWithValue("@seviye", 2);
            komut_dk2.ExecuteNonQuery();
            MySqlDataReader oku_dk2 = komut_dk2.ExecuteReader();
            while (oku_dk2.Read())
            {
                lbl_sayı_S2.Text = "" + oku_dk2[0].ToString() + " kelime / 20";
                if (Convert.ToInt32(oku_dk2[0].ToString()) < 20)
                {
                    XTC_AnaSayfa_Seviye2.PageVisible = false;
                    btn_Seviye2.Enabled = false;
                }
                else
                {
                    XTC_AnaSayfa_Seviye2.PageVisible = true;
                    btn_Seviye2.Enabled = false;
                }
            }
            oku_dk2.Close();

            MySqlCommand komut_dk3 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", blg.bağlantı());
            komut_dk3.Parameters.Clear();
            komut_dk3.Parameters.AddWithValue("@seviye", 3);
            komut_dk3.ExecuteNonQuery();
            MySqlDataReader oku_dk3 = komut_dk3.ExecuteReader();
            while (oku_dk3.Read())
            {
                lbl_sayı_S3.Text = "" + oku_dk3[0].ToString() + " kelime / 30";

                if (Convert.ToInt32(oku_dk3[0].ToString()) < 30)
                {
                    XTC_AnaSayfa_Seviye3.PageVisible = false;
                    btn_Seviye3.Enabled = false;
                }
                else
                {
                    XTC_AnaSayfa_Seviye3.PageVisible = true;
                    btn_Seviye3.Enabled = true;
                }
            }
            oku_dk3.Close();

            MySqlCommand komut_dk4 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", blg.bağlantı());
            komut_dk4.Parameters.Clear();
            komut_dk4.Parameters.AddWithValue("@seviye", 4);
            komut_dk4.ExecuteNonQuery();
            MySqlDataReader oku_dk4 = komut_dk4.ExecuteReader();
            while (oku_dk4.Read())
            {
                lbl_sayı_S4.Text = "" + oku_dk4[0].ToString() + " kelime / 40";
                if (Convert.ToInt32(oku_dk4[0].ToString()) < 40)
                {
                    XTC_AnaSayfa_Seviye4.PageVisible = false;
                    btn_Seviye4.Enabled = false;
                }
                else
                {
                    XTC_AnaSayfa_Seviye4.PageVisible = true;
                    btn_Seviye4.Enabled = true;
                }
            }
            oku_dk4.Close();

            MySqlCommand komut_dk5 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", blg.bağlantı());
            komut_dk5.Parameters.Clear();
            komut_dk5.Parameters.AddWithValue("@seviye", 5);
            komut_dk5.ExecuteNonQuery();
            MySqlDataReader oku_dk5 = komut_dk5.ExecuteReader();
            while (oku_dk5.Read())
            {
                lbl_sayı_S5.Text = "" + oku_dk5[0].ToString() + " kelime / 50";
                if (Convert.ToInt32(oku_dk5[0].ToString()) < 50)
                {
                    XTC_AnaSayfa_Seviye5.PageVisible = false;
                    btn_Seviye5.Enabled = false;
                }
                else
                {
                    XTC_AnaSayfa_Seviye5.PageVisible = true;
                    btn_Seviye5.Enabled = true;
                }
            }
            oku_dk5.Close();

            MySqlCommand komut_dk6 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", blg.bağlantı());
            komut_dk6.Parameters.Clear();
            komut_dk6.Parameters.AddWithValue("@seviye", 6);
            komut_dk6.ExecuteNonQuery();
            MySqlDataReader oku_dk6 = komut_dk6.ExecuteReader();
            while (oku_dk6.Read())
            {
                lbl_sayı_Kalıcı.Text = ""+ oku_dk6[0].ToString() + " kelime";
            }
            oku_dk6.Close();
            #endregion
        }

        private void yeniSoru()
        {

            timer_soruArası.Stop();

            if (xtraTabControl_AnaSayfa.SelectedTabPage == XTC_AnaSayfa_Seviye1)
            {
                s1_şık_1.Appearance.BackColor = Color.White;
                s1_şık_2.Appearance.BackColor = Color.White;
                s1_şık_3.Appearance.BackColor = Color.White;
                s1_kelime.Appearance.BackColor = Color.White;
                s1_şık_1.Enabled = true;
                s1_şık_2.Enabled = true;
                s1_şık_3.Enabled = true;
                s1_rasgeleKelime();
            }
        }

        #region SAYFA GEÇİŞLERİ
        private void xtraTabControl_AnaSayfa_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {            
            yeniSoru();
        }
        #endregion

        #region Voidler
        private void görünürlükArttır(string kelimeid, string gösterim)
        {
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set seviye_gösterim=@seviye_gösterim where id=@id", blg.bağlantı());
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(gösterim) + 1);
        }

        private void doğruCevap(string seviye, string kelimeid, string doğru)
        {
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                                 "set seviye=@seviye, doğru=@doğru where id=@id", blg.bağlantı());
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye) + 1);
            komut_a2.Parameters.AddWithValue("@doğru", Convert.ToInt32(doğru) + 1);
            komut_a2.ExecuteNonQuery();
        }
        private void yanlışCevapS1(string kelimeid, string yanlış)
        {
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set yanlış=@yanlış where id=@id", blg.bağlantı());
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@yanlış", Convert.ToInt32(yanlış) + 1);
            komut_a2.ExecuteNonQuery();
        }
        #endregion

        #region Ana Sayfa Butonlar
        private void btn_Kısım1_Click(object sender, EventArgs e)
        {
            xtraTabControl_AnaSayfa.SelectedTabPage = XTC_AnaSayfa_Seviye1;
        }

        private void btn_Kısım2_Click(object sender, EventArgs e)
        {
            xtraTabControl_AnaSayfa.SelectedTabPage = XTC_AnaSayfa_Seviye2;
        }

        private void btn_Kısım3_Click(object sender, EventArgs e)
        {
            xtraTabControl_AnaSayfa.SelectedTabPage = XTC_AnaSayfa_Seviye3;
        }

        private void btn_Kısım4_Click(object sender, EventArgs e)
        {
            xtraTabControl_AnaSayfa.SelectedTabPage = XTC_AnaSayfa_Seviye4;
        }

        private void btn_Kısım5_Click(object sender, EventArgs e)
        {
            xtraTabControl_AnaSayfa.SelectedTabPage = XTC_AnaSayfa_Seviye5;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            xtraTabControl_AnaSayfa.SelectedTabPage = XTC_AnaSayfa_KalıcıHafıza;
        }
        #endregion

        #region SEVİYE-1

        List<string> s1_şıklar = new List<string>();
        string s1_kelimeİd;
        string s1_seviye;
        string s1_seviye_gösterim;
        string s1_cevap;
        string s1_alan;
        private void s1_rasgeleKelime()
        {
            lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
            lbl_toplamSayı_s2.Text = sayıKontrolleri(2);

            MySqlCommand komut = new MySqlCommand();
            string tür = "";
            if (ch_fiiller.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and tür=@tür ORDER BY RAND()";
                tür = "fiil";
            }
            else if (ch_favoriler.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and favori=1 ORDER BY RAND()";
            }
            else if (ch_yanlışlar.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 ORDER BY yanlış DESc, RAND()";
            }
            else
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 ORDER BY RAND()";
            }
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@tür", tür);
            komut.Connection = blg.bağlantı();
            komut.CommandType = CommandType.Text;
            MySqlDataReader dr;
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                s1_cevap = dr["TR"].ToString();
                s1_kelimeİd = dr["id"].ToString();
                s1_seviye = dr["seviye"].ToString();
                s1_seviye_gösterim = dr["seviye_gösterim"].ToString();
                s1_tür.Text = dr["tür"].ToString();
                s1_alan = dr["alan"].ToString();
                s1_btnFavori.EditValue = dr["favori"].ToString();
                lbl_doğru_s1.Text = dr["doğru"].ToString();
                lbl_yanlış_s1.Text = dr["yanlış"].ToString();
                s1_kelime.Text = dr["EN"].ToString();
            }
            dr.Close();

            s1_şıkOluşturma();

            //Rasgele gelen kelimenin görünürlük puanını +1 yapıyoruz
            görünürlükArttır(s1_kelimeİd, s1_seviye_gösterim);

        }
                

        private void s1_şıkOluşturma()
        {
            //Önce Doğru şıkkı listeye ekliyoruz
            s1_şıklar.Clear();
            s1_şıklar.Add(s1_cevap);

            //sonra rasgele kelimeler getiriyoruz ama doğru şık haricinde
            MySqlCommand komut_şıklar = new MySqlCommand();
            
            if (s1_alan != "" & s1_alan != null)
            {
                //alan var ise alandan seç
                komut_şıklar.CommandText = "SELECT *FROM kullanıcı1 where alan=@alan ORDER BY RAND() LIMIT 10";
            }
            else
            {
                //alan yok ise tür var mı kontrol et
                if (s1_tür.Text != "" & s1_tür.Text != null)
                {
                    //tür varsa türden seç o zaman
                    komut_şıklar.CommandText = "SELECT *FROM kullanıcı1 where tür=@tür ORDER BY RAND() LIMIT 10";
                }
                else
                {
                    //tür de boş ise kafana göre takıl
                    komut_şıklar.CommandText = "SELECT *FROM kullanıcı1 ORDER BY RAND() LIMIT 10";
                }                                
            }

            komut_şıklar.Connection = blg.bağlantı();
            komut_şıklar.CommandType = CommandType.Text;
            komut_şıklar.Parameters.Clear();
            komut_şıklar.Parameters.AddWithValue("@tür", s1_tür.Text);
            komut_şıklar.Parameters.AddWithValue("@alan", s1_alan);

            MySqlDataReader dr_şıklar;
            dr_şıklar = komut_şıklar.ExecuteReader();
            for (int i = 0; i < 10; i++)
            {
                while (dr_şıklar.Read())
                {
                    string rasgele = dr_şıklar["TR"].ToString();

                    if (rasgele != s1_şıklar[0])
                    {
                        s1_şıklar.Add(rasgele);

                        if (s1_şıklar.Count == 2)
                        {
                            i = 17;
                        }
                    }
                }
            }

            try
            {
                Random rdn = new Random();
                int sayı = rdn.Next(0, 2);
                s1_şık_1.Text = s1_şıklar[sayı];
                s1_şıklar.RemoveAt(sayı);

                int sayı2 = rdn.Next(0, 1);
                s1_şık_2.Text = s1_şıklar[sayı2];
                s1_şıklar.RemoveAt(sayı2);

                s1_şık_3.Text = s1_şıklar[0];
            }
            catch (Exception)
            {

            }
            
        }
        #region CevapKontrol
        
        private void s1_şık_1_Click(object sender, EventArgs e)
        {
            s1_şık_2.Enabled = false;
            s1_şık_3.Enabled = false;
            if (s1_şık_1.Text == s1_cevap)
            {
                s1_şık_1.Appearance.BackColor = Color.Green;
                s1_kelime.Appearance.BackColor = Color.Green;

                doğruCevap(s1_seviye, s1_kelimeİd, lbl_doğru_s1.Text);
                lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
                lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
            }
            else
            {
                s1_şık_1.Appearance.BackColor = Color.Red;

                if (s1_şık_2.Text == s1_cevap)
                {
                    s1_şık_2.Appearance.BackColor = Color.DarkOliveGreen;
                }

                if (s1_şık_3.Text == s1_cevap)
                {
                    s1_şık_3.Appearance.BackColor = Color.DarkOliveGreen;
                }

                yanlışCevapS1(s1_kelimeİd, lbl_yanlış_s1.Text);
                lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
                lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
            }

            timer_soruArası.Start();
        }        

        private void s1_şık_2_Click(object sender, EventArgs e)
        {
            s1_şık_1.Enabled = false;
            s1_şık_3.Enabled = false;

            if (s1_şık_2.Text == s1_cevap)
            {
                s1_şık_2.Appearance.BackColor = Color.Green;
                s1_kelime.Appearance.BackColor = Color.Green;

                doğruCevap(s1_seviye,s1_kelimeİd,lbl_doğru_s1.Text);
                lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
                lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
            }
            else
            {
                s1_şık_2.Appearance.BackColor = Color.Red;

                if (s1_şık_1.Text == s1_cevap)
                {
                    s1_şık_1.Appearance.BackColor = Color.DarkOliveGreen;
                }

                if (s1_şık_3.Text == s1_cevap)
                {
                    s1_şık_3.Appearance.BackColor = Color.DarkOliveGreen;
                }

                yanlışCevapS1(s1_kelimeİd, lbl_yanlış_s1.Text);
                lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
                lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
            }
            timer_soruArası.Start();
        }

        private void s1_şık_3_Click(object sender, EventArgs e)
        {
            s1_şık_2.Enabled = false;
            s1_şık_1.Enabled = false;
            if (s1_şık_3.Text == s1_cevap)
            {
                s1_şık_3.Appearance.BackColor = Color.Green;
                s1_kelime.Appearance.BackColor = Color.Green;

                doğruCevap(s1_seviye, s1_kelimeİd, lbl_doğru_s1.Text);
                lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
                lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
            }
            else
            {
                s1_şık_3.Appearance.BackColor = Color.Red;                

                if (s1_şık_1.Text == s1_cevap)
                {
                    s1_şık_1.Appearance.BackColor = Color.DarkOliveGreen;
                }

                if (s1_şık_2.Text == s1_cevap)
                {
                    s1_şık_2.Appearance.BackColor = Color.DarkOliveGreen;
                }

                // Seviye 0 oldğu için bir alt seviyeye geçirmiyoruz
                yanlışCevapS1(s1_kelimeİd, lbl_yanlış_s1.Text);
                lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
                lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
            }
            timer_soruArası.Start();
        }


        #region Butonlar
        private void ch_fiiller_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
        }

        private void ch_favoriler_CheckedChanged(object sender, EventArgs e)
        {
            ch_fiiller.Checked = false;
            ch_yanlışlar.Checked = false;
        }

        private void ch_yanlışlar_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_fiiller.Checked = false;
        }
        #endregion

        #endregion

        #endregion

        private void s1_btnFavori_CheckedChanged(object sender, EventArgs e)
        {
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set favori=@favori where id=@id", blg.bağlantı());
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", s1_kelimeİd);
            komut_a2.Parameters.AddWithValue("@favori", s1_btnFavori.EditValue);
            komut_a2.ExecuteNonQuery();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bu kelime zaten ezberimde diyorsun yani?", "KALICI HAFIZA", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set seviye=@seviye where id=@id", blg.bağlantı());
                komut_a2.Parameters.Clear();
                komut_a2.Parameters.AddWithValue("@id", s1_kelimeİd);
                komut_a2.Parameters.AddWithValue("@seviye", 6);
                komut_a2.ExecuteNonQuery();
            }
        }

        private void timer_soruArası_Tick(object sender, EventArgs e)
        {
            yeniSoru();
        }

        private void btn_kelimeEkle_Click(object sender, EventArgs e)
        {
            Form_KelimeEkle frm = new Form_KelimeEkle();
            frm.ShowDialog();
        }

        
    }
}
