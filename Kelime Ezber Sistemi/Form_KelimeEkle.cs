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
        public string kullanıcı = "";

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

            lbl_yüzde.Text = "Yüklenen: " + 0 + "/" + gridView1.RowCount + "";
        }

        void sayıSay(int i, int toplam)
        {
            lbl_yüzde.Text = "Yüklenen: "+i+"/" + toplam + "";
        }

        private void işlem(int i)
        {
            sayıSay(i, gridView1.RowCount);

            MySqlConnection bağlantı = new MySqlConnection(bağlantıadresi);
            string id = gridView1.GetRowCellValue(i, "id").ToString();

            string sorgu = "Insert into " + kullanıcı + " (EN,TR,oku,tür,alan,kur,eş,ko)" +
            " values " +
            "(@EN,@TR,@oku,@tür,@alan,@kur,@eş,@ko)";

            string sorguUpdate = "update " + kullanıcı + " " +
                     "set EN=@EN, TR=@TR, oku=@oku, tür=@tür, alan=@alan, kur=@kur, eş=@eş, ko=@ko where id=@id";

            if (id != "")
            {
                // güncelleme
                MySqlCommand komut_a2 = new MySqlCommand(sorguUpdate, bağlantı);
                komut_a2.Parameters.Clear();
                komut_a2.Parameters.AddWithValue("@id", id);
                komut_a2.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                komut_a2.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                komut_a2.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                komut_a2.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));
                komut_a2.Parameters.AddWithValue("@kur", gridView1.GetRowCellValue(i, "kur"));
                komut_a2.Parameters.AddWithValue("@oku", gridView1.GetRowCellValue(i, "oku"));
                komut_a2.Parameters.AddWithValue("@eş", gridView1.GetRowCellValue(i, "eş"));
                komut_a2.Parameters.AddWithValue("@ko", gridView1.GetRowCellValue(i, "ko"));

                bağlantı.Open();
                komut_a2.ExecuteNonQuery();
                bağlantı.Close();
            }
            else
            {
                // yeni kayıt
                MySqlCommand komut = new MySqlCommand(sorgu, bağlantı);
                komut.Parameters.AddWithValue("@TR", gridView1.GetRowCellValue(i, "TR"));
                komut.Parameters.AddWithValue("@EN", gridView1.GetRowCellValue(i, "EN"));
                komut.Parameters.AddWithValue("@tür", gridView1.GetRowCellValue(i, "tür"));
                komut.Parameters.AddWithValue("@alan", gridView1.GetRowCellValue(i, "alan"));
                komut.Parameters.AddWithValue("@kur", gridView1.GetRowCellValue(i, "kur"));
                komut.Parameters.AddWithValue("@oku", gridView1.GetRowCellValue(i, "oku"));
                komut.Parameters.AddWithValue("@eş", gridView1.GetRowCellValue(i, "eş"));
                komut.Parameters.AddWithValue("@ko", gridView1.GetRowCellValue(i, "ko"));

                bağlantı.Open();
                komut.ExecuteNonQuery();
                bağlantı.Close();
            }

        }

        private void btn_yükle_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 200)
            {
                for (int i = 0; i < 201; i++)
                {
                    işlem(i);
                    sayıSay(i, gridView1.RowCount);
                }
                sayıSay(200, gridView1.RowCount);
            }
            else
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }

            //200-400
            if (gridView1.RowCount > 200 & gridView1.RowCount > 400)
            {
                for (int i = 201; i < 400; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 201; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            sayıSay(400, gridView1.RowCount);
            //200-400 SONU

            //400-600
            if (gridView1.RowCount > 399 & gridView1.RowCount > 600)
            {
                for (int i = 400; i < 600; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 400; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //400-600 SONU

            //600-800
            if (gridView1.RowCount > 599 & gridView1.RowCount > 800)
            {
                for (int i = 600; i < 800; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 600; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //600-800 SONU
            sayıSay(800, gridView1.RowCount);

            //800-1000
            if (gridView1.RowCount > 799 & gridView1.RowCount > 1000)
            {
                for (int i = 800; i < 1000; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 800; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //800-1000 SONU

            //1000-1200
            if (gridView1.RowCount > 999 & gridView1.RowCount > 1200)
            {
                for (int i = 1000; i < 1200; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1000; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1000-1200 SONU


            //1200-1400
            if (gridView1.RowCount > 1199 & gridView1.RowCount > 1400)
            {
                for (int i = 1200; i < 1400; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1200; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1200-1400 SONU

            //1400-1500
            if (gridView1.RowCount > 1399 & gridView1.RowCount > 1500)
            {
                for (int i = 1400; i < 1500; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1400; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1400-1500 SONU

            //1500-1600
            if (gridView1.RowCount > 1499 & gridView1.RowCount > 1600)
            {
                for (int i = 1500; i < 1600; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1500; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1500-1600 SONU

            //1600-1700
            if (gridView1.RowCount > 1599 & gridView1.RowCount > 1700)
            {
                for (int i = 1600; i < 1700; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1600; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1600-1700 SONU

            //1700-1800
            if (gridView1.RowCount > 1699 & gridView1.RowCount > 1800)
            {
                for (int i = 1700; i < 1800; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1700; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1700-1800 SONU

            //1800-1900
            if (gridView1.RowCount > 1799 & gridView1.RowCount > 1900)
            {
                for (int i = 1800; i < 1900; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1800; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1800-1900 SONU

            //1900-2000
            if (gridView1.RowCount > 1899 & gridView1.RowCount > 2000)
            {
                for (int i = 1900; i < 2000; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 1900; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //1900-2000 SONU

            //2000-2050
            if (gridView1.RowCount > 1999 & gridView1.RowCount > 2050)
            {
                for (int i = 2000; i < 2050; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 2000; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //2000-2050 SONU

            //2050-2100
            if (gridView1.RowCount > 2049 & gridView1.RowCount > 2100)
            {
                for (int i = 2050; i < 2100; i++)
                {
                    işlem(i);
                }
            }
            else
            {
                for (int i = 2050; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }
            //2050-2100 SONU

            //2100-2200
            if (gridView1.RowCount > 2099 & gridView1.RowCount > 2150)
            {
                for (int i = 2100; i < 2150; i++)
                {
                    işlem(i);
                }

                //2150-2200
                if (gridView1.RowCount < 2201) // 2200 'E KADAR DESTEKLİYOR O YÜZDEN
                {
                    for (int i = 2150; i < gridView1.RowCount; i++)
                    {
                        işlem(i);
                    }
                }
                //2100-2200 SONU
            }
            else
            {
                for (int i = 2100; i < gridView1.RowCount; i++)
                {
                    işlem(i);
                }
            }

            sayıSay(gridView1.RowCount, gridView1.RowCount);
            MessageBox.Show("Yükleme Tamamlandı");
        }
    }
}