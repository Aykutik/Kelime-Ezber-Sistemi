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

        public string kullanıcı = "";
        public int düzey = 0;
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
            //MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            //MySqlCommand komut_a2 = new MySqlCommand("update " + kullanıcı + " " +
            //                         "set seviye=@seviye", bağlantı);
            //komut_a2.Parameters.Clear();
            //komut_a2.Parameters.AddWithValue("@seviye", 1);
            //bağlantı.Open();
            //komut_a2.ExecuteNonQuery();
            //bağlantı.Close();

            MySqlDataAdapter adp = new MySqlDataAdapter("select * from kullanıcılar ORDER BY kalıcıhafıza DESC, doğru DESC", bağlantıadresi);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            gridControl1.DataSource = ds.Tables[0];
            ds.Dispose();

            kullancıBilgileri();
            seviyeKontrolAnasayfa();
            txt_kullanıcıAdı.Focus();
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
                btn_anasayfa.Enabled = false;
                tarih();
                seviyeKontrolAnasayfa();
            }
            else if (xt_ana.SelectedTabPage == xt_anaPage_seviyeler)
            {
                btn_anasayfa.Enabled = true;
                ipucuBilgisiGöster();
            }
            else if (xt_ana.SelectedTabPage == xt_anaPage_kalıcıHafıza)
            {
                btn_anasayfa.Enabled = true;
                MySqlDataAdapter adp = new MySqlDataAdapter("select * from aykutik where seviye=6", bağlantıadresi);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                gridControl_kalıcıHafıza.DataSource = ds.Tables[0];
                ds.Dispose();
            }
            else if (xt_ana.SelectedTabPage == xt_anaPage_giriş)
            {
                btn_anasayfa.Visible = false;
                btn_anasayfa.Enabled = true;
                txt_kullanıcıAdı.Focus();
            }

            panelControl1.Visible = false;
        }
        #endregion

        #region Voidler
        private void doğruCevap()
        {
            int kalıcıHafızaSay = 0;
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            if (seviye == "5")
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

                MySqlCommand komut_dk1 = new MySqlCommand("select COUNT(*) from " + kullanıcı + " " +
                            "where seviye=@seviye", bağlantı);
                komut_dk1.Parameters.Clear();
                komut_dk1.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye));
                bağlantı.Open();
                komut_dk1.ExecuteNonQuery();
                MySqlDataReader oku_dk1 = komut_dk1.ExecuteReader();
                if (oku_dk1.Read())
                {
                    kalıcıHafızaSay = Convert.ToInt32(oku_dk1[0].ToString());
                }
                oku_dk1.Close();
                bağlantı.Close();
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
            string komut = "";            
            if (kalıcıHafızaSay > 0)
            {
                komut = "update kullanıcılar " +
                         "set doğru=@doğru, kalıcıhafıza=@kalıcıhafıza where kullanıcıadı=@kullanıcıadı";
            }
            else
            {
                komut = "update kullanıcılar " +
                         "set doğru=@doğru where kullanıcıadı=@kullanıcıadı";
            }
            MySqlCommand komut_a4 = new MySqlCommand(komut, bağlantı);
            komut_a4.Parameters.Clear();
            komut_a4.Parameters.AddWithValue("@kullanıcıadı", kullanıcı);
            komut_a4.Parameters.AddWithValue("@doğru", kullanıcıTopDoğru);
            komut_a4.Parameters.AddWithValue("@kalıcıhafıza", kalıcıHafızaSay);
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
            if (seviye == "1")
            {
                lbl_seviyeKelimeSayısı.Text = "(" + _SeviyeKelimeSayısı + " Kelime)";
                lbl_üstSeviyeBaşlık.Text = "Seviye " + (Convert.ToInt32(seviye) + 1) + ":";
                lbl_üstseviyeKelimeSayısı.Text = "" + _ÜstSeviyeKelimeSayısı + " / " + minSeviye2 + " Kelime";
            }
            if (seviye == "2")
            {
                lbl_seviyeKelimeSayısı.Text = "(" + _SeviyeKelimeSayısı + " / " + minSeviye2 + " Kelime)";
                lbl_üstSeviyeBaşlık.Text = "Seviye "+ (Convert.ToInt32(seviye) + 1) + ":";
                lbl_üstseviyeKelimeSayısı.Text = "" + _ÜstSeviyeKelimeSayısı + " / " + minSeviye3 + " Kelime";
                if (1 > _SeviyeKelimeSayısı)
                {
                    timer_soruArası.Stop();
                    timer_yazmalıSoruArası.Stop();
                    MessageBox.Show("Seviye 3'de yeterli kelime kalmadı.\nUygun seviye seçimi için anasayfaya yönlendiriliyorsunuz.");
                    xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
                }
            }
            else if (seviye == "3")
            {
                lbl_seviyeKelimeSayısı.Text = "(" + _SeviyeKelimeSayısı + " / " + minSeviye3 + " Kelime)";
                lbl_üstSeviyeBaşlık.Text = "Seviye " + (Convert.ToInt32(seviye) + 1) + ":";
                lbl_üstseviyeKelimeSayısı.Text = "" + _ÜstSeviyeKelimeSayısı + " / " + minSeviye4 + " Kelime";
                if (1 > _SeviyeKelimeSayısı)
                {
                    MessageBox.Show("Seviye 3'de yeterli kelime kalmadı.\nUygun seviye seçimi için anasayfaya yönlendiriliyorsunuz.");
                    xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
                }
            }
            else if (seviye == "4")
            {
                lbl_seviyeKelimeSayısı.Text = "(" + _SeviyeKelimeSayısı + " / " + minSeviye4 + " Kelime)";
                lbl_üstSeviyeBaşlık.Text = "Seviye " + (Convert.ToInt32(seviye) + 1) + ":";
                lbl_üstseviyeKelimeSayısı.Text = "" + _ÜstSeviyeKelimeSayısı + " / " + minSeviye5 + " Kelime";
                if (1 > _SeviyeKelimeSayısı)
                {
                    MessageBox.Show("Seviye 4'de yeterli kelime kalmadı.\nUygun seviye seçimi için anasayfaya yönlendiriliyorsunuz.");
                    xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
                }
            }
            else if (seviye == "5")
            {
                lbl_seviyeKelimeSayısı.Text = "(" + _SeviyeKelimeSayısı + " / " + minSeviye5 + " Kelime)";
                if (1 > _SeviyeKelimeSayısı)
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
            if (seviye == "1")
            {
                komut_a2.Parameters.AddWithValue("@seviye", Convert.ToInt32(seviye));
            }
            else
            {                
                komut_a2.Parameters.AddWithValue("@seviye", 2);
            }
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();

            if (hak > 0)
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
            frm.kullanıcı = kullanıcı;
            frm.Show();
        }

        private void btn_Kısım1_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            btn_kalıcaHafızaOnay.Visible = true;
            seviye = "1";
            hak = 3;
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 1";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım2_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            btn_kalıcaHafızaOnay.Visible = true;
            seviye = "2";
            hak = 3;
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 2";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım3_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            btn_kalıcaHafızaOnay.Visible = false;
            seviye = "3";
            hak = 1;
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 3";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım4_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            btn_kalıcaHafızaOnay.Visible = false;
            seviye = "4";
            hak = 0;
            xt_ana.SelectedTabPage = xt_anaPage_seviyeler;
            lbl_seviye.Text = "Seviye 4";
            xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            yeniSoru();
        }

        private void btn_Kısım5_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            btn_kalıcaHafızaOnay.Visible = false;
            seviye = "5";
            hak = 0;
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

            denemeSayısı = 0;

            çalışmaTemizle();
            rasgeleKelime();
            
            btn_kelime.Text = kelime;
            şık_1.Text = şık1;
            şık_2.Text = şık2;
            şık_3.Text = şık3;
            lbl_kelimeYanlış.Text = yanlış;
            lbl_kelimeDoğru.Text = doğru;
            s1_btnFavori.EditValue = favori;
            lbl_KelimeTür.Text = tür;
            lbl_okunuşu.Text = oku;
            panelControl1.Visible = false;
        }

        public string çeviri = "";
        public string kelimeİd = "";
        public string seviye = "";
        public string gösterim = "";
        public string tür = "";
        public string alan = "";
        public string favori = "";
        public string doğru = "";
        public string yanlış = "";
        public string kelime = "";
        public string oku = "";
        public string eş = "";

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
            string _kur = "";
            #region KategorilereGöre
            if (ch_a1.Checked == true)
            {
                komut.CommandText = "SELECT *from " + kullanıcı + " where seviye=" + seviye + " and kur=@kur ORDER BY seviye_tarih ASC, RAND()";
                _kur = "a1";
            }
            else if (ch_fiiller.Checked == true)
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
            komut.Parameters.AddWithValue("@kur", _kur);
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
                oku = dr["oku"].ToString();
                eş = dr["eş"].ToString();

                if (Convert.ToInt32(seviye) < 5) //seviye 4 den küçükse ve eşli kelime değilse arada bir engilizce sorup türkçe cevap isteyecek
                {
                    if (seviye == "4" & eş != "x")
                    {
                        Random rnd = new Random();
                        int sayı = rnd.Next(1, 5);

                        if (sayı == 2 | sayı == 4)
                        {
                            çeviri = dr["EN"].ToString();
                            kelime = dr["TR"].ToString();
                        }
                        else
                        {
                            çeviri = dr["TR"].ToString();
                            kelime = dr["EN"].ToString();
                        }
                    }
                    else if (seviye == "3" & eş != "x")
                    {
                        Random rnd = new Random();
                        int sayı = rnd.Next(1, 5);

                        if (sayı == 2)
                        {
                            çeviri = dr["EN"].ToString();
                            kelime = dr["TR"].ToString();
                        }
                        else
                        {
                            çeviri = dr["TR"].ToString();
                            kelime = dr["EN"].ToString();
                        }
                    }
                    else
                    {
                        çeviri = dr["TR"].ToString();
                        kelime = dr["EN"].ToString();
                    }
                }
                else
                {
                    çeviri = dr["EN"].ToString();
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
            şıklar.Add(çeviri);

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
            if (Convert.ToInt32(seviye) < 4 & Convert.ToInt32(seviye) > 0)
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
                    //ts_seçmeliYazmalı.Enabled = false;
                    //ts_seçmeliYazmalı.EditValue = "yazmalı";
                    lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                }
                else
                {
                    seçmeliŞıkOluştur();
                    xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
                    //ts_seçmeliYazmalı.Visible = true;
                    //ts_seçmeliYazmalı.Enabled = true;
                    //ts_seçmeliYazmalı.EditValue = "seçmeli";
                }
            }
            else if (seviye == "5")
            {
                xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
                //ts_seçmeliYazmalı.Visible = false;
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
                if (şık_1.Text == çeviri)
                {
                    
                    şık_1.Appearance.BackColor = Color.Green;

                    doğruCevapGörsel();

                    timer_soruArası.Start();

                    if (seviye5EAL_Test != "")
                    {
                        Seviye5EAl();
                        seviye5EAL_Test = "";
                    }

                    doğruCevap();
                }
                else
                {
                    şık_1.Appearance.BackColor = Color.Red;
                    şık_1.Enabled = false;

                    if (şık_2.Text == çeviri)
                    {
                        şık_3.Enabled = false;
                        şık_2.Appearance.BackColor = Color.DarkOrange;
                        şık_2.Font = new Font(şık_2.Font.FontFamily, 8, FontStyle.Bold);

                        yanlışCevapGörsel("seçmeli");

                    }

                    if (şık_3.Text == çeviri)
                    {
                        şık_2.Enabled = false;
                        şık_3.Font = new Font(şık_3.Font.FontFamily, 8, FontStyle.Bold);
                        şık_3.Appearance.BackColor = Color.DarkOrange;

                        yanlışCevapGörsel("seçmeli");
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
                if (şık_2.Text == çeviri)
                {
                    
                    şık_2.Appearance.BackColor = Color.Green;
                    doğruCevapGörsel();

                    if (seviye5EAL_Test != "")
                    {
                        Seviye5EAl();
                        seviye5EAL_Test = "";
                    }
                    doğruCevap();
                    
                    timer_soruArası.Start();
                    
                }
                else
                {
                    şık_2.Appearance.BackColor = Color.Red;
                    şık_2.Enabled = false;
                    if (şık_1.Text == çeviri)
                    {
                        şık_1.Appearance.BackColor = Color.DarkOrange;                        
                        şık_3.Enabled = false;
                        şık_1.Font = new Font(şık_1.Font.FontFamily, 8, FontStyle.Bold);

                        yanlışCevapGörsel("seçmeli");
                    }

                    if (şık_3.Text == çeviri)
                    {
                        şık_3.Appearance.BackColor = Color.DarkOrange;
                        
                        şık_1.Enabled = false;
                        şık_3.Font = new Font(şık_3.Font.FontFamily, 8, FontStyle.Bold);

                        yanlışCevapGörsel("seçmeli");
                    }

                    yanlışCevap();
                    yanıt = "yanlış";
                }
            }
        }

        private void yanlışCevapGörsel(string neli)
        {
            if (neli == "yazmalı")
            {
                lbl_kelimeYanlış_başlık.BackColor = Color.Red;
                lbl_kelimeDoğru_başlık.BackColor = Color.Red;
                btn_kelime.Appearance.BackColor = Color.Red;
                s1_btnFavori.BackColor = Color.Red;
                lbl_kelimeDoğru.BackColor = Color.Red;
                lbl_kelimeYanlış.BackColor = Color.Red;
                btn_kalıcaHafızaOnay.Appearance.BackColor = Color.Red;
                btn_sorunbildir.Appearance.BackColor = Color.Red;
                lbl_KelimeTür.BackColor = Color.Red;
            }
            else
            {
                lbl_kelimeYanlış_başlık.BackColor = Color.DarkOrange;
                lbl_kelimeDoğru_başlık.BackColor = Color.DarkOrange;
                btn_kelime.Appearance.BackColor = Color.DarkOrange;
                s1_btnFavori.BackColor = Color.DarkOrange;
                lbl_kelimeDoğru.BackColor = Color.DarkOrange;
                lbl_kelimeYanlış.BackColor = Color.DarkOrange;
                btn_kalıcaHafızaOnay.Appearance.BackColor = Color.DarkOrange;
                btn_sorunbildir.Appearance.BackColor = Color.DarkOrange;
                lbl_KelimeTür.BackColor = Color.DarkOrange;
            }

            lbl_kelimeYanlış_başlık.ForeColor = Color.White;
            lbl_kelimeDoğru_başlık.ForeColor = Color.White;
            lbl_kelimeDoğru.ForeColor = Color.White;
            lbl_kelimeYanlış.ForeColor = Color.White;
            lbl_KelimeTür.ForeColor = Color.White;
            btn_kelime.ForeColor = Color.White;


        }

        private void doğruCevapGörsel()
        {
            lbl_kelimeYanlış_başlık.BackColor = Color.Green;
            lbl_kelimeDoğru_başlık.BackColor = Color.Green;
            s1_btnFavori.BackColor = Color.Green;
            lbl_kelimeDoğru.BackColor = Color.Green;
            lbl_kelimeYanlış.BackColor = Color.Green;
            btn_kalıcaHafızaOnay.Appearance.BackColor = Color.Green;
            btn_sorunbildir.Appearance.BackColor = Color.Green;
            lbl_KelimeTür.BackColor = Color.Green;
            btn_kelime.Appearance.BackColor = Color.Green;

            lbl_kelimeYanlış_başlık.ForeColor = Color.White;
            lbl_kelimeDoğru_başlık.ForeColor = Color.White;
            lbl_kelimeDoğru.ForeColor = Color.White;
            lbl_kelimeYanlış.ForeColor = Color.White;
            lbl_KelimeTür.ForeColor = Color.White;
            btn_kelime.ForeColor = Color.White;

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
                if (şık_3.Text == çeviri)
                {
                    şık_3.Appearance.BackColor = Color.Green;
                    doğruCevapGörsel();

                    if (seviye5EAL_Test != "")
                    {
                        Seviye5EAl();
                        seviye5EAL_Test = "";
                    }
                    doğruCevap();
                    timer_soruArası.Start();
                }
                else
                {
                    şık_3.Appearance.BackColor = Color.Red;
                    şık_3.Enabled = false;
                    if (şık_1.Text == çeviri)
                    {
                        şık_1.Appearance.BackColor = Color.DarkOrange;                        
                        şık_1.Font = new Font(şık_1.Font.FontFamily, 8, FontStyle.Bold);
                        şık_2.Enabled = false;
                        yanlışCevapGörsel("seçmeli");
                    }

                    if (şık_2.Text == çeviri)
                    {
                        şık_2.Appearance.BackColor = Color.DarkOrange;                        
                        şık_2.Font = new Font(şık_2.Font.FontFamily, 8, FontStyle.Bold);
                        şık_1.Enabled = false;
                        yanlışCevapGörsel("seçmeli");
                    }

                    // Seviye 0 oldğu için bir alt seviyeye geçirmiyoruz
                    yanlışCevap();
                    yanıt = "yanlış";
                }
            }                        
        }

        private void ipucuBilgisiGöster()
        {
            if (hak >= 0)
            {
                if (seviye == "3")
                {
                    if (seviye5EAL_Test == "1")
                    {
                        lbl_hak.Text = "Kalıcı hafıza testinde ipucu gösterimi yoktur.";
                    }
                    else
                    {
                        lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/1";
                    }
                }
                else if (seviye == "2" | seviye == "1")
                {
                    if (seviye5EAL_Test == "1")
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
        }

        int hak = 3;
        int yazmalıYanlışYapıldı = 0;
        int denemeSayısı = 0;

        private void btn_yazmalı_ok_Click(object sender, EventArgs e)
        {
            if (txt_yazmalı_yanıt.Text.Trim() != "" )
            {
                //çeviri = "kendi, (bahane) banane, olmak ve olmak";
                string metin = çeviri.Trim().ToLower().Replace(" ", string.Empty);
                string cevap = txt_yazmalı_yanıt.Text.Trim().ToLower().Replace(" ", string.Empty);
                int virgül = çeviri.IndexOf(","); // Tek anlamımı var yoksa birden fazla mı?
                string anlam1 = "";
                string anlam2 = "";
                string anlam3 = "";
                int parantez = -1;
                int parantezSonu = -1;

                if (virgül < 0)
                {
                    //Tek anlamı
                    anlam1 = metin;

                    parantez = çeviri.IndexOf("(");
                    parantezSonu = çeviri.IndexOf(")");

                    if (parantez >= 0)
                    {
                        //Parantez var
                        if (parantez == 0)
                        {
                            anlam1 = anlam1.Substring(parantezSonu + 1, anlam1.Length - parantezSonu - 1);
                        }
                        else
                        {
                            anlam1 = anlam1.Substring(0, parantez);
                        }
                    }
                }
                else
                {
                    //Birden fazla anlam var.
                    char[] virgülAyırma = { ',' };
                    string[] anlam = çeviri.Split(virgülAyırma);
                    anlam1 = anlam[0].Trim().ToLower().Replace(" ", string.Empty);
                    parantez = anlam1.IndexOf("(");
                    parantezSonu = anlam1.IndexOf(")");
                    if (parantez >= 0)
                    {
                        //Parantez var
                        if (parantez == 0)
                        {
                            anlam1 = anlam1.Substring(parantezSonu + 1, anlam1.Length - parantezSonu - 1);
                        }
                        else
                        {
                            anlam1 = anlam1.Substring(0, parantez);
                        }
                    }
                    anlam2 = anlam[1].Trim().ToLower().Replace(" ", string.Empty);
                    parantez = anlam2.IndexOf("(");
                    parantezSonu = anlam2.IndexOf(")");
                    if (parantez >= 0)
                    {
                        //Parantez var
                        if (parantez == 0)
                        {
                            anlam2 = anlam2.Substring(parantezSonu + 1, anlam2.Length - parantezSonu - 1);
                        }
                        else
                        {
                            anlam2 = anlam2.Substring(0, parantez);
                        }
                    }
                    if (anlam3!="")
                    {
                        anlam3 = anlam[2].Trim().ToLower().Replace(" ", string.Empty);
                        parantez = anlam3.IndexOf("(");
                        parantezSonu = anlam3.IndexOf(")");
                        if (parantez >= 0)
                        {
                            //Parantez var
                            if (parantez == 0)
                            {
                                anlam3 = anlam3.Substring(parantezSonu + 1, anlam3.Length - parantezSonu - 1);
                            }
                            else
                            {
                                anlam3 = anlam3.Substring(0, parantez);
                            }
                        }
                    }
                }              

                if (cevap == anlam1 | cevap == anlam2 | cevap == anlam3)
                {
                    //DOĞRU
                    doğruCevapGörsel();
                    if (hak < 3)//& yazmalıYanlışYapıldı != 0
                    {
                        hak++;
                        //lbl_hak.Text = "İpucu Hakkı: " + hak.ToString() + "/3";
                        ipucuBilgisiGöster();
                    }

                    yazmalıYanlışYapıldı = 0;


                    denemeSayısı = 0;
                    
                    timer_soruArası.Start();
                                 
                    if (seviye5EAL_Test != "")
                    {
                        Seviye5EAl();
                        seviye5EAL_Test = "";
                    }
                    doğruCevap();
                    //çalışmaTemizle();

                }
                else
                {
                    //YANLIŞ
                    yanlışCevapGörsel("yazmalı");
                    yazmalıYanlışYapıldı = 1;
                    denemeSayısı++;

                    //İPUCU GÖSTER
                    if (hak > 0 & (seviye != "5" | seviye != "4") & seviye5EAL_Test != "1")
                    {
                        //hak var ise ve kalıca hafıza testi yok ise ipucu göster

                        List<string> harfler = new List<string>();
                        //harfleri ayır
                        for (int i = 0; i < çeviri.Length; i++)
                        {
                            harfler.Add(çeviri.Substring(i, 1));
                        }

                        string ipucu = çeviri.Substring(0, 1);
                        string boşlukSonrası = "0";
                        for (int i = 0; i < çeviri.Length - 1; i++)
                        {
                            if (i == 3 & denemeSayısı == 3 & yazmalıYanlışYapıldı == 1)
                            {
                                ipucu = "" + ipucu + "" + harfler[i + 1] + "";
                            }
                            else if (boşlukSonrası == "1")
                            {
                                if (denemeSayısı > 1)
                                {
                                    ipucu = "" + ipucu + "" + harfler[i + 1] + "";
                                    boşlukSonrası = "0";
                                }
                                else
                                {
                                    ipucu = "" + ipucu + "#";
                                    boşlukSonrası = "0";
                                }
                            }
                            else if (harfler[i + 1] == " ")
                            {
                                ipucu = "" + ipucu + " ";
                                boşlukSonrası = "1";
                            }
                            else if (harfler[i + 1] == ",")
                            {
                                ipucu = "" + ipucu + ",";
                            }
                            else if (i == çeviri.Length - 2)
                            {
                                ipucu = "" + ipucu + "" + harfler[i + 1] + "";
                            }
                            else
                            {
                                ipucu = "" + ipucu + "#";
                            }
                        }

                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = "İpucu: " + ipucu + "";

                        if (hak != 0)
                        {
                            hak--;
                        }                        
                    }
                    else
                    {
                        //HAK YOK, seviye 4 vrys 5, kalıcı hafıza testi var
                        yanlışCevapGörsel("yazmalı");
                        lbl_ipucu.ForeColor = Color.Red;
                        lbl_ipucu.Visible = true;
                        lbl_ipucu.Text = çeviri;
                        timer_yazmalıSoruArası.Start();
                        yanlışCevap();
                        yanıt = "yanlış";
                        denemeSayısı = 0;
                    }

                    ipucuBilgisiGöster();

                    btn_kelime.Appearance.BackColor = Color.Red;
                    txt_yazmalı_yanıt.SelectAll();
                }

                seviye5EAL_Test = "";
                txt_yazmalı_yanıt.SelectAll();
            }
            else
            {
                MessageBox.Show("Cevap boş olamaz!");
            }
        }

        void çalışmaTemizle()
        {
            txt_yazmalı_yanıt.Text = "";
            lbl_ipucu.Text = "";
            lbl_ipucu.Visible = false;
            lbl_kelimeYanlış_başlık.BackColor = Color.White;
            lbl_kelimeDoğru_başlık.BackColor = Color.White;
            lbl_kelimeDoğru.BackColor = Color.White;
            lbl_kelimeYanlış.BackColor = Color.White;
            s1_btnFavori.BackColor = Color.White;
            btn_kalıcaHafızaOnay.Appearance.BackColor = Color.White;
            btn_sorunbildir.Appearance.BackColor = Color.White;
            lbl_KelimeTür.BackColor = Color.White;

            lbl_kelimeYanlış_başlık.ForeColor = Color.Black;
            lbl_kelimeDoğru_başlık.ForeColor = Color.Black;
            lbl_kelimeDoğru.ForeColor = Color.Black;
            lbl_kelimeYanlış.ForeColor = Color.Black;
            lbl_KelimeTür.ForeColor = Color.Black;
            btn_kelime.ForeColor = Color.Black;


            ipucuBilgisiGöster();
        }

        #region Kategori Butonları

        private void ch_a1_CheckedChanged(object sender, EventArgs e)
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
            ch_fiiller.Checked = false;
        }

        private void ch_fiiller_CheckedChanged(object sender, EventArgs e)
        {
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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
            ch_a1.Checked = false;
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

        public string seviye5EAL_Test = "";

        private void btn_kalıcaHafızaOnay_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Bu kelime zaten ezberimde diyorsun yani?\nEğer doğru bilirsen 'Seviye 5' statüsüne taşınacak.\n\nOnaylıyor musun?", "KALICI HAFIZA", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                seviye5EAL_Test = "1";
                xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
                btn_pas.Enabled = false;
                btn_kelime.Text = çeviri;
                çeviri = kelime;
                ipucuBilgisiGöster();
            }
            else
            {
                seviye5EAL_Test = "";
            }
        }

        private void Seviye5EAl()
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            //kalıcıhafıza ya alıyoruz
            MySqlCommand komut_a2 = new MySqlCommand("update " + kullanıcı + " " +
                     "set seviye_gösterim=@seviye_gösterim, doğru=@doğru, seviye=@seviye where id=@id", bağlantı);
            komut_a2.Parameters.Clear();
            komut_a2.Parameters.AddWithValue("@id", kelimeİd);
            komut_a2.Parameters.AddWithValue("@doğru", Convert.ToInt32(doğru) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_gösterim", Convert.ToInt32(gösterim) + 1);
            komut_a2.Parameters.AddWithValue("@seviye_tarih", bugün);
            komut_a2.Parameters.AddWithValue("@seviye", 5);
            bağlantı.Open();
            komut_a2.ExecuteNonQuery();
            bağlantı.Close();
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
            //if (xt_şıklar.SelectedTabPage == xt_şıklarPage_seçmeli)
            //{
            //    ts_seçmeliYazmalı.EditValue = "seçmeli";
            //}
            //else
            //{
            //    ts_seçmeliYazmalı.EditValue = "yazmalı";
            //    txt_yazmalı_yanıt.Focus();
            //    ipucuBilgisiGöster();
            //}
        }
        private void ts_seçmeliYazmalı_Toggled(object sender, EventArgs e)
        {
            //if (ts_seçmeliYazmalı.EditValue.ToString() == "yazmalı")
            //{
            //    xt_şıklar.SelectedTabPage = xt_şıklarPage_yazmalı;
            //}
            //else if (ts_seçmeliYazmalı.EditValue.ToString() == "seçmeli")
            //{
            //    xt_şıklar.SelectedTabPage = xt_şıklarPage_seçmeli;
            //}
        }

        private void btn_pas_Click(object sender, EventArgs e)
        {
            lbl_ipucu.Visible = true;
            lbl_ipucu.Text = çeviri;
            lbl_ipucu.Appearance.ForeColor = Color.DarkGreen;
            
            timer_yazmalıSoruArası.Start();
            yanlışCevap();
            seviye5EAL_Test = "";
        }

        private void btn_sorunbildir_Click(object sender, EventArgs e)
        {
            Form_SorunBildir frm = new Form_SorunBildir();

            frm.kelimeİd = kelimeİd;
            frm.kelime = kelime;
            frm.cevap = çeviri;
            frm.kullanıcı = kullanıcı;
            frm.kullanıcıİd = kullanıcıİd;
            frm.ShowDialog();
        }

        public void sorunBildirSonrası()
        {
            timer_soruArası.Start();
        }

        private void Form_AnaSayfa_KeyDown(object sender, KeyEventArgs e)
        {
            if (xt_ana.SelectedTabPage == xt_anaPage_giriş)
            {
                if (xt_şifre.SelectedTabPage == xt_şifrePage_giriş & e.KeyCode == Keys.Enter)
                {
                    btn_giriş.PerformClick();
                }
                else if (xt_şifre.SelectedTabPage == xt_şifrePage_ParolaDeğiş & e.KeyCode == Keys.Enter)
                {
                    btn_parolaDeğiştir.PerformClick();
                }
            }
            if (xt_ana.SelectedTabPage == xt_anaPage_seviyeler)
            {
                if (e.KeyCode == Keys.NumPad1)
                {
                    şık_1.PerformClick();
                }
                if (e.KeyCode == Keys.NumPad2)
                {
                    şık_2.PerformClick();
                }
                if (e.KeyCode == Keys.NumPad3)
                {
                    şık_3.PerformClick();
                }
                if (e.KeyCode  == Keys.Enter)
                {
                    btn_yazmalı_ok.PerformClick();
                }
            }
            
        }

        #region KULLANICI GİRİŞİ
        private void btn_giriş_Click(object sender, EventArgs e)
        {
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "SELECT *from kullanıcılar where kullanıcıadı=@kullanıcıadı and parola=@parola";
            komut.Connection = bağlantı;
            komut.CommandType = CommandType.Text;
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@kullanıcıadı", txt_kullanıcıAdı.Text.Trim());
            komut.Parameters.AddWithValue("@parola", txt_parola.Text.Trim());
            MySqlDataReader dr;
            bağlantı.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                panelControl1.Visible = true;
   
                lbl_girişKontrolBilgi.Visible = false;
                lbl_girişKontrolBilgi.ForeColor = Color.Black;
                kullanıcı = dr["kullanıcıadı"].ToString();
                kullanıcıİd = dr["id"].ToString();
                düzey = Convert.ToInt32(dr["düzey"].ToString());
                db_kullanıcıAdı.Text = kullanıcı;
                xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
                btn_anasayfa.Enabled = false;
                btn_anasayfa.Visible = true;
                db_kullanıcıAdı.Visible = true;

                if (düzey>0)
                {
                    btn_kelimeEkle.Visible = true;
                }
            }
            else
            {
                lbl_girişKontrolBilgi.ForeColor = Color.Red;
                lbl_girişKontrolBilgi.Text = "Kullanıcı adı veya parola hatalı.\nKontrol edip tekrar deneyin.";
                lbl_girişKontrolBilgi.Visible = true;
                db_kullanıcıAdı.Visible = true;
            }
            dr.Close();
            bağlantı.Close();
        }
        #endregion

        private void menu_şifreDeğiştir_Click(object sender, EventArgs e)
        {
            xt_şifre.SelectedTabPage = xt_şifrePage_ParolaDeğiş;
            xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;            
        }

        private void btn_parolaDeğiştir_Click(object sender, EventArgs e)
        {
            lbl_pararolaDeğiştirBilgi.Visible = false;
            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "SELECT *from kullanıcılar where id=@id and parola=@parola";
            komut.Connection = bağlantı;
            komut.CommandType = CommandType.Text;
            komut.Parameters.Clear();
            komut.Parameters.AddWithValue("@id", kullanıcıİd);
            komut.Parameters.AddWithValue("@parola", txt_mevcutParola.Text.Trim());
            MySqlDataReader dr;
            bağlantı.Open();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                if (txt_yeniParola.Text.Trim() == txt_yeniParolaTekrar.Text.Trim())
                {
                    try
                    {
                        MySqlCommand komut_a2 = new MySqlCommand("update kullanıcılar " +
                        "set parola=@parola where id=@id", bağlantı);
                        komut_a2.Parameters.Clear();
                        komut_a2.Parameters.AddWithValue("@id", kullanıcıİd);
                        komut_a2.Parameters.AddWithValue("@parola", txt_yeniParolaTekrar.Text.Trim());
                        bağlantı.Close();
                        bağlantı.Open();
                        komut_a2.ExecuteNonQuery();

                        lbl_pararolaDeğiştirBilgi.ForeColor = Color.DarkGreen;
                        lbl_pararolaDeğiştirBilgi.Text = "Parola başarıyla değiştirildi.";
                        lbl_pararolaDeğiştirBilgi.Visible = true;
                    }
                    catch (Exception)
                    {
                        lbl_pararolaDeğiştirBilgi.ForeColor = Color.Red;
                        lbl_pararolaDeğiştirBilgi.Text = "Hata ile karşılaşıldı";
                        lbl_pararolaDeğiştirBilgi.Visible = true;
                    }
                }
                else
                {
                    lbl_pararolaDeğiştirBilgi.ForeColor = Color.Red;
                    lbl_pararolaDeğiştirBilgi.Text = "Yeni parola tekrarları uyuşmuyor.";
                    lbl_pararolaDeğiştirBilgi.Visible = true;
                }
            }
            else
            {
                //mevcut şifre hatalı
                lbl_pararolaDeğiştirBilgi.ForeColor = Color.Red;
                lbl_pararolaDeğiştirBilgi.Text = "Mevcut şifre hatalı";
                lbl_pararolaDeğiştirBilgi.Visible = true;
            }
            dr.Close();
            bağlantı.Close();
        }

        private void bar_Btn_ŞifreDeğiştir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Visible = true;
            xt_şifre.SelectedTabPage = xt_şifrePage_ParolaDeğiş;
            xt_ana.SelectedTabPage = xt_anaPage_giriş;
            btn_anasayfa.Visible = true;
            panelControl1.Visible = false;
        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            panelControl1.Visible = true;
            xt_ana.SelectedTabPage = xt_anaPage_Anasayfa;
        }

        private void db_kullanıcıAdı_TextChanged(object sender, EventArgs e)
        {
            if (db_kullanıcıAdı.Text != "")
            {
                bar_Btn_ŞifreDeğiştir.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                bar_Btn_ŞifreDeğiştir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void timer_geçiş_Tick(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
        }
    }
}