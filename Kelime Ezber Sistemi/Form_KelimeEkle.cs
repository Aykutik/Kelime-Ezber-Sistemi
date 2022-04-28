using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kelime_Ezber_Sistemi
{
    public partial class Form_KelimeEkle : DevExpress.XtraEditors.XtraForm
    {
        public Form_KelimeEkle()
        {
            InitializeComponent();
        }

        public string bağlantıadresi = "server=loyaz.net;user id=u477970783_kelimeezber; database=u477970783_kelimeezber; Pwd=aykuT18092007; Charset = utf8";
        //public string bağlantıadresi = "server=eu-cdbr-west-02.cleardb.net;user id=bdbb59f8e5a999; database=heroku_35277f60d273b6a; Pwd=9e92108f; Charset = utf8";

        private void btn_gözat_Click(object sender, EventArgs e)
        {
            string yol = "";
            openFileDialog1.Filter = "EXCEL (*.xlsx) | *.xlsx";
            openFileDialog1.FileName = "Dosya";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Bir Excel Dosyas Seçiniz";
            string cmd = "Select * from [Sayfa1$]";

            //openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yol = openFileDialog1.FileName;
                lbl_dosyaİsmi.Text = openFileDialog1.SafeFileName;
                OleDbConnection bağlantı = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + yol + ";Extended Properties=Excel 12.0;");


                OleDbDataAdapter adp = new OleDbDataAdapter(cmd, bağlantı);
                DataTable ds = new DataTable();
                adp.Fill(ds);
                gridControl_kelimeEkle.DataSource = ds;
            }
        }
        public string sayı = "";
        void sayıSay()
        {
            lbl_yüzde.Text = sayı;
        }

        private void kelimeYükle()
        {
            
            if (gridView1.RowCount > 300)
            {
                for (int i = 0; i < 300; i++)
                {
                    MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                    //Yeni Eklenecek Kayıt
                    string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                    " values " +
                    "(@TR,@EN,@tür,@alan)";
                    MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                    komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                    komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                    komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                    komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                    bağlantı.Open();
                    komut.ExecuteNonQuery();
                    bağlantı.Close();                    
                }
                sayı = "300/" + gridView1.RowCount + "";
                sayıSay();
                
                if (gridView1.RowCount > 600)//300-600
                {
                    for (int i = 300; i < 600; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "600/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 300; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = ""+ gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//300-600


                if (gridView1.RowCount > 900)//600-900
                {
                    for (int i = 600; i < 900; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı= "900/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 600; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//600-900
                                
                if (gridView1.RowCount > 1200)//900-1200
                {
                    for (int i = 900; i < 1200; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);

                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "1200/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 900; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//900-1200


                if (gridView1.RowCount > 1200)//1200-1500
                {
                    for (int i = 1200; i < 1500; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "1500/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 1200; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//1200-1500

                if (gridView1.RowCount > 1800)//1500-1800
                {
                    for (int i = 1500; i < 1800; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    lbl_yüzde.Text = "1800/" + gridView1.RowCount + "";
                }
                else
                {
                    for (int i = 1500; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//1500-1800

                if (gridView1.RowCount > 2100)//1800-2100
                {
                    for (int i = 1800; i < 2100; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "2100/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 1800; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//1800-2100

                if (gridView1.RowCount > 2400)//2100-2400
                {
                    for (int i = 2100; i < 2400; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "2400/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 2100; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }

                if (gridView1.RowCount > 2700)//2400-3000
                {
                    for (int i = 2400; i < 2700; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "2700/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 2400; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//2400-2700

                if (gridView1.RowCount > 2700)//2700-3000
                {
                    for (int i = 2700; i < 3001; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "3000/" + gridView1.RowCount + "";
                    sayıSay();
                }
                else
                {
                    for (int i = 2700; i < gridView1.RowCount; i++)
                    {
                        MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                        //Yeni Eklenecek Kayıt
                        string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                        " values " +
                        "(@TR,@EN,@tür,@alan)";
                        MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                        komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                        komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                        komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                        komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                        bağlantı.Open();
                        komut.ExecuteNonQuery();
                        bağlantı.Close();
                    }
                    sayı = "" + gridView1.RowCount + "/" + gridView1.RowCount + "";
                    sayıSay();
                }//2700-3000
            }
            else
            {
                //300 den küçük ise
                for (int i = 300; i < gridView1.RowCount; i++)
                {
                    MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
                    //Yeni Eklenecek Kayıt
                    string sorgu = "Insert into kullanıcı1 (TR,EN,tür,alan)" +
                    " values " +
                    "(@TR,@EN,@tür,@alan)";
                    MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                    komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                    komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                    komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                    komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));

                    bağlantı.Open();
                    komut.ExecuteNonQuery();
                    bağlantı.Close();
                }
            }
            MessageBox.Show("Yükleme Tamamlandı");
        }
        
        

        private void btn_yükle_Click(object sender, EventArgs e)
        {
            kelimeYükle();
        }
    }
}