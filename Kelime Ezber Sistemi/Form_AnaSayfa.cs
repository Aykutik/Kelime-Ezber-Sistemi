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

        //public string bağlantıadresi = "server=eu-cdbr-west-02.cleardb.net;user id=bdbb59f8e5a999; database=heroku_35277f60d273b6a; Pwd=9e92108f; Charset = utf8";
        public string bağlantıadresi = "server=loyaz.net;user id=u477970783_kelimeezber; database=u477970783_kelimeezber; Pwd=aykuT18092007; Charset = utf8";

        string sayıKontrolleri(int seviye)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            string yazı = "";
            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", bağlantı);
            komut_dk1.Parameters.Clear();
            komut_dk1.Parameters.AddWithValue("@seviye", seviye);
            bağlantı.Open();
            komut_dk1.ExecuteNonQuery();
            MySqlDataReader oku_dk1 = komut_dk1.ExecuteReader();
            while (oku_dk1.Read())
            {
                yazı = "" + oku_dk1[0].ToString() + " kelime";
            }
            oku_dk1.Close();
            bağlantı.Close();

            return yazı;
        }        

        private void Form_AnaSayfa_Load(object sender, EventArgs e)
        {
            #region Seviye Kontrolleri
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", bağlantı);
            komut_dk1.Parameters.Clear();
            komut_dk1.Parameters.AddWithValue("@seviye", 1);
            bağlantı.Open();
            komut_dk1.ExecuteNonQuery();
            MySqlDataReader oku_dk1 = komut_dk1.ExecuteReader();
            while (oku_dk1.Read())
            {
                lbl_sayı_S1.Text = "" + oku_dk1[0].ToString() + " kelime";
            }
            oku_dk1.Close();
            bağlantı.Close();

            MySqlCommand komut_dk2 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                                    "where seviye=@seviye", bağlantı);
            komut_dk2.Parameters.Clear();
            komut_dk2.Parameters.AddWithValue("@seviye", 2);
            bağlantı.Open();
            komut_dk2.ExecuteNonQuery();
            MySqlDataReader oku_dk2 = komut_dk2.ExecuteReader();
            while (oku_dk2.Read())
            {
                lbl_sayı_S2.Text = "" + oku_dk2[0].ToString() + " kelime / 30";
                if (Convert.ToInt32(oku_dk2[0].ToString()) < 30)
                {
                    XTC_AnaSayfa_Seviye2.PageVisible = false;
                    btn_Seviye2.Enabled = false;
                }
                else
                {
                    XTC_AnaSayfa_Seviye2.PageVisible = true;
                    btn_Seviye2.Enabled = true;
                }
            }
            oku_dk2.Close();
            bağlantı.Close();

            MySqlCommand komut_dk3 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", bağlantı);
            komut_dk3.Parameters.Clear();
            komut_dk3.Parameters.AddWithValue("@seviye", 3);
            bağlantı.Open();
            komut_dk3.ExecuteNonQuery();
            MySqlDataReader oku_dk3 = komut_dk3.ExecuteReader();
            while (oku_dk3.Read())
            {
                lbl_sayı_S3.Text = "" + oku_dk3[0].ToString() + " kelime / 40";

                if (Convert.ToInt32(oku_dk3[0].ToString()) < 40)
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
            bağlantı.Close();

            MySqlCommand komut_dk4 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", bağlantı);
            komut_dk4.Parameters.Clear();
            komut_dk4.Parameters.AddWithValue("@seviye", 4);
            bağlantı.Open();
            komut_dk4.ExecuteNonQuery();
            MySqlDataReader oku_dk4 = komut_dk4.ExecuteReader();
            while (oku_dk4.Read())
            {
                lbl_sayı_S4.Text = "" + oku_dk4[0].ToString() + " kelime / 50";
                if (Convert.ToInt32(oku_dk4[0].ToString()) < 50)
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
            bağlantı.Close();

            MySqlCommand komut_dk5 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", bağlantı);
            komut_dk5.Parameters.Clear();
            komut_dk5.Parameters.AddWithValue("@seviye", 5);
            bağlantı.Open();
            komut_dk5.ExecuteNonQuery();
            MySqlDataReader oku_dk5 = komut_dk5.ExecuteReader();
            while (oku_dk5.Read())
            {
                lbl_sayı_S5.Text = "" + oku_dk5[0].ToString() + " kelime / 70";
                if (Convert.ToInt32(oku_dk5[0].ToString()) < 70)
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
            bağlantı.Close();

            MySqlCommand komut_dk6 = new MySqlCommand("select COUNT(*) from kullanıcı1 " +
                            "where seviye=@seviye", bağlantı);
            komut_dk6.Parameters.Clear();
            komut_dk6.Parameters.AddWithValue("@seviye", 6);
            bağlantı.Open();
            komut_dk6.ExecuteNonQuery();
            MySqlDataReader oku_dk6 = komut_dk6.ExecuteReader();
            while (oku_dk6.Read())
            {
                lbl_sayı_Kalıcı.Text = ""+ oku_dk6[0].ToString() + " kelime";
            }
            oku_dk6.Close();
            bağlantı.Close();
            #endregion
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
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set seviye_gösterim=@seviye_gösterim where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(gösterim) + 1);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }

        private void doğruCevap(string seviye, string kelimeid, string doğru)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                                 "set seviye=@seviye, seviye_gösterim=@seviye_gösterim, doğru=@doğru where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye) + 1);
            komut_a2.Parameters.AddWithValue("@doğru", Convert.ToInt32(doğru) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(s1_seviye_gösterim) + 1);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }
        private void yanlışCevapS1(string kelimeid, string yanlış)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set yanlış=@yanlış,seviye_gösterim=@seviye_gösterim where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@yanlış", Convert.ToInt32(yanlış) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(yanlış) + 1);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
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

        private void yeniSoru()
        {
            timer_soruArası.Stop();            

            if (xtraTabControl_AnaSayfa.SelectedTabPage == XTC_AnaSayfa_Seviye1)
            {
                s1_şık_1.Font = new Font(s1_şık_1.Font.FontFamily, 7, FontStyle.Regular);
                s1_şık_2.Font = new Font(s1_şık_2.Font.FontFamily, 7, FontStyle.Regular);
                s1_şık_3.Font = new Font(s1_şık_2.Font.FontFamily, 7, FontStyle.Regular);
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

        #region SEVİYE-1

        List<string> s1_şıklar = new List<string>();
        string s1_kelimeİd;
        string s1_seviye;
        string s1_seviye_gösterim;
        string s1_cevap;
        string s1_alan;
        private void s1_rasgeleKelime()
        {            
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            
            MySqlCommand komut = new MySqlCommand();
            string tür = "";
            string alan = "";
            if (ch_fiiller.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and tür=@tür ORDER BY RAND()";
                tür = "fiil";
            }
            else if (ch_sıfatlar.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and tür=@tür ORDER BY RAND()";
                tür = "sıfat";
            }
            else if (ch_isimler.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and tür=@tür ORDER BY RAND()";
                tür = "isim";
            }
            else if (ch_zamirler.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and tür=@tür ORDER BY RAND()";
                tür = "zamir";
            }
            else if (ch_edatlar.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and tür=@tür ORDER BY RAND()";
                tür = "edat";
            }
            else if (ch_favoriler.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and favori=1 ORDER BY RAND()";
            }
            else if (ch_yanlışlar.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 ORDER BY yanlış DESC, RAND()";
                //komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 ORDER BY yanlış ASC, RAND()";
            }
            else if (ch_duyguVeHisler.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and alan=@alan ORDER BY RAND()";
                alan = "duygu ve his";
            }
            else if (ch_gıda.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and alan=@alan ORDER BY RAND()";
                alan = "gıda";
            }
            else if (ch_işHayatı.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and alan=@alan ORDER BY RAND()";
                alan = "iş hayatı";
            }
            else if (ch_insanVucudu.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and alan=@alan ORDER BY RAND()";
                alan = "insan ve sağlık";
            }
            else if (ch_kıyafet.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and alan=@alan ORDER BY RAND()";
                alan = "Kılık Kıyafet";
            }
            else if (ch_c1.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and alan=@alan ORDER BY RAND()";
                alan = "c1";
            }
            else if (ch_b1.Checked == true)
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 and alan=@alan ORDER BY RAND()";
                alan = "b1";
            }
            else            
            {
                komut.CommandText = "SELECT *FROM kullanıcı1 where seviye=1 ORDER BY RAND() LIMIT 10";
            }
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@tür", tür);
            komut.Parameters.AddWithValue("@alan", alan);
            komut.Connection = bağlantı;
            komut.CommandType = CommandType.Text;
            MySqlDataReader dr;
            bağlantı.Open();
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
            bağlantı.Close();

            s1_şıkOluşturma();
            //lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
            //lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
        }
                

        private void s1_şıkOluşturma()
        {
            //Önce Doğru şıkkı listeye ekliyoruz
            s1_şıklar.Clear();
            s1_şıklar.Add(s1_cevap);

            string komut = "";
            //sonra rasgele kelimeler getiriyoruz ama doğru şık haricinde
            
            if (s1_alan != "" & s1_alan != null)
            {
                //alan var ise alandan seç
                komut = "SELECT *FROM kullanıcı1 where alan=@alan ORDER BY RAND() LIMIT 10";
            }
            else
            {
                //alan yok ise tür var mı kontrol et
                if (s1_tür.Text != "" & s1_tür.Text != null)
                {
                    //tür varsa türden seç o zaman
                    komut = "SELECT *FROM kullanıcı1 where tür=@tür ORDER BY RAND() LIMIT 10";
                }
                else
                {
                    //tür de boş ise kafana göre takıl
                    komut = "SELECT *FROM kullanıcı1 ORDER BY RAND() LIMIT 6";
                }                                
            }

            //son iki şık
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_şıklar = new MySqlCommand(komut, bağlantı);
            komut_şıklar.Parameters.Clear();
            komut_şıklar.Parameters.AddWithValue("@tür", s1_tür.Text);
            komut_şıklar.Parameters.AddWithValue("@alan", s1_alan);
            bağlantı.Open();
            MySqlDataReader dr_şıklar = komut_şıklar.ExecuteReader();
            while (dr_şıklar.Read() & s1_şıklar.Count < 3)
            {
               string rasgele = dr_şıklar["TR"].ToString();
               if (rasgele != s1_şıklar[0])
               {
                    if (s1_şıklar.Count > 1)
                    {
                        if (rasgele != s1_şıklar[1])
                        {
                            s1_şıklar.Add(rasgele);
                        }
                    }
                    else
                    {
                        s1_şıklar.Add(rasgele);
                    }
               }
            }

            try
            {
                Random rdn = new Random();
                int sayı = rdn.Next(0, 3);
                if (sayı == 0)
                {
                    s1_şık_1.Text = s1_şıklar[0];
                    s1_şık_2.Text = s1_şıklar[1];
                    s1_şık_3.Text = s1_şıklar[2];
                }
                else
                {
                    s1_şık_1.Text = s1_şıklar[sayı];
                    s1_şıklar.RemoveAt(sayı);
                    int sayı2 = rdn.Next(0, 2);
                    s1_şık_2.Text = s1_şıklar[sayı2];
                    s1_şıklar.RemoveAt(sayı2);
                    s1_şık_3.Text = s1_şıklar[0];
                }            
            }
            catch (Exception)
            {

            }
            bağlantı.Close();

        }
        public string cevap = "";

        #region CevapKontrol
        
        private void s1_şık_1_Click(object sender, EventArgs e)
        {
            if (cevap=="yanlış")
            {
                yeniSoru();
                cevap = "";
            }
            else
            {
                if (s1_şık_1.Text == s1_cevap)
                {
                    s1_kelime.Appearance.BackColor = Color.Green;
                    s1_şık_1.Appearance.BackColor = Color.Green;

                    doğruCevap(s1_seviye, s1_kelimeİd, lbl_doğru_s1.Text);
                    timer_soruArası.Start();
                }
                else
                {
                    s1_şık_1.Appearance.BackColor = Color.Red;
                    s1_şık_1.Enabled = false;
                    if (s1_şık_2.Text == s1_cevap)
                    {
                        s1_şık_3.Enabled = false;
                        s1_şık_2.Appearance.BackColor = Color.DarkOrange;
                        s1_kelime.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_2.Font = new Font(s1_şık_2.Font.FontFamily, 8, FontStyle.Bold);
                    }

                    if (s1_şık_3.Text == s1_cevap)
                    {
                        s1_şık_2.Enabled = false;
                        s1_şık_3.Appearance.BackColor = Color.DarkOrange;
                        s1_kelime.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_3.Font = new Font(s1_şık_3.Font.FontFamily, 8, FontStyle.Bold);
                    }
                    yanlışCevapS1(s1_kelimeİd, lbl_yanlış_s1.Text);
                    cevap = "yanlış";
                }
            }            
        }        

        private void s1_şık_2_Click(object sender, EventArgs e)
        {
            if (cevap=="yanlış")
            {
                yeniSoru();
                cevap = "";
            }
            else
            {
                if (s1_şık_2.Text == s1_cevap)
                {

                    s1_kelime.Appearance.BackColor = Color.Green;
                    s1_şık_2.Appearance.BackColor = Color.Green;

                    doğruCevap(s1_seviye, s1_kelimeİd, lbl_doğru_s1.Text);
                    timer_soruArası.Start();
                }
                else
                {
                    s1_şık_2.Appearance.BackColor = Color.Red;
                    s1_şık_2.Enabled = false;
                    if (s1_şık_1.Text == s1_cevap)
                    {
                        s1_şık_1.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_3.Enabled = false;
                        s1_kelime.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_1.Font = new Font(s1_şık_1.Font.FontFamily, 8, FontStyle.Bold);
                    }

                    if (s1_şık_3.Text == s1_cevap)
                    {
                        s1_şık_3.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_1.Enabled = false;
                        s1_kelime.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_3.Font = new Font(s1_şık_3.Font.FontFamily, 8, FontStyle.Bold);
                    }

                    yanlışCevapS1(s1_kelimeİd, lbl_yanlış_s1.Text);
                    cevap = "yanlış";
                }
            }
        }

        private void s1_şık_3_Click(object sender, EventArgs e)
        {
            if (cevap == "yanlış")
            {
                yeniSoru();
                cevap = "";
            }
            else
            {
                if (s1_şık_3.Text == s1_cevap)
                {
                    s1_şık_3.Appearance.BackColor = Color.Green;
                    s1_kelime.Appearance.BackColor = Color.Green;

                    doğruCevap(s1_seviye, s1_kelimeİd, lbl_doğru_s1.Text);
                    timer_soruArası.Start();
                }
                else
                {
                    s1_şık_3.Appearance.BackColor = Color.Red;
                    s1_şık_3.Enabled = false;
                    if (s1_şık_1.Text == s1_cevap)
                    {
                        s1_şık_1.Appearance.BackColor = Color.DarkOrange;
                        s1_kelime.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_1.Font = new Font(s1_şık_1.Font.FontFamily, 8, FontStyle.Bold);
                        s1_şık_2.Enabled = false;
                    }

                    if (s1_şık_2.Text == s1_cevap)
                    {
                        s1_şık_2.Appearance.BackColor = Color.DarkOrange;
                        s1_kelime.Appearance.BackColor = Color.DarkOrange;
                        s1_şık_2.Font = new Font(s1_şık_2.Font.FontFamily, 8, FontStyle.Bold);
                        s1_şık_1.Enabled = false;                        
                    }

                    // Seviye 0 oldğu için bir alt seviyeye geçirmiyoruz
                    yanlışCevapS1(s1_kelimeİd, lbl_yanlış_s1.Text);
                    cevap = "yanlış";
                }
            }                        
        }


        #region Butonlar
        private void ch_fiiller_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_favoriler_CheckedChanged(object sender, EventArgs e)
        {
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_yanlışlar_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_isimler_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_edatlar_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_gıda_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_işHayatı_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_duyguVeHisler_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_insanVucudu.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_insanVucudu_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }
        private void ch_kıyafet_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_b1.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_b1_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_fiiller.Checked = false;
            ch_c1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_c1_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_fiiller.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_sıfatlar.Checked = false;
            ch_zamirler.Checked = false;
        }

        private void ch_zamirler_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_fiiller.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_c1.Checked = false;
            ch_sıfatlar.Checked = false;
        }
        private void ch_sıfatlar_CheckedChanged(object sender, EventArgs e)
        {
            ch_favoriler.Checked = false;
            ch_yanlışlar.Checked = false;
            ch_isimler.Checked = false;
            ch_edatlar.Checked = false;
            ch_gıda.Checked = false;
            ch_işHayatı.Checked = false;
            ch_duyguVeHisler.Checked = false;
            ch_fiiller.Checked = false;
            ch_b1.Checked = false;
            ch_kıyafet.Checked = false;
            ch_c1.Checked = false;
            ch_zamirler.Checked = false;
        }
        #endregion

        #endregion

        #endregion

        private void s1_btnFavori_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set favori=@favori where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", s1_kelimeİd);
            komut_a2.Parameters.AddWithValue("@favori", s1_btnFavori.EditValue);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bu kelime zaten ezberimde diyorsun yani?", "KALICI HAFIZA", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                MySqlCommand komut_a2 = new MySqlCommand("update kullanıcı1 " +
                     "set seviye=@seviye where id=@id", bağlantı);
                komut_a2.Parameters.Clear();
                komut_a2.Parameters.AddWithValue("@id", s1_kelimeİd);
                komut_a2.Parameters.AddWithValue("@seviye", 6);
                bağlantı.Open();
                komut_a2.ExecuteNonQuery();
                bağlantı.Close();
            }
        }

        private void timer_soruArası_Tick(object sender, EventArgs e)
        {
            yeniSoru();
        }

        private void btn_kelimeEkle_Click_1(object sender, EventArgs e)
        {
            Form_KelimeEkle frm = new Form_KelimeEkle();
            frm.ShowDialog();
        }

        
    }
}
