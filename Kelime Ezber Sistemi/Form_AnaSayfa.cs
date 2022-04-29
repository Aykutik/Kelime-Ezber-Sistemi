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
            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from "+kullanıcı+" " +
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

        public string kullanıcı = "kullanıcı1";

        private void Form_AnaSayfa_Load(object sender, EventArgs e)
        {           

            #region Seviye Kontrolleri
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from "+kullanıcı+" " +
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

            MySqlCommand komut_dk2 = new MySqlCommand("select COUNT(*) from "+kullanıcı+" " +
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
                    btn_Seviye2.Enabled = false;
                }
                else
                {
                    btn_Seviye2.Enabled = true;
                }
            }
            oku_dk2.Close();
            bağlantı.Close();

            MySqlCommand komut_dk3 = new MySqlCommand("select COUNT(*) from "+kullanıcı+" " +
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
                    btn_Seviye3.Enabled = false;
                }
                else
                {
                    btn_Seviye3.Enabled = true;
                }
            }
            oku_dk3.Close();
            bağlantı.Close();

            MySqlCommand komut_dk4 = new MySqlCommand("select COUNT(*) from "+kullanıcı+" " +
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
                    btn_Seviye4.Enabled = false;
                }
                else
                {
                    btn_Seviye4.Enabled = true;
                }
            }
            oku_dk4.Close();
            bağlantı.Close();

            MySqlCommand komut_dk5 = new MySqlCommand("select COUNT(*) from "+kullanıcı+" " +
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
                    btn_Seviye5.Enabled = false;
                }
                else
                {
                    btn_Seviye5.Enabled = true;
                }
            }
            oku_dk5.Close();
            bağlantı.Close();

            MySqlCommand komut_dk6 = new MySqlCommand("select COUNT(*) from "+kullanıcı+" " +
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
            MySqlCommand komut_a2 = new MySqlCommand("update "+kullanıcı+" " +
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
            MySqlCommand komut_a2 = new MySqlCommand("update "+kullanıcı+" " +
                                 "set seviye=@seviye, seviye_gösterim=@seviye_gösterim, doğru=@doğru where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye) + 1);
            komut_a2.Parameters.AddWithValue("@doğru", Convert.ToInt32(doğru) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(gösterim) + 1);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }
        private void yanlışCevap(string kelimeid, string yanlış)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update "+kullanıcı+" " +
                     "set seviye=@seviye,yanlış=@yanlış,seviye_gösterim=@seviye_gösterim where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeid);
            komut_a2.Parameters.AddWithValue("@yanlış", Convert.ToInt32(yanlış) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(yanlış) + 1);
            if (seviye != "1")
            {
                komut_a2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye)-1);
            }
            else
            {
                komut_a2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye));
            }
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }
        #endregion

        #region Ana Sayfa Butonlar
        private void btn_Kısım1_Click(object sender, EventArgs e)
        {
            btn_kalıcıHafıza.Visible = true;
            seviye = "1";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 1";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım2_Click(object sender, EventArgs e)
        {
            btn_kalıcıHafıza.Visible = true;
            seviye = "2";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 2";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım3_Click(object sender, EventArgs e)
        {
            btn_kalıcıHafıza.Visible = false;
            seviye = "3";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 3";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım4_Click(object sender, EventArgs e)
        {
            btn_kalıcıHafıza.Visible = false;
            seviye = "4";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 4";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım5_Click(object sender, EventArgs e)
        {
            btn_kalıcıHafıza.Visible = false;
            seviye = "5";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 5";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
            yeniSoru();
            hak = 0;
        }

        private void btn_kalıcıHafıza_Click(object sender, EventArgs e)
        {
            btn_kalıcıHafıza.Visible = false;
            seviye = "6";
            xt_ana.SelectedTabPage = xt_anaPage_kalıcıHafıza;
            lbl_seviye.Text = "Kalıcı Hafıza";
        }

        #endregion

        private void yeniSoru()
        {
            timer_soruArası.Stop();
            timer_yazmalıSoruArası.Stop();
            şık_1.Font = new Font(şık_1.Font.FontFamily, 7, FontStyle.Regular);
            şık_2.Font = new Font(şık_2.Font.FontFamily, 7, FontStyle.Regular);
            şık_3.Font = new Font(şık_2.Font.FontFamily, 7, FontStyle.Regular);
            şık_1.Appearance.BackColor = Color.White;
            şık_2.Appearance.BackColor = Color.White;
            şık_3.Appearance.BackColor = Color.White;
            btn_kelime.Appearance.BackColor = Color.White;
            şık_1.Enabled = true;
            şık_2.Enabled = true;
            şık_3.Enabled = true;
            çalışmaTemizle();
            rasgeleKelime();
            

            btn_kelime.Text = kelime;
            şık_1.Text = şık1;
            şık_2.Text = şık2;
            şık_3.Text = şık3;
            lbl_yanlış_s1.Text = yanlış;
            lbl_doğru_s1.Text = doğru;
            s1_btnFavori.EditValue = favori;
            s1_tür.Text = tür;

        }

        public string cevap = "";
        public string kelimeİd = "";
        public string seviye = "";
        public string gösterim = "";
        public string tür = "";
        public string alan = "";
        public string favori = "";
        public string doğru = "";
        public string yanlış = "";
        public string kelime = "";

        public string şık1 = "";
        public string şık2 = "";
        public string şık3 = "";

        List<string> şıklar = new List<string>();

        #region SEVİYE-1

        private void rasgeleKelime()
        {            
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            
            MySqlCommand komut = new MySqlCommand();
            string _tür = "";
            string _alan = "";
            if (ch_fiiller.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and _tür=@_tür ORDER BY RAND()";
                _tür = "fiil";
            }
            else if (ch_sıfatlar.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and _tür=@_tür ORDER BY RAND()";
                _tür = "sıfat";
            }
            else if (ch_isimler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and _tür=@_tür ORDER BY RAND()";
                _tür = "isim";
            }
            else if (ch_zamirler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and _tür=@_tür ORDER BY RAND()";
                _tür = "zamir";
            }
            else if (ch_edatlar.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and _tür=@_tür ORDER BY RAND()";
                _tür = "edat";
            }
            else if (ch_favoriler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and favori=1 ORDER BY RAND()";
            }
            else if (ch_yanlışlar.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" ORDER BY yanlış DESC, RAND()";
                //komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" ORDER BY yanlış ASC, RAND()";
            }
            else if (ch_duyguVeHisler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY RAND()";
                _alan = "duygu ve his";
            }
            else if (ch_gıda.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY RAND()";
                _alan = "gıda";
            }
            else if (ch_işHayatı.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY RAND()";
                _alan = "iş hayatı";
            }
            else if (ch_insanVucudu.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY RAND()";
                _alan = "insan ve sağlık";
            }
            else if (ch_kıyafet.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY RAND()";
                _alan = "Kılık Kıyafet";
            }
            else if (ch_c1.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY RAND()";
                _alan = "c1";
            }
            else if (ch_b1.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY RAND()";
                _alan = "b1";
            }
            else            
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" ORDER BY RAND() LIMIT 10";
            }
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@tür", _tür);
            komut.Parameters.AddWithValue("@alan", _alan);
            komut.Connection = bağlantı;
            komut.CommandType = CommandType.Text;
            MySqlDataReader dr;
            bağlantı.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {                                
                kelimeİd = dr["id"].ToString();
                gösterim = dr["seviye_gösterim"].ToString();
                tür = dr["tür"].ToString();
                alan = dr["alan"].ToString();
                favori = dr["favori"].ToString();
                doğru = dr["doğru"].ToString();
                yanlış = dr["yanlış"].ToString();

                if (Convert.ToInt32(seviye) < 4) //seviye 4 den küçükse engilizce sorup türkçe cevap isteyecek
                {
                    cevap = dr["TR"].ToString();
                    kelime = dr["EN"].ToString();
                }
                else
                {
                    cevap = dr["EN"].ToString();
                    kelime = dr["TR"].ToString();
                }
                
            }
            dr.Close();
            bağlantı.Close();

            if (kelime == "" | kelime == null)
            {
                yeniSoru();
            }

            şıkOluşturma();

            //lbl_toplamSayı_s1.Text = sayıKontrolleri(1);
            //lbl_toplamSayı_s2.Text = sayıKontrolleri(2);
        }

        private void seçmeliŞıkOluştur()
        {
            //Önce Doğru şıkkı listeye ekliyoruz
            şıklar.Clear();
            şıklar.Add(cevap);

            string komut = "";
            //sonra rasgele kelimeler getiriyoruz ama doğru şık haricinde

            if (alan != "" & alan != null)
            {
                //alan var ise alandan seç
                komut = "SELECT *from " + kullanıcı + " where alan=@alan ORDER BY RAND() LIMIT 5";
            }
            else
            {
                //alan yok ise tür var mı kontrol et
                if (tür != "" & tür != null)
                {
                    //tür varsa türden seç o zaman
                    komut = "SELECT *from " + kullanıcı + " where tür=@tür ORDER BY RAND() LIMIT 5";
                }
                else
                {
                    //tür de boş ise kafana göre takıl
                    komut = "SELECT *from " + kullanıcı + " ORDER BY RAND() LIMIT 5";
                }
            }

            //son iki şık
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_şıklar = new MySqlCommand(komut, bağlantı);
            komut_şıklar.Parameters.Clear();
            komut_şıklar.Parameters.AddWithValue("@tür", tür);
            komut_şıklar.Parameters.AddWithValue("@alan", alan);
            bağlantı.Open();
            MySqlDataReader dr_şıklar = komut_şıklar.ExecuteReader();
            while (dr_şıklar.Read() & şıklar.Count < 3)
            {
                string rasgele = dr_şıklar["TR"].ToString();
                if (rasgele != şıklar[0])
                {
                    if (şıklar.Count > 1)
                    {
                        if (rasgele != şıklar[1])
                        {
                            şıklar.Add(rasgele);
                        }
                    }
                    else
                    {
                        şıklar.Add(rasgele);
                    }
                }
            }
            bağlantı.Close();
            dr_şıklar.Close();

            try
            {
                Random rdn = new Random();
                int sayı = rdn.Next(0, 3);
                if (sayı == 0)
                {
                    şık1 = şıklar[0];
                    şık2 = şıklar[1];
                    şık3 = şıklar[2];
                }
                else
                {
                    şık1 = şıklar[sayı];
                    şıklar.RemoveAt(sayı);
                    int sayı2 = rdn.Next(0, 2);
                    şık2 = şıklar[sayı2];
                    şıklar.RemoveAt(sayı2);
                    şık3 = şıklar[0];
                }
            }
            catch (Exception)
            {

            }
        }
        
        private void şıkOluşturma()
        {
            if (Convert.ToInt32(seviye)<4 & Convert.ToInt32(seviye) > 0)
            {
                int sonSayı = 0;
                if (seviye == "1")
                {
                    sonSayı = 7;
                }
                if (seviye == "2")
                {
                    sonSayı = 4;
                }
                if (seviye == "3")
                {
                    sonSayı = 2;
                }
                Random rnd = new Random();
                int sayı = rnd.Next(1, 6);
                if (sayı == 5)
                {
                    xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
                    ts_seçmeliYazmalı.Enabled = false;
                    ts_seçmeliYazmalı.EditValue = "yazmalı";
                }
                else
                {
                    seçmeliŞıkOluştur();
                    xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
                    ts_seçmeliYazmalı.Visible = true;
                    ts_seçmeliYazmalı.Enabled = true;
                    ts_seçmeliYazmalı.EditValue = "seçmeli";
                }
                
            }
            else if (seviye == "5")
            {
                xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
                ts_seçmeliYazmalı.Visible = false;
            }
        }

        public string yanıt = "";
        

        #region CevapKontrol

        private void s1_şık_1_Click(object sender, EventArgs e)
        {
            if (yanıt=="yanlış")
            {
                yeniSoru();
                yanıt = "";
            }
            else
            {
                if (şık_1.Text == cevap)
                {
                    btn_kelime.Appearance.BackColor = Color.Green;
                    şık_1.Appearance.BackColor = Color.Green;

                    doğruCevap(seviye, kelimeİd, doğru);
                    timer_soruArası.Start();
                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafıza();
                        kalıcıHafızaTest = "";
                    }
                }
                else
                {
                    şık_1.Appearance.BackColor = Color.Red;
                    şık_1.Enabled = false;
                    if (şık_2.Text == cevap)
                    {
                        şık_3.Enabled = false;
                        şık_2.Appearance.BackColor = Color.DarkOrange;
                        btn_kelime.Appearance.BackColor = Color.DarkOrange;
                        şık_2.Font = new Font(şık_2.Font.FontFamily, 8, FontStyle.Bold);
                    }

                    if (şık_3.Text == cevap)
                    {
                        şık_2.Enabled = false;
                        şık_3.Appearance.BackColor = Color.DarkOrange;
                        btn_kelime.Appearance.BackColor = Color.DarkOrange;
                        şık_3.Font = new Font(şık_3.Font.FontFamily, 8, FontStyle.Bold);
                    }
                    yanlışCevap(kelimeİd, yanlış);
                    yanıt = "yanlış";
                }
            }            
        }        

        private void s1_şık_2_Click(object sender, EventArgs e)
        {
            if (yanıt == "yanlış")
            {
                yeniSoru();
                yanıt = "";
            }
            else
            {
                if (şık_2.Text == cevap)
                {

                    btn_kelime.Appearance.BackColor = Color.Green;
                    şık_2.Appearance.BackColor = Color.Green;

                    doğruCevap(seviye, kelimeİd, doğru);
                    
                    timer_soruArası.Start();
                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafıza();
                        kalıcıHafızaTest = "";
                    }
                }
                else
                {
                    şık_2.Appearance.BackColor = Color.Red;
                    şık_2.Enabled = false;
                    if (şık_1.Text == cevap)
                    {
                        şık_1.Appearance.BackColor = Color.DarkOrange;
                        şık_3.Enabled = false;
                        btn_kelime.Appearance.BackColor = Color.DarkOrange;
                        şık_1.Font = new Font(şık_1.Font.FontFamily, 8, FontStyle.Bold);
                    }

                    if (şık_3.Text == cevap)
                    {
                        şık_3.Appearance.BackColor = Color.DarkOrange;
                        şık_1.Enabled = false;
                        btn_kelime.Appearance.BackColor = Color.DarkOrange;
                        şık_3.Font = new Font(şık_3.Font.FontFamily, 8, FontStyle.Bold);
                    }

                    yanlışCevap(kelimeİd, yanlış);
                    yanıt = "yanlış";
                }
            }
        }

        private void s1_şık_3_Click(object sender, EventArgs e)
        {
            if (yanıt == "yanlış")
            {
                yeniSoru();
                yanıt = "";
            }
            else
            {
                if (şık_3.Text == cevap)
                {
                    şık_3.Appearance.BackColor = Color.Green;
                    btn_kelime.Appearance.BackColor = Color.Green;

                    doğruCevap(seviye, kelimeİd, doğru);
                    timer_soruArası.Start();
                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafıza();
                        kalıcıHafızaTest = "";
                    }
                }
                else
                {
                    şık_3.Appearance.BackColor = Color.Red;
                    şık_3.Enabled = false;
                    if (şık_1.Text == cevap)
                    {
                        şık_1.Appearance.BackColor = Color.DarkOrange;
                        btn_kelime.Appearance.BackColor = Color.DarkOrange;
                        şık_1.Font = new Font(şık_1.Font.FontFamily, 8, FontStyle.Bold);
                        şık_2.Enabled = false;
                    }

                    if (şık_2.Text == cevap)
                    {
                        şık_2.Appearance.BackColor = Color.DarkOrange;
                        btn_kelime.Appearance.BackColor = Color.DarkOrange;
                        şık_2.Font = new Font(şık_2.Font.FontFamily, 8, FontStyle.Bold);
                        şık_1.Enabled = false;                        
                    }

                    // Seviye 0 oldğu için bir alt seviyeye geçirmiyoruz
                    yanlışCevap(kelimeİd, yanlış);
                    yanıt = "yanlış";
                }
            }                        
        }

        int hak = 2;
        int tamEşleşmeVeyaİçerme = 0;
        int yazmalıYanlışYapıldı = 0;

        private void btn_yazmalı_ok_Click(object sender, EventArgs e)
        {
            
            string metin = cevap.ToLower();
            //string metin = "park etmek";
            string ara = txt_yazmalı_yanıt.Text.Trim().ToLower();
            tamEşleşmeVeyaİçerme = metin.ToLower().IndexOf(ara.ToLower());

            //virgüllü, virgül varsa boşluk da vardır. Tam eşleşme yapmamız lazım
            int virgül = metin.IndexOf(",");
            int boşluk = metin.IndexOf(" ");
            int ilkKelimeUzunluk = 0;
            int sonKelimeUzunluk = 0;
            int birdenfazlakelime = 0;
            if (virgül != -1 & boşluk != -1)
            {
                //hem virgül hem boşluk var
                ilkKelimeUzunluk = boşluk-1;
                sonKelimeUzunluk = (metin.Length-1)- virgül-1;
            }
            else if (virgül == -1 & boşluk != -1)
            {
                // Virgül yok ama birden fazla kelime
                birdenfazlakelime = 1;
            }

            if ((tamEşleşmeVeyaİçerme == -1 && metin != ara) | (txt_yazmalı_yanıt.Text.Length != ilkKelimeUzunluk & txt_yazmalı_yanıt.Text.Length != sonKelimeUzunluk) & (ilkKelimeUzunluk != 0 & sonKelimeUzunluk != 0))
            {
                //YANLIŞ
                yazmalıYanlışYapıldı = 1;
                if (hak > 0 & seviye != "5")
                {
                    //hak var ise ipucu göster
                    //ipucu göster

                    List<string> harfler = new List<string>();
                    //harfleri ayır
                    for (int i = 0; i < metin.Length; i++)
                    {
                        harfler.Add(metin.Substring(i, 1));
                    }

                    if (virgül == -1 && boşluk == -1)
                    {
                        //virgül veya boşluk yok
                        string ipiucu = metin.Substring(0, 1);
                        for (int i = 1; i < metin.Length; i++)
                        {
                            if (i == 2)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[2] + "";
                                
                            }
                            else if (i == metin.Length - 1)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                            }
                            else
                            {
                                if (i == 3 & seviye != "4")
                                {
                                    if (hak == 1 & yazmalıYanlışYapıldı == 1)
                                    {
                                        try
                                        {
                                            ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                                else
                                {
                                    ipiucu = "" + ipiucu + "" + "X";
                                }
                            }
                        }
                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                    }
                    else if (virgül != -1 && boşluk == -1)
                    {
                        // Virgül var boşluk yok
                        string ipiucu = metin.Substring(0, 1);
                        for (int i = 1; i < metin.Length; i++)
                        {
                            if (i == 2)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[2] + "";

                            }
                            else if (i == virgül + 1)
                            {
                                ipiucu = "" + ipiucu + ",";
                            }
                            else if (i == metin.Length - 1)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                            }
                            else
                            {
                                if (i == 3 & seviye != "4")
                                {
                                    if (hak == 1 & yazmalıYanlışYapıldı == 1)
                                    {
                                        try
                                        {
                                            ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                                else
                                {
                                    ipiucu = "" + ipiucu + "" + "X";
                                }
                            }
                        }
                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                    }
                    else if (virgül == -1 && boşluk != -1)
                    {
                        //Virgül yok Boşluk Var
                        string ipiucu = metin.ToUpper().Substring(0, 1).ToUpper();
                        for (int i = 1; i < metin.Length; i++)
                        {
                            if (i == 2)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[2] + "";

                            }
                            else if (i == boşluk)
                            {
                                ipiucu = "" + ipiucu + " ";
                            }
                            else if (i == boşluk + 1)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[boşluk + 1] + "";
                            }
                            else if (i == metin.Length - 1)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                            }
                            else
                            {
                                if (i== 3 & seviye != "4")
                                {
                                    if (hak == 1 & yazmalıYanlışYapıldı ==1)
                                    {
                                        try
                                        {
                                            ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                                else
                                {
                                    ipiucu = "" + ipiucu + "" + "X";
                                }                                
                            }
                        }
                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                    }
                    else if (virgül != -1 && boşluk != -1)
                    {
                        //Virgül yok Boşluk Var
                        string ipiucu = metin.Substring(0, 1);
                        for (int i = 1; i < metin.Length; i++)
                        {
                            if (i == 2)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[2] + "";

                            }                            
                            else if (i == boşluk)
                            {
                                ipiucu = "" + ipiucu + " ";
                            }
                            else if (i == virgül)
                            {
                                ipiucu = "" + ipiucu + ",";
                            }
                            else if (i == boşluk + 1)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[boşluk + 1] + "";
                            }
                            else if (i == metin.Length - 1)
                            {
                                ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                            }
                            else
                            {
                                if (i == 3 & seviye != "4")
                                {
                                    if (hak == 1 & yazmalıYanlışYapıldı ==1)
                                    {
                                        try
                                        {
                                            ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                                else
                                {
                                    ipiucu = "" + ipiucu + "" + "X";
                                }
                            }
                        }
                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                    }
                }
                else
                {
                    //hak kalmamış direk yanlış işlemler
                    lbl_ipucu.ForeColor = Color.Red;
                    lbl_ipucu.Visible = true;
                    lbl_ipucu.Text = cevap;

                    timer_yazmalıSoruArası.Start();
                    
                    yanlışCevap(kelimeİd, yanlış);
                    yanıt = "yanlış";                                        
                }

                if (hak > 0)
                {
                    hak--;
                    lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                }

                if (hak == 0)
                {
                    lbl_hak.Text = "İpucu Hakkınız Kalmadı. Doğru cevaplar vererek yükseltin.";
                }
                else
                {
                    lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                }                

                btn_kelime.Appearance.BackColor = Color.Red;
            }
            else
            {
                if ((birdenfazlakelime == 1 & metin == ara) | (tamEşleşmeVeyaİçerme == 0 && metin == ara) | ((tamEşleşmeVeyaİçerme > -1 & txt_yazmalı_yanıt.Text.Length == ilkKelimeUzunluk)| ((tamEşleşmeVeyaİçerme > -1 & txt_yazmalı_yanıt.Text.Length == sonKelimeUzunluk))))
                {
                    //DOĞRU
                    if (hak < 3)
                    {
                        hak++;
                        lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                    }
                    yazmalıYanlışYapıldı = 0;

                    btn_kelime.Appearance.BackColor = Color.Green;
                    timer_soruArası.Start();
                    çalışmaTemizle();
                    doğruCevap(seviye, kelimeİd, doğru);

                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafıza();
                        kalıcıHafızaTest = "";
                    }
                }
                else
                {
                    //YANLIŞ
                    if (hak != 0)
                    {
                        hak--;
                        lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                    }

                    btn_kelime.Appearance.BackColor = Color.Red;

                    if (hak > 0)
                    {
                        //hak var ise ipucu göster
                        //ipucu göster

                        List<string> harfler = new List<string>();
                        //harfleri ayır
                        for (int i = 0; i < metin.Length; i++)
                        {
                            harfler.Add(metin.Substring(i, 1));
                        }

                        if (virgül == -1 && boşluk == -1)
                        {
                            //virgül veya boşluk yok
                            string ipiucu = metin.Substring(0, 1);
                            for (int i = 1; i < metin.Length; i++)
                            {
                                if (i == 2)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[2] + "";
                                }
                                else if (i == metin.Length - 1)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                                }
                                else
                                {
                                    if (i == 3 & yazmalıYanlışYapıldı == 1 & seviye != "4")
                                    {
                                        if (hak == 1)
                                        {
                                            try
                                            {
                                                ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ipiucu = "" + ipiucu + "" + "X";
                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                            }
                            lbl_ipucu.Visible = true;
                            lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                        }
                        else if (virgül != -1 && boşluk == -1)
                        {
                            // Virgül var boşluk yok
                            string ipiucu = metin.Substring(0, 1);
                            for (int i = 1; i < metin.Length; i++)
                            {
                                if (i == 2)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[2] + "";
                                }
                                else if (i == virgül + 1)
                                {
                                    ipiucu = "" + ipiucu + ",";
                                }
                                else if (i == metin.Length - 1)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                                }
                                else
                                {
                                    if (i == 3 & yazmalıYanlışYapıldı == 1 & seviye != "4")
                                    {
                                        if (hak == 1)
                                        {
                                            try
                                            {
                                                ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ipiucu = "" + ipiucu + "" + "X";
                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                            }
                            lbl_ipucu.Visible = true;
                            lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                        }
                        else if (virgül == -1 && boşluk != -1)
                        {
                            //Virgül yok Boşluk Var
                            string ipiucu = metin.Substring(0, 1);
                            for (int i = 1; i < metin.Length; i++)
                            {
                                if (i == 2)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[2] + "";
                                }
                                else if (i == boşluk + 1)
                                {
                                    ipiucu = "" + ipiucu + " ";
                                }
                                else if (i == boşluk + 2)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[boşluk + 1] + "";
                                }
                                else if (i == metin.Length - 1)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                                }
                                else
                                {
                                    if (i == 3)
                                    {
                                        if (hak == 1 & yazmalıYanlışYapıldı == 1 & seviye != "4")
                                        {
                                            try
                                            {
                                                ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ipiucu = "" + ipiucu + "" + "X";
                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                            }
                            lbl_ipucu.Visible = true;
                            lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                        }
                        else if (virgül != -1 && boşluk != -1)
                        {
                            //Virgül de var boşluk da
                            string ipiucu = metin.Substring(0, 1);
                            for (int i = 1; i < metin.Length; i++)
                            {
                                if (i == 2)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[2] + ""; // cavabın 3.Harfi
                                }
                                else if (i == boşluk)
                                {
                                    ipiucu = "" + ipiucu + " ";
                                }
                                else if (i == virgül)
                                {
                                    ipiucu = "" + ipiucu + ",";
                                }
                                else if (i == boşluk + 1)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[boşluk + 1] + "";
                                }
                                else if (i == metin.Length - 1)
                                {
                                    ipiucu = "" + ipiucu + "" + harfler[metin.Length - 1] + "";
                                }
                                else
                                {
                                    if (i == 3 & yazmalıYanlışYapıldı == 1 & seviye != "4")
                                    {
                                        if (hak == 1)
                                        {
                                            try
                                            {
                                                ipiucu = "" + ipiucu + "" + harfler[3] + ""; // cavabın 4.Harfi
                                            }
                                            catch (Exception)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            ipiucu = "" + ipiucu + "" + "X";
                                        }
                                    }
                                    else
                                    {
                                        ipiucu = "" + ipiucu + "" + "X";
                                    }
                                }
                            }
                            lbl_ipucu.Visible = true;
                            lbl_ipucu.Text = "İpucu: " + ipiucu + "";
                        }

                    }
                    else
                    {
                        //hak kalmamış direk yanlış işlemler
                        lbl_ipucu.ForeColor = Color.Red;
                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = cevap;
                        timer_yazmalıSoruArası.Start();
                        yanlışCevap(kelimeİd, yanlış);
                        yanıt = "yanlış"; 
                    }
                }
            }
        }

        void çalışmaTemizle()
        {
            txt_yazmalı_yanıt.Text = "";
            lbl_ipucu.Text = "";
            lbl_ipucu.Visible = false;
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
            MySqlCommand komut_a2 = new MySqlCommand("update "+kullanıcı+" " +
                     "set favori=@favori where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeİd);
            komut_a2.Parameters.AddWithValue("@favori", s1_btnFavori.EditValue);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }

        public string kalıcıHafızaTest = "";
        private void simpleButton9_Click(object sender, EventArgs e)
        {
           
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bu kelime zaten ezberimde diyorsun yani?\nEğer doğru bilisen kalıcı hafızaya alınacak.\nOnaylıyor musun?", "KALICI HAFIZA", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                kalıcıHafızaTest = "1";
            }
            else
            {
                kalıcıHafızaTest = "";
            }
        }

        private void timer_soruArası_Tick(object sender, EventArgs e)
        {
            yeniSoru();
        }
        private void timer_yazmalıSoruArası_Tick(object sender, EventArgs e)
        {
            yeniSoru();
        }

        private void btn_kelimeEkle_Click_1(object sender, EventArgs e)
        {
            Form_KelimeEkle frm = new Form_KelimeEkle();
            frm.ShowDialog();
        }

        private void kalıcıHafıza()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update "+kullanıcı+" " +
                     "set seviye=@seviye where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeİd);
            komut_a2.Parameters.AddWithValue("@seviye", 6);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }

        private void ts_seçmeliYazmalı_Toggled(object sender, EventArgs e)
        {
            if (ts_seçmeliYazmalı.EditValue.ToString() == "yazmalı")
            {
                xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
            }
            else if (ts_seçmeliYazmalı.EditValue.ToString() == "seçmeli")
            {
                xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            }
        }

        
    }
}
