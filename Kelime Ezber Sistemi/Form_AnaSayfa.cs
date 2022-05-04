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

        public DateTime bugün = DateTime.Today;

        private void tarih()
        {
            DateTime tarih = DateTime.Today;
            string tarih_format = "DD.MM.YYYY";
            tarih.ToString(tarih_format);
            bugün = tarih;
        }

        public string kullanıcı = "aykutik";
        public string kullanıcılarİstatistik = "";
        public string kullanıcıİd = "";
        public string kullanıcıPuan = "";
        public string kullanıcıRütbe = "";
        public string kalıcıHafıza = "";
        public int kullanıcıTopDoğru = 0;

        List<string> kullanıcılar = new List<string>();
        List<string> kullanıcılar_rütbe = new List<string>();
        List<string> kullanıcılar_kalıcıhafıza = new List<string>();
        List<string> kullanıcılar_doğru = new List<string>();
        List<string> kullanıcılar_yanlış = new List<string>();
        private void kullancıBilgileri()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);

            //string _kalıcıHafıza = "";
            ////kalıcıhafıza ya alıyoruz
            //MySqlCommand komut_a2 = new MySqlCommand("update " + kullanıcı + " " +
            //         "set seviye=@seviye", bağlantı);
            //komut_a2.Parameters.Clear();
            //komut_a2.Parameters.AddWithValue("@seviye", 1);
            //bağlantı.Open();
            //komut_a2.ExecuteNonQuery();
            //bağlantı.Close();

            MySqlCommand komut = new MySqlCommand();

            komut.CommandText = "SELECT *from kullanıcılar ORDER BY kalıcıhafıza DESC";
            komut.Connection = bağlantı;
            komut.CommandType = CommandType.Text;
            MySqlDataReader dr;
            bağlantı.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kullanıcılar.Add(dr["kullanıcıadı"].ToString());
            }
            dr.Close();
            bağlantı.Close();

            for (int i = 0; i < kullanıcılar.Count; i++)
            {
                MySqlCommand komut2 = new MySqlCommand();
                komut2.CommandText = "SELECT *FROM kullanıcılar where kullanıcıadı=@kullanıcıadı";
                komut2.Connection = bağlantı;
                komut2.CommandType = CommandType.Text;
                komut2.Parameters.Clear();
                komut2.Parameters.AddWithValue("@kullanıcıadı", kullanıcılar[i]);
                MySqlDataReader dr2;
                bağlantı.Open();
                dr2 = komut2.ExecuteReader();
                if (dr2.Read())
                {
                    kullanıcılar_kalıcıhafıza.Add(dr2["kalıcıhafıza"].ToString());
                    //oturum açan kullanıcı ise doğrularını hafızaya al.
                    if (kullanıcı == kullanıcılar[i])
                    {
                        kullanıcıTopDoğru = Convert.ToInt32(dr2["doğru"].ToString());
                    }
                }
                dr2.Close();
                bağlantı.Close();
            }

            for (int i = 0; i < kullanıcılar.Count; i++)
            {
                MySqlCommand komut3 = new MySqlCommand();
                komut3.CommandText = "SELECT sum(doğru) FROM " + kullanıcılar[i] + "";
                komut3.Connection = bağlantı;
                komut3.CommandType = CommandType.Text;
                MySqlDataReader dr3;
                bağlantı.Open();
                dr3 = komut3.ExecuteReader();
                if (dr3.Read())
                {
                    kullanıcılar_doğru.Add(dr3[0].ToString());
                }
                dr3.Close();
                bağlantı.Close();
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, "sıra", i + 1);
            }
        }

        #region PARAMETRELER
        public int minSeviye2 = 60;
        public int minSeviye3 = 120;
        public int minSeviye4 = 240;
        public int minSeviye5 = 500;
        #endregion

        private void Form_AnaSayfa_Load(object sender, EventArgs e)
        {
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from kullanıcılar ORDER BY kalıcıhafıza DESC, doğru DESC", bağlantıadresi);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            ds.Dispose();

            //DataTable dt = new DataTable();
            //dt.Columns.Add("sıra", Type.GetType("System.String"));
            //dt.Columns.Add("kullanıcıadı", Type.GetType("System.String"));
            //dt.Columns.Add("kalıcıhafıza", Type.GetType("System.String"));
            //dt.Columns.Add("doğru", Type.GetType("System.String"));
            //gridControl1.DataSource = dt;
            //gridView1.AddNewRow();

            kullancıBilgileri();
            seviyeKontrolAnasayfa();


        }
        void seviyeKontrolAnasayfa()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
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

            MySqlCommand komut_dk2 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                                    "where seviye=@seviye", bağlantı);
            komut_dk2.Parameters.Clear();
            komut_dk2.Parameters.AddWithValue("@seviye", 2);
            bağlantı.Open();
            komut_dk2.ExecuteNonQuery();
            MySqlDataReader oku_dk2 = komut_dk2.ExecuteReader();
            while (oku_dk2.Read())
            {
                lbl_sayı_S2.Text = "" + oku_dk2[0].ToString() + " kelime / " + minSeviye2 + "";
                if (Convert.ToInt32(oku_dk2[0].ToString()) < minSeviye2)
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

            MySqlCommand komut_dk3 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                            "where seviye=@seviye", bağlantı);
            komut_dk3.Parameters.Clear();
            komut_dk3.Parameters.AddWithValue("@seviye", 3);
            bağlantı.Open();
            komut_dk3.ExecuteNonQuery();
            MySqlDataReader oku_dk3 = komut_dk3.ExecuteReader();
            while (oku_dk3.Read())
            {
                lbl_sayı_S3.Text = "" + oku_dk3[0].ToString() + " kelime / " + minSeviye3 + "";

                if (Convert.ToInt32(oku_dk3[0].ToString()) < minSeviye3)
                {
                    btn_Seviye3.Enabled = false;
                }
                else
                {
                    if (btn_Seviye2.Enabled == true)
                    {
                        btn_Seviye3.Enabled = true;
                        lbl_uyarıSeviye3.Visible = false;
                    }
                    else
                    {
                        btn_Seviye3.Enabled = false;
                        lbl_uyarıSeviye3.Visible = true;
                    }

                }
            }
            oku_dk3.Close();
            bağlantı.Close();

            MySqlCommand komut_dk4 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                            "where seviye=@seviye", bağlantı);
            komut_dk4.Parameters.Clear();
            komut_dk4.Parameters.AddWithValue("@seviye", 4);
            bağlantı.Open();
            komut_dk4.ExecuteNonQuery();
            MySqlDataReader oku_dk4 = komut_dk4.ExecuteReader();
            while (oku_dk4.Read())
            {
                lbl_sayı_S4.Text = "" + oku_dk4[0].ToString() + " kelime / " + minSeviye4 + "";
                if (Convert.ToInt32(oku_dk4[0].ToString()) < minSeviye4)
                {
                    btn_Seviye4.Enabled = false;
                }
                else
                {
                    if (btn_Seviye3.Enabled == true)
                    {
                        btn_Seviye4.Enabled = true;
                        lbl_uyarıSeviye4.Visible = false;
                    }
                    else
                    {
                        btn_Seviye4.Enabled = false;
                        lbl_uyarıSeviye4.Visible = true;
                    }
                }
            }
            oku_dk4.Close();
            bağlantı.Close();

            MySqlCommand komut_dk5 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                            "where seviye=@seviye", bağlantı);
            komut_dk5.Parameters.Clear();
            komut_dk5.Parameters.AddWithValue("@seviye", 5);
            bağlantı.Open();
            komut_dk5.ExecuteNonQuery();
            MySqlDataReader oku_dk5 = komut_dk5.ExecuteReader();
            while (oku_dk5.Read())
            {
                lbl_sayı_S5.Text = "" + oku_dk5[0].ToString() + " kelime / " + minSeviye5 + "";
                if (Convert.ToInt32(oku_dk5[0].ToString()) < minSeviye5)
                {
                    btn_Seviye5.Enabled = false;
                }
                else
                {
                    if (btn_Seviye4.Enabled == true)
                    {
                        btn_Seviye5.Enabled = true;
                        lbl_uyarıSeviye5.Visible = false;
                    }
                    else
                    {
                        btn_Seviye5.Enabled = false;
                        lbl_uyarıSeviye5.Visible = true;
                    }
                }
            }
            oku_dk5.Close();
            bağlantı.Close();

            MySqlCommand komut_dk6 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                            "where seviye=@seviye", bağlantı);
            komut_dk6.Parameters.Clear();
            komut_dk6.Parameters.AddWithValue("@seviye", 6);
            bağlantı.Open();
            komut_dk6.ExecuteNonQuery();
            MySqlDataReader oku_dk6 = komut_dk6.ExecuteReader();
            while (oku_dk6.Read())
            {
                lbl_sayı_Kalıcı.Text = "" + oku_dk6[0].ToString() + " kelime";
            }
            oku_dk6.Close();
            bağlantı.Close();
        }

        #region SAYFA GEÇİŞLERİ
        private void xtraTabControl_AnaSayfa_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xt_ana.SelectedTabPage == xt_anaPage_Anasayfa)
            {
                tarih();
                seviyeKontrolAnasayfa();
            }
            else if (xt_ana.SelectedTabPage == xt_anaPage_seviyeler)
            {

            }
            else if (xt_ana.SelectedTabPage == xt_anaPage_kalıcıHafıza)
            {

            }
        }
        #endregion

        #region Voidler
        private void doğruCevap()
        {   
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            if (seviye == "5")
            {
                kalıcıHafızayaAl();
            }
            else
            {
                MySqlCommand komut_a2 = new MySqlCommand("update " + kullanıcı + " " +
                                     "set seviye=@seviye, seviye_gösterim=@seviye_gösterim, doğru=@doğru where id=@id", bağlantı);
                komut_a2.Parameters.Clear();
                komut_a2.Parameters.AddWithValue("@id", kelimeİd);
                komut_a2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye) + 1);
                komut_a2.Parameters.AddWithValue("@doğru", Convert.ToInt32(doğru) + 1);
                komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(gösterim) + 1);
                komut_a2.Parameters.AddWithValue("@seviye_tarih", bugün);
                bağlantı.Open();
                komut_a2.ExecuteNonQuery();
                bağlantı.Close();
            }

            kullanıcıTopDoğru++;
            MySqlCommand komut_a4 = new MySqlCommand("update kullanıcılar " +
                         "set doğru=@doğru where kullanıcıadı=@kullanıcıadı", bağlantı);
            komut_a4.Parameters.Clear();
            komut_a4.Parameters.AddWithValue("@kullanıcıadı", kullanıcı);
            komut_a4.Parameters.AddWithValue("@doğru", kullanıcıTopDoğru);
            bağlantı.Open();
            komut_a4.ExecuteNonQuery();
            bağlantı.Close();
        }

        void seviyeKontrolMevcut()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);

            int _SeviyeKelimeSayısı = 0;
            int _ÜstSeviyeKelimeSayısı = 0;
            MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                            "where seviye=@seviye", bağlantı);
            komut_dk1.Parameters.Clear();
            komut_dk1.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye));
            bağlantı.Open();
            komut_dk1.ExecuteNonQuery();
            MySqlDataReader oku_dk1 = komut_dk1.ExecuteReader();
            if (oku_dk1.Read())
            {
                _SeviyeKelimeSayısı = Convert.ToInt32(oku_dk1[0].ToString());
            }
            oku_dk1.Close();
            bağlantı.Close();

            if (Convert.ToInt32(seviye)<5)
            {
                //Üst seviye kontrol
                MySqlCommand komut_dk2 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                                "where seviye=@seviye", bağlantı);
                komut_dk2.Parameters.Clear();
                komut_dk2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye) + 1);
                bağlantı.Open();
                komut_dk2.ExecuteNonQuery();
                MySqlDataReader oku_dk2 = komut_dk2.ExecuteReader();
                if (oku_dk2.Read())
                {
                    _ÜstSeviyeKelimeSayısı = Convert.ToInt32(oku_dk2[0].ToString());
                }
                oku_dk2.Close();
                bağlantı.Close();
            }

            //Devam edrken seviye kilit kontrol.
            if (seviye == "2")
            {
                lbl_seviyeKelimeSayısı.Text = "" + _SeviyeKelimeSayısı + " / " + minSeviye2 + "";
                lbl_üstSeviyeBaşlık.Text = "Seviye "+ (Convert.ToInt32(seviye) + 1) + ":";
                lbl_üstseviyeKelimeSayısı.Text = "" + _ÜstSeviyeKelimeSayısı + " / " + minSeviye3 + "";
            }
            else if (seviye == "3")
            {
                lbl_seviyeKelimeSayısı.Text = "" + _SeviyeKelimeSayısı + " / " + minSeviye3 + "";
                lbl_üstSeviyeBaşlık.Text = "Seviye " + (Convert.ToInt32(seviye) + 1) + ":";
                lbl_üstseviyeKelimeSayısı.Text = "" + _ÜstSeviyeKelimeSayısı + " / " + minSeviye4 + "";
                if (2 > _SeviyeKelimeSayısı)
                {
                    MessageBox.Show("Seviye 3'de yeterli kelime kalmadı.\nUygun seviye seçimi için anasayfaya yönlendiriliyorsunuz.");
                    xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
                }
            }
            else if (seviye == "4")
            {
                lbl_seviyeKelimeSayısı.Text = "" + _SeviyeKelimeSayısı + " / " + minSeviye4 + "";
                lbl_üstSeviyeBaşlık.Text = "Seviye " + (Convert.ToInt32(seviye) + 1) + ":";
                lbl_üstseviyeKelimeSayısı.Text = "" + _ÜstSeviyeKelimeSayısı + " / " + minSeviye5 + "";
                if (minSeviye4 > _SeviyeKelimeSayısı)
                {
                    MessageBox.Show("Seviye 4'de yeterli kelime kalmadı.\nUygun seviye seçimi için anasayfaya yönlendiriliyorsunuz.");
                    xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
                }
            }
            else if (seviye == "5")
            {
                lbl_seviyeKelimeSayısı.Text = "" + _SeviyeKelimeSayısı + " / " + minSeviye5 + "";
                if (minSeviye4 > _SeviyeKelimeSayısı)
                {
                    MessageBox.Show("Seviye 5'de yeterli kelime kalmadı.\nUygun seviye seçimi için anasayfaya yönlendiriliyorsunuz.");
                    xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
                }
            }
        }
        private void yanlışCevap()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update "+kullanıcı+" " +
                     "set seviye=@seviye,yanlış=@yanlış,seviye_gösterim=@seviye_gösterim,seviye_tarih=@seviye_tarih where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeİd);
            komut_a2.Parameters.AddWithValue("@yanlış", Convert.ToInt32(yanlış) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(yanlış) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_tarih", bugün);
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

            if (hak>0)
            {
                hak--;
            }
        }
        #endregion

        #region Ana Sayfa Butonlar
        private void s1_btnFavori_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut_a2 = new MySqlCommand("update " + kullanıcı + " " +
                     "set favori=@favori where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeİd);
            komut_a2.Parameters.AddWithValue("@favori", s1_btnFavori.EditValue);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
        }

        private void btn_kelimeEkle_Click_1(object sender, EventArgs e)
        {
            Form_KelimeEkle frm = new Form_KelimeEkle();
            frm.ShowDialog();
        }

        private void btn_Kısım1_Click(object sender, EventArgs e)
        {
            btn_kalıcaHafızaOnay.Visible = true;
            seviye = "1";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 1";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım2_Click(object sender, EventArgs e)
        {
            btn_kalıcaHafızaOnay.Visible = true;
            seviye = "2";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 2";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım3_Click(object sender, EventArgs e)
        {
            btn_kalıcaHafızaOnay.Visible = false;
            seviye = "3";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 3";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım4_Click(object sender, EventArgs e)
        {
            btn_kalıcaHafızaOnay.Visible = false;
            seviye = "4";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 4";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım5_Click(object sender, EventArgs e)
        {
            btn_kalıcaHafızaOnay.Visible = false;
            seviye = "5";
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 5";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
            yeniSoru();
            hak = 0;
        }

        private void btn_kalıcıHafıza_Click(object sender, EventArgs e)
        {
            btn_kalıcaHafızaOnay.Visible = false;
            seviye = "6";
            xt_ana.SelectedTabPage = xt_anaPage_kalıcıHafıza;
            lbl_seviye.Text = "Kalıcı Hafıza";
        }

        #endregion

        private void yeniSoru()
        {
            seviyeKontrolMevcut();
            timer_soruArası.Stop();
            timer_yazmalıSoruArası.Stop();
            şık_1.Font = new Font(şık_1.Font.FontFamily, 7, FontStyle.Regular);
            şık_2.Font = new Font(şık_2.Font.FontFamily, 7, FontStyle.Regular);
            şık_3.Font = new Font(şık_2.Font.FontFamily, 7, FontStyle.Regular);
            şık_1.Appearance.BackColor = Color.White;
            şık_2.Appearance.BackColor = Color.White;
            şık_3.Appearance.BackColor = Color.White;
            lbl_ipucu.Visible = false;
            btn_kelime.Appearance.BackColor = Color.White;
            şık_1.Enabled = true;
            şık_2.Enabled = true;
            şık_3.Enabled = true;

            btn_pas.Enabled = true;

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

        public string yanıt = "";

        List<string> şıklar = new List<string>();

        #region SEVİYE-1

        private void rasgeleKelime()
        {   
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            
            MySqlCommand komut = new MySqlCommand();
            string _tür = "";
            string _alan = "";
            #region KategorilereGöre
            if (ch_fiiller.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+ " and tür=@tür ORDER BY seviye_tarih ASC, RAND()";
                _tür = "fiil";
            }
            else if (ch_sıfatlar.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+ " and tür=@tür ORDER BY seviye_tarih ASC, RAND()";
                _tür = "sıfat";
            }
            else if (ch_isimler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+ " and tür=@tür ORDER BY seviye_tarih ASC, RAND()";
                _tür = "isim";
            }
            else if (ch_zamirler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+ " and tür=@tür ORDER BY seviye_tarih ASC, RAND()";
                _tür = "zamir";
            }
            else if (ch_edatlar.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+ " and tür=@tür ORDER BY seviye_tarih ASC, RAND()";
                _tür = "edat";
            }
            else if (ch_favoriler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and favori=1 ORDER BY seviye_tarih ASC, RAND()";
            }
            else if (ch_yanlışlar.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+ " ORDER BY yanlış DESC, seviye_tarih ASC, RAND()";
                //komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" ORDER BY yanlış ASC, RAND()";
            }
            else if (ch_duyguVeHisler.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY seviye_tarih ASC, RAND()";
                _alan = "duygu ve his";
            }
            else if (ch_gıda.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY seviye_tarih ASC, RAND()";
                _alan = "gıda";
            }
            else if (ch_işHayatı.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY seviye_tarih ASC, RAND()";
                _alan = "iş hayatı";
            }
            else if (ch_insanVucudu.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY seviye_tarih ASC, RAND()";
                _alan = "insan ve sağlık";
            }
            else if (ch_kıyafet.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY seviye_tarih ASC, RAND()";
                _alan = "Kılık Kıyafet";
            }
            else if (ch_c1.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY seviye_tarih ASC, RAND()";
                _alan = "c1";
            }
            else if (ch_b1.Checked == true)
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+" and alan=@alan ORDER BY seviye_tarih ASC, RAND()";
                _alan = "b1";
            }
            else            
            {
                komut.CommandText = "SELECT *from "+kullanıcı+" where seviye="+seviye+ " ORDER BY seviye_tarih ASC, RAND()";
            }
            #endregion
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

                    if (seviye == "3")
                    {
                        Random rnd = new Random();
                        int sayı = rnd.Next(1, 5);

                        if (sayı == 2)
                        {
                            cevap = dr["EN"].ToString();
                            kelime = dr["TR"].ToString();
                        }
                        else
                        {
                            cevap = dr["TR"].ToString();
                            kelime = dr["EN"].ToString();
                        }
                    }
                    else
                    {
                        cevap = dr["TR"].ToString();
                        kelime = dr["EN"].ToString();
                    }
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
                    sonSayı = 5;
                }
                if (seviye == "2")
                {
                    sonSayı = 4;
                }
                if (seviye == "3")
                {
                    sonSayı = 3;
                }

                Random rnd = new Random();
                int sayı = rnd.Next(1, sonSayı);
                if (sayı == 1)
                {
                    xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
                    ts_seçmeliYazmalı.Enabled = false;
                    ts_seçmeliYazmalı.EditValue = "yazmalı";
                    lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
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

        
        

        #region CevapKontrol

        private void s1_şık_1_Click(object sender, EventArgs e)
        {
            //Yanlış cevaba tıklandıktan sonra,
            //Doğru yanıta tıklandığında yeni soru gelsin.
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
                    timer_soruArası.Start();
                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafızayaAl();
                        kalıcıHafızaTest = "";
                    }
                    doğruCevap();
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
                    yanlışCevap();

                    yanıt = "yanlış";//Doğru şıkka tıkla yeni soru gelsin.
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
                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafızayaAl();
                        kalıcıHafızaTest = "";
                    }
                    doğruCevap();
                    
                    timer_soruArası.Start();
                    
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

                    yanlışCevap();
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
                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafızayaAl();
                        kalıcıHafızaTest = "";
                    }
                    doğruCevap();
                    timer_soruArası.Start();
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
                    yanlışCevap();
                    yanıt = "yanlış";
                }
            }                        
        }

        private void ipucuBilgisiGöster()
        {
            if (hak > 0)
            {
                if (seviye == "3")
                {
                    lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/1";
                }
                else if (seviye == "2" | seviye == "1")
                {
                    if (kalıcıHafızaTest == "1")
                    {
                        lbl_hak.Text = "Kalıcı hafıza testinde ipucu gösterimi yoktur.";
                    }
                    else
                    {
                        lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                    }
                }
                else
                {
                    lbl_hak.Text = "Bu seviyede ipucu gösterimi yoktur.";
                }
            }
            else if (hak == 0)
            {
                if (Convert.ToInt32(seviye) < 3)
                {
                    if (kalıcıHafızaTest == "1")
                    {
                        lbl_hak.Text = "Kalıcı hafıza testinde ipucu gösterimi yoktur.";
                    }
                    else
                    {
                        lbl_hak.Text = "İpucu Hakkınız Kalmadı. Doğru cevaplar vererek yükseltin.";
                    }

                }
                else
                {
                    lbl_hak.Text = "Bu seviyede ipucu gösterimi yoktur.";
                }
            }
        }

        int hak = 2;
        int tamEşleşmeVeyaİçerme = 0;
        int yazmalıYanlışYapıldı = 0;

        private void btn_yazmalı_ok_Click(object sender, EventArgs e)
        {
            ipucuBilgisiGöster();
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

            if (txt_yazmalı_yanıt.Text == "" | (tamEşleşmeVeyaİçerme == -1 && metin != ara) | (txt_yazmalı_yanıt.Text.Length != ilkKelimeUzunluk & txt_yazmalı_yanıt.Text.Length != sonKelimeUzunluk) & (ilkKelimeUzunluk != 0 & sonKelimeUzunluk != 0))
            {
                //YANLIŞ
                yazmalıYanlışYapıldı = 1;

                //İPUCU GÖSTER
                if (hak > 0 & (seviye != "5" | seviye != "4") & kalıcıHafızaTest != "1")
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
                else if (hak == 0 | seviye == "5" | seviye == "4" | kalıcıHafızaTest == "1")
                {
                    //hak kalmamış direk yanlış işlemler
                    lbl_ipucu.ForeColor = Color.Red;
                    lbl_ipucu.Visible = true;
                    lbl_ipucu.Text = cevap;

                    timer_yazmalıSoruArası.Start();
                    
                    
                    yanıt = "yanlış";                                        
                }
                //İPUCU GÖSTER SONU
                yanlışCevap();
                ipucuBilgisiGöster();

                btn_kelime.Appearance.BackColor = Color.Red;
            }
            else
            {
                if ((birdenfazlakelime == 1 & metin == ara) | (tamEşleşmeVeyaİçerme == 0 && metin == ara) | ((tamEşleşmeVeyaİçerme > -1 & txt_yazmalı_yanıt.Text.Length == ilkKelimeUzunluk)| ((tamEşleşmeVeyaİçerme > -1 & txt_yazmalı_yanıt.Text.Length == sonKelimeUzunluk))))
                {
                    //DOĞRU

                    if (hak < 3 & yazmalıYanlışYapıldı != 0)
                    {
                        hak++;
                        lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                    }

                    yazmalıYanlışYapıldı = 0;

                    btn_kelime.Appearance.BackColor = Color.Green;

                    timer_soruArası.Start();

                    çalışmaTemizle();
                    if (kalıcıHafızaTest != "")
                    {
                        kalıcıHafızayaAl();
                        kalıcıHafızaTest = "";
                    }
                    doğruCevap();

                    
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

                    //İPUCU GÖSTER
                    if (hak > 0 & (seviye != "5" | seviye != "4") & kalıcıHafızaTest != "1")
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
                    }
                    else if (hak == 0 | seviye == "5" | seviye == "4" | kalıcıHafızaTest == "1")
                    {
                        //hak kalmamış direk yanlış işlemler
                        lbl_ipucu.ForeColor = Color.Red;
                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = cevap;

                        timer_yazmalıSoruArası.Start();

                        yanlışCevap();
                        yanıt = "yanlış";
                    }
                    //İPUCU GÖSTER SONU

                    ipucuBilgisiGöster();
                }
            }

            kalıcıHafızaTest = "";
        }

        void çalışmaTemizle()
        {
            txt_yazmalı_yanıt.Text = "";
            lbl_ipucu.Text = "";
            lbl_ipucu.Visible = false;
            ipucuBilgisiGöster();
        }

        #region Kategori Butonları
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

        public string kalıcıHafızaTest = "";

        private void btn_kalıcaHafızaOnay_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bu kelime zaten ezberimde diyorsun yani?\nEğer doğru bilirsen 'Kalıcı Hafıza Adayı' statüsüne taşınacak. Bir daha da önüne çıkmayacak.\n\nOnaylıyor musun?", "KALICI HAFIZA", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                kalıcıHafızaTest = "1";
                xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
                btn_pas.Enabled = false;
                btn_kelime.Text = cevap;
                cevap = kelime;
                ipucuBilgisiGöster();
            }
            else
            {
                kalıcıHafızaTest = "";
            }
        }

        private void kalıcıHafızayaAl()
        {            
            string _kalıcıHafıza = "";
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            //kalıcıhafıza ya alıyoruz
            MySqlCommand komut_a2 = new MySqlCommand("update " + kullanıcı + " " +
                     "set seviye_gösterim=@seviye_gösterim, doğru=@doğru, seviye=@seviye where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeİd);
            komut_a2.Parameters.AddWithValue("@doğru", Convert.ToInt32(doğru) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(gösterim) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_tarih", bugün);
            komut_a2.Parameters.AddWithValue("@seviye", 6);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();

            //kullanıcının Kalıcı hafızayı say
            MySqlCommand komut2 = new MySqlCommand();
            komut2.CommandText = "SELECT count(seviye) FROM " + kullanıcı + " where seviye=6";
            komut2.Connection = bağlantı;
            komut2.CommandType = CommandType.Text;
            MySqlDataReader dr2;
            bağlantı.Open();
            dr2 = komut2.ExecuteReader();
            if (dr2.Read())
            {
                _kalıcıHafıza = dr2[0].ToString();
            }
            dr2.Close();
            bağlantı.Close();

            //sayılan kalıcıhafızayı kullanıcılara kaydet
            MySqlCommand komut_a3 = new MySqlCommand("update kullanıcılar " +
                         "set kalıcıhafıza=@kalıcıhafıza where kullanıcıadı=@kullanıcıadı", bağlantı);
            komut_a3.Parameters.Clear();
            komut_a3.Parameters.AddWithValue("@kullanıcıadı", kullanıcı);
            komut_a3.Parameters.AddWithValue("@kalıcıhafıza", _kalıcıHafıza);
            bağlantı.Open();
            komut_a3.ExecuteNonQuery();
            bağlantı.Close();

            MessageBox.Show("'"+kelime+"' kelimesi 'Kalıcı Hafıza Adayı' statüsüne alındı.");
            kalıcıHafızaTest = "";
        }

        private void timer_soruArası_Tick(object sender, EventArgs e)
        {
            yeniSoru();
        }
        private void timer_yazmalıSoruArası_Tick(object sender, EventArgs e)
        {
            yeniSoru();
        }
        
        private void xt_şıklar_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xt_şıklar.SelectedTabPage == xt_şıklarPage_seçmeli)
            {
                ts_seçmeliYazmalı.EditValue = "seçmeli";
            }
            else
            {
                ts_seçmeliYazmalı.EditValue = "yazmalı";
                txt_yazmalı_yanıt.Focus();
                ipucuBilgisiGöster();
            }
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

        private void btn_pas_Click(object sender, EventArgs e)
        {
            lbl_ipucu.Visible = true;
            lbl_ipucu.Text = cevap;
            lbl_ipucu.Appearance.ForeColor = Color.DarkGreen;
            
            timer_yazmalıSoruArası.Start();
            yanlışCevap();
            kalıcıHafızaTest = "";
        }

        private void btn_sorunbildir_Click(object sender, EventArgs e)
        {
            Form_SorunBildir frm = new Form_SorunBildir();

            frm.kelimeİd = kelimeİd;
            frm.kelime = kelime;
            frm.cevap = cevap;
            frm.kullanıcı = kullanıcı;
            frm.kullanıcıİd = kullanıcıİd;

            frm.ShowDialog();
        }

        public void sorunBildirSonrası()
        {
            timer_soruArası.Start();
        }
    }
}
